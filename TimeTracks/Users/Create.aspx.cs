using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using TimeTracks.Data;
using TimeTracks.Core;

namespace TimeTracks.Users
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CurrentSession.Active || CurrentSession.UserRole != RoleTypes.Admin)
            {
                Forbidden();
                return;
            }

            if (!Page.IsPostBack)
            {
                PopulateControls();
            }
        }

        private void PopulateControls()
        {
            // Populate dropdown controls.
            Sprocs.GetRoleTypes().ForEach(role => RoleDropDown.Items.Add(role));
            Sprocs.GetPayIntervals().ForEach(interval => PayIntervalDropDown.Items.Add(interval));

            // Add context menu items to master.
            var linkList = new List<KeyValuePair<string, string>>();
            var master = Master as SiteMaster;

            linkList.Add(new KeyValuePair<string,string>("Add Device", "/devices/create"));
            master.UpdateContextMenu(linkList);
        }

        private void Forbidden()
        {

            // if we get this far, nothing valid was passed and no one is logged in, 404.  
            // TODO: create a proper 404 page.
            Response.Status = "403 Forbidden - You must sign in to access this page. ";
            Response.StatusCode = 403;

            // TODO: an error message would be nice.  Perhaps we should have a 403 re-direct.
            editUser.Controls.Clear();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // TODO: validate all fields.
            if (PasswordTextBox1.Text != PasswordTextBox2.Text) return;

            // Silly hack until we create a proper numeric-only textbox.
            decimal payRate = 0;
            Decimal.TryParse(PayrateTextBox.Text, out payRate);

            var user = new User();
            user.Active = true; // If we're creating them, they are likely active.
            user.Email = EmailTextBox.Text;
            user.FirstName = FirstNameTextBox.Text;
            user.LastName = LastNameTextBox.Text;
            user.PayRate = payRate;
            user.Role = Sprocs.GetRoleType(RoleDropDown.SelectedValue);
            user.PayInterval = Sprocs.GetPayInterval(PayIntervalDropDown.SelectedValue);
            user.UserName = UserNameTextBox.Text;
            user.Account = Sprocs.GetUserAccount(CurrentSession.AspId); // it's the same account we're creating the user from.

            Sprocs.CreateUser(user, PasswordTextBox1.Text);

            Response.Redirect("/");
        }
    }
}