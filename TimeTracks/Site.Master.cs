using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using TimeTracks.Data;
using TimeTracks.Core;

namespace TimeTracks
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            
            // If it's a post back, don't bother.
            if (Page.IsPostBack) return;

            // See if it's a new session.
            if (!CurrentSession.Active)
            {

                // Check if we are already logged in. If we are, get our real user name and account name.
                // (may want to change it to first/last name, though.
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // Get the user that is logged in.
                    var user = Sprocs.GetUserByAspId(Membership.GetUser().ProviderUserKey.ToString());

                    // If we have a valid user, create a new session object.
                    if (user != null)
                    {
                        CurrentSession.Active = true;
                        CurrentSession.AccountId = user.Account.Id;
                        CurrentSession.AspId = user.ASPid;
                        CurrentSession.DispalyName = String.Format("{0}, {1} {2}", user.Account.Name, user.FirstName, user.LastName);
                        CurrentSession.UserId = user.Id;
                        CurrentSession.Username = user.UserName;
                        CurrentSession.UserRole = user.Role;

                    }
                }
            }

            if (CurrentSession.Active)
            {
                var loginName = LoginView1.FindControl("LoginName1") as LoginName;

                if (loginName != null)
                {
                    loginName.FormatString = CurrentSession.DispalyName;
                }
            }
        }

        public void UpdateContextMenu(List<KeyValuePair<string, string>> linkList) {

            foreach (var link in linkList)
            {
                var li = new HtmlGenericControl("li");
                MenuList.Controls.Add(li);

                var anchor = new HtmlGenericControl("a");
                anchor.InnerText = link.Key;
                anchor.Attributes.Add("href", link.Value);
                
                li.Controls.Add(anchor);
            }
        }

        public void ToggleContextMenu(bool enable)
        {
            // Not working.
             //this.FindControl("tracks-body-content-menu").Visible = enable;
        }

        protected void LoginStatus_LoggedOut(Object sender, System.EventArgs e)
        {
            Session.Abandon();
        }
    }
}