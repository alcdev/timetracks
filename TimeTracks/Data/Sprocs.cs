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
            // Create the user in the ASP.Net membership database.
            MembershipUser User = Membership.CreateUser(user.Account.Id.ToString() + user.UserName, password, user.Email);
            user.ASPid = User.ProviderUserKey.ToString();

            // Check for nullable props that have no value.
            if (!user.PayRate.HasValue) {
                user.PayRate = null;
            }
            if (!user.PayInterval.HasValue) {
                user.PayInterval = null;
            }

            // You'd never create an 'inactive' user.
            user.Active = true;

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
            if (String.IsNullOrEmpty(adderess.Suite)) {
                adderess.Suite = null;
            }

            // add, save, return id.
            db.Adderesses.Add(adderess);
            db.SaveChanges();
            return adderess.Id;
        }

        public static User GetUserByAspId(string aspId) {
            return (from u in db.Users
                    where u.ASPid == aspId
                    select u).SingleOrDefault();
        }

        public static List<string> GetDaysOfWeek()
        {
            return EnumToList(typeof(Days));
        }

        public static Days GetDayOfWeek(string phoneType)
        {
            return (Days)NameToEnum(phoneType, typeof(Days));
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