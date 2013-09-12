using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using TimeTracks.Core;

namespace TimeTracks.API
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Utils.JsonResponse(Response, true);
            }
            else {
                Utils.JsonResponse(Response, false, new
                {
                    error = "NOT_LOGGED_IN"
                });
            }
        }
    }
}