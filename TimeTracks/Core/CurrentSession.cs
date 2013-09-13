using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TimeTracks.Data;

namespace TimeTracks.Core
{
    public static class CurrentSession
    {
        private static bool active;
        public static bool Active
        {
            get
            {
                // Active is a bit different then the rest.  If it's not an active session, everything else will be created.
                // But active itself will need to be created the first time, if it's null.
                if (HttpContext.Current.Session["tt_active"] == null)
                {
                    HttpContext.Current.Session.Add("tt_active", false);
                }

                return (bool) HttpContext.Current.Session["tt_active"];
            }
            set { HttpContext.Current.Session.Add("tt_active", value); }
        }

        private static int userId;
        public static int UserId
        {
            get { return (int) HttpContext.Current.Session["tt_userid"]; }
            set { HttpContext.Current.Session.Add("tt_userid", value); }
        }

        private static int accountId;
        public static int AccountId
        {
            get { return (int) HttpContext.Current.Session["tt_accountid"]; ; }
            set { HttpContext.Current.Session.Add("tt_accountid", value); }
        }

        private static string username;
        public static string Username
        {
            get { return (string) HttpContext.Current.Session["tt_username"]; }
            set { HttpContext.Current.Session.Add("tt_username", value); }
        }

        private static string dispalyName;
        public static string DispalyName
        {
            get { return (string) HttpContext.Current.Session["tt_displayname"]; }
            set { HttpContext.Current.Session.Add("tt_displayname", value); }
        }

        private static string aspId;
        public static string AspId
        {
            get { return (string) HttpContext.Current.Session["tt_aspid"]; }
            set { HttpContext.Current.Session.Add("tt_aspid", value); }
        }

        private static RoleTypes userRole;
        public static RoleTypes UserRole
        {
            get { return (RoleTypes) HttpContext.Current.Session["tt_role"]; }
            set { HttpContext.Current.Session.Add("tt_role", value); }
        }
    }
}