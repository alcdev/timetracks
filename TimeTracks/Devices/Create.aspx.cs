using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using TimeTracks.Data;

namespace TimeTracks.Devices
{
    public partial class Create : System.Web.UI.Page
    {
        private string aspId;
        private TimeTracks.Data.Account account;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                aspId = Membership.GetUser().ProviderUserKey.ToString();
                account = Sprocs.GetUserAccount(aspId);
            }
            else
            {
                Forbidden();
                return;
            }

            var role = Sprocs.GetUserRole(aspId);
            if (role == RoleTypes.Admin || role == RoleTypes.Manager)
            {
                if (!Page.IsPostBack)
                {
                    PopulateControls();
                }
            }
            else
            {
                Forbidden();
            }
        }

        private void PopulateControls()
        {

            // Populate dropdown controls.
            Sprocs.GetDeviceOwners().ForEach(owner => OwnerDropDown.Items.Add(owner));

            Sprocs.GetUsers(account.Id).ForEach(user =>
                UserDropDown.Items.Add(new ListItem(user.UserName, user.Id.ToString())));

            DeviceIdTextBox.Text = Guid.NewGuid().ToString();
        }

        private void Forbidden()
        {

            // if we get this far, nothing valid was passed and no one is logged in, 404.  
            // TODO: create a proper 404 page.
            Response.Status = "403 Forbidden - You must sign in to access this page. ";
            Response.StatusCode = 403;

            // TODO: an error message would be nice.  Perhaps we should have a 403 re-direct.
            editDevice.Controls.Clear();
        }

        protected void EditIdButton_Click(object sender, EventArgs e)
        {
            DeviceIdTextBox.Enabled = true;
            EditIdButton.Visible = false;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int userID = 0;
            Int32.TryParse(UserDropDown.SelectedValue, out userID);

            var device = new Device();
            device.Name = DeviceNameTextBox.Text;
            device.Serial = SerialNumberTextBox.Text;
            device.UID = DeviceIdTextBox.Text;
            device.Owner = Sprocs.GetDeviceOwner(OwnerDropDown.SelectedValue);
            device.User = Sprocs.GetUserById(userID);

            Sprocs.CreateDevice(device);

            Response.Redirect("/");
        }
    }
}