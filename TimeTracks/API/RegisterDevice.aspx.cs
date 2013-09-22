using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeTracks.Core;
using TimeTracks.Data;

namespace TimeTracks.API
{
    public partial class RegisterDevice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var deviceId = Request["id"];
            var serial = Request["serial"];

            // Are we logged in?
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Utils.JsonResponse(Response, false, new
                {
                    error = "NOT_LOGGED_IN"
                });
                return;
            }

            // Do we have a device ID?
            if (deviceId == null)
            {
                Utils.JsonResponse(Response, false, new
                {
                    error = "NO_DEVICE_SPECIFIED"
                });
                return;
            }

            // Do we have a device ID?
            if (serial == null)
            {
                Utils.JsonResponse(Response, false, new
                {
                    error = "NO_SERIAL_SPECIFIED"
                });
                return;
            }

            // Is this a valid device?
            var device = Sprocs.GetDevice(deviceId);
            if (device == null)
            {
                Utils.JsonResponse(Response, false, new
                {
                    error = "INVALID_DEVICE_ID"
                });
                return;
            }

            if (!String.IsNullOrWhiteSpace(device.Serial))
            {
                Utils.JsonResponse(Response, false, new
                {
                    error = "DEVICE_ALREADY_REGISTERED"
                });
                return;
            }

            Utils.JsonResponse(Response, Sprocs.RegisterDevice(device, serial));
        }
    }
}