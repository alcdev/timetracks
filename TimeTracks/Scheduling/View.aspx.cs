using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using TimeTracks.Data;
using TimeTracks.Core;

namespace TimeTracks.Scheduling
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CurrentSession.Active || !(CurrentSession.UserRole == RoleTypes.Admin || CurrentSession.UserRole == RoleTypes.Manager))
            {
                Forbidden();
                return;
            }

            if (!Page.IsPostBack)
            {
                PopulateControls();
            }

        }

        private void Forbidden()
        {

            // if we get this far, nothing valid was passed and no one is logged in, 404.  
            // TODO: create a proper 404 page.
            Response.Status = "403 Forbidden - You must sign in to access this page.";
            Response.StatusCode = 403;

            // TODO: an error message would be nice.  Perhaps we should have a 403 re-direct.
            viewScheduling.Controls.Clear();
        }

        private void PopulateControls()
        {
            // Add context menu items to master.
            var linkList = new List<KeyValuePair<string, string>>();
            var master = Master as SiteMaster;

            foreach (var user in Sprocs.GetUsers(CurrentSession.AccountId))
            {
                /* TODO: pretty URLs.
                linkList.Add(new KeyValuePair<string, string>(
                    user.UserName,  String.Format(
                    "/scheduling/view/{0}/{1}", CurrentSession.AccountId, user.Id)));
                 */
                linkList.Add(new KeyValuePair<string, string>(
                    user.UserName, String.Format(
                    "/scheduling/view?ac={0}&ur={1}", CurrentSession.AccountId, user.Id)));
            }

            master.UpdateContextMenu(linkList);
        }
    }
}