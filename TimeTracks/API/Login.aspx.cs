using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using TimeTracks.Data;
using TimeTracks.Core;

namespace TimeTracks.API
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

                    // Not sure is we should respond with just the success call, or the user's info.
                    Utils.JsonResponse(Response, true);
                    //Response.Redirect("userinfo"); 
                }
                else
                {
                    Utils.JsonResponse(Response, false, new
                    {
                        error = "INVALID_PASSWORD_USER_OR_ACCOUNT"
                    });
                }
            }

            // if we get this far, nothing valid was passed and no one is logged in, 404.  
            // TODO: create a proper 404 page.
            Response.Status = "404 Not Found - The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications.";
            Response.StatusCode = 404;
        }
    }
}
