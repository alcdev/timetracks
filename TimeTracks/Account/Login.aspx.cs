using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeTracks.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Create";

            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            var username = AccountTextBox.Text + '-' + UsernameTextBox.Text;
            
            if (Membership.ValidateUser(username, PasswordTextBox.Text))
            {
                if (RememberCheckBox.Checked) FormsAuthentication.SetAuthCookie(username, true);
            }
            else {
                FailureText.Visible = true;
                FailureText.Text = "Invalid Username, Password or Account";
            }
        }
    }
}