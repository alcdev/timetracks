using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

using TimeTracks.Data;
using TimeTracks.Core;

namespace TimeTracks.API
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if we are already logged in. (see the redirect below)
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // Get the user that is logged in.
                var user = Sprocs.GetUserByAspId(Membership.GetUser().ProviderUserKey.ToString());

                Utils.JsonResponse(Response, true, new
                {
                    username = user.UserName,
                    userID = user.Id,
                    accountName = user.Account.Name,
                    accountID = user.Account.Id
                });

                return;
            }

            // No one is logged in, let's see if this is a login request.
            var username = Request["un"];  // username
            var password = Request["pw"];  // password
            var account = Request["ac"];  // account

            if (username != null && password != null && account != null)
            {
                username = account + '-' + username;
                if (Membership.ValidateUser(username, password))
                {
                    FormsAuthentication.SetAuthCookie(username, true);

                    // We need to do this, because if we don't reload the page, we get a null response.
                    Response.Redirect("login"); // redirect back and respond with user json.
                }
                else
                {
                    Utils.JsonResponse(Response, false, new
                    {
                        error = "Invalid username, password or account"
                    });
                }
            }

            // if we get this far, nothing valid was passed and no one is logged in, 404.  
            // TODO: create a proper 404 page.
            Response.Status = "404 Not Found";
            Response.StatusCode = 404;
        }
    }
}
