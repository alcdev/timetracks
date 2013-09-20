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
    public partial class GetDevices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if we are already logged in. (see the redirect below)
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // Get the user that is logged in.
                var user = Sprocs.GetUserByAspId(Membership.GetUser().ProviderUserKey.ToString());
                var devices = new List<object>();
                var getUnregistered = (Request["unreg"] != null);

                foreach (var device in user.Devices)
                {

                    // See if we're only asking for unregistured devices.  If so, skip ones with a serial.
                    if (getUnregistered && !String.IsNullOrEmpty(device.Serial)) continue;

                    devices.Add(new
                    {
                        name = device.Name,
                        id = device.UID,
                        owner = Sprocs.GetDeviceOwner(device.Owner),
                        serial = device.Serial
                    });
                }

                if (devices.Count > 0)
                {
                    Utils.JsonResponse(Response, true, devices);
                }
                else {
                    Utils.JsonResponse(Response, false, new
                    {
                        error = getUnregistered ? "NO_UNREGISTERED_DEVICES" : "NO_DEVICES"
                    });
                }

                return;
            }
            else
            {
                Utils.JsonResponse(Response, false, new
                {
                    error = "NOT_LOGGED_IN"
                });
            }
        }
    }
}