using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TimeTracks.Data
{
    public static class Sprocs
    {
        private static TimeTracksContainer db = new TimeTracksContainer();

        public static int CreateAccount(Account account, User user, string password) {

            // Nothing to check for accounts, just save and return the ID.
            db.Accounts.Add(account);
            db.SaveChanges();

            // Create User in ASP DB.
            MembershipUser User = Membership.CreateUser(account.Id.ToString() + '-' + user.UserName, password, user.Email);
            user.ASPid = User.ProviderUserKey.ToString();
            db.SaveChanges();

            return account.Id;
        }

        public static int CreateUser(User user, string password) {
            // Check for nullable props that have no value.
            if (!user.PayRate.HasValue) {
                user.PayRate = null;
            }
            if (!user.PayInterval.HasValue) {
                user.PayInterval = null;
            }

            // You'd never create an 'inactive' user.
            user.Active = true;

            // Create the user in the ASP.Net membership database.
            MembershipUser User = Membership.CreateUser(user.Account.Id.ToString() + '-' + user.UserName, password, user.Email);
            user.ASPid = User.ProviderUserKey.ToString();

            // add user, save changes, return user ID.
            db.Users.Add(user);
            db.SaveChanges();

            return user.Id;
        }

        public static int CreateLocation(Location location) {

            // Nothing to check for locations, just save and return the ID.
            db.Locations.Add(location);
            db.SaveChanges();
            return location.Id;
        }

        public static int CreateCompany(Company company) {

            // nothing to check, just add and return.
            db.Companies.Add(company);
            db.SaveChanges();
            return company.Id;
        }

        public static int CreateAdderess(Adderess adderess) {

            // check for nullable.
            if (!adderess.Primary.HasValue) {
                adderess.Primary = null;
            }
            if (String.IsNullOrWhiteSpace(adderess.Suite)) {
                adderess.Suite = null;
            }

            // add, save, return id.
            db.Adderesses.Add(adderess);
            db.SaveChanges();
            return adderess.Id;
        }

        public static int CreateDevice(Device device)
        {
            // check for nullables.
            if (String.IsNullOrWhiteSpace(device.Serial))
            {
                device.Serial = null;
            }

            db.Devices.Add(device);
            db.SaveChanges();
            return device.Id;
        }

        public static User GetUserByAspId(string aspId) {
            return (from u in db.Users
                    where u.ASPid == aspId
                    select u).SingleOrDefault();
        }

        public static User GetUserById(int userID)
        {
            return (from u in db.Users
                    where u.Id == userID
                    select u).SingleOrDefault();
        }

        public static RoleTypes GetUserRole(string aspId) {
            return (from u in db.Users
                    where u.ASPid == aspId
                    select u).SingleOrDefault().Role;
        }

        public static Account GetUserAccount(string aspId)
        {
            return (from u in db.Users
                    where u.ASPid == aspId
                    select u).SingleOrDefault().Account;
        }

        public static List<Company> GetCompanies(int accountId)
        {
            // TODO: sort by name.
            return (from c in db.Companies
                    where c.Account.Id == accountId
                    select c).ToList();
        }

        public static List<User> GetUsers(int accountId)
        {
            // TODO: sort by name.
            return (from c in db.Users
                    where c.Account.Id == accountId
                    select c).ToList();
        }

        public static Company GetCompany(int companyId)
        {
            return (from c in db.Companies
                    where c.Id == companyId
                    select c).SingleOrDefault();
        }

        public static List<string> GetDaysOfWeek()
        {
            return EnumToList(typeof(Days));
        }

        public static Days GetDayOfWeek(string day)
        {
            return (Days)NameToEnum(day, typeof(Days));
        }

        public static List<string> GetRoleTypes()
        {
            return EnumToList(typeof(RoleTypes));
        }

        public static RoleTypes GetRoleType(string role)
        {
            return (RoleTypes)NameToEnum(role, typeof(RoleTypes));
        }

        public static List<string> GetPayIntervals()
        {
            return EnumToList(typeof(PayIntervals));
        }

        public static PayIntervals GetPayInterval(string interval)
        {
            return (PayIntervals)NameToEnum(interval, typeof(PayIntervals));
        }

        public static List<string> GetDeviceOwners()
        {
            return EnumToList(typeof(DeviceOwner));
        }

        public static DeviceOwner GetDeviceOwner(string interval)
        {
            return (DeviceOwner)NameToEnum(interval, typeof(DeviceOwner));
        }

        // UTILS
        private static object NameToEnum(string enumName, Type type)
        {
            return Enum.Parse(type, enumName.Replace(" ", "_"));
        }

        private static List<string> EnumToList(Type type)
        {
            var list = Enum.GetNames(type);
            return list.Select(n => n.Replace("_", " ")).ToList();
        }
    }
}