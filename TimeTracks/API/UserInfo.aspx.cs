using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using TimeTracks.Data;
using TimeTracks.Core;

namespace TimeTracks.API
{
    public partial class UserInfo : System.Web.UI.Page
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
            else
            {
                Utils.JsonResponse(Response, false, new
                {
                    error = "NOT_LOGGEDIN"
                });
            }
        }
    }
}