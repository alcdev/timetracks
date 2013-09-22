using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using TimeTracks.Core;
using TimeTracks.Data;

namespace TimeTracks.API
{
    public partial class LogLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double longitude, latitude;
            var lng = Request["lng"];  // longitude
            var lat = Request["lat"];  // latitude
            var deviceId = Request["id"];  // device's GUID
            var serial = Request["serial"]; // devices's serial.

            // Are we logged in?
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Utils.JsonResponse(Response, false, new
                {
                    error = "NOT_LOGGED_IN"
                });
                return;
            }

            // Let's see if the coords seem valid.
            if (!Double.TryParse(lng, out longitude) || !Double.TryParse(lat, out latitude)) {
                Utils.JsonResponse(Response, false, new
                {
                    error = "INVALID_COORDINATES"
                });
                return;
            }

            // Do we have a device ID?
            if (deviceId == null) {
                Utils.JsonResponse(Response, false, new
                {
                    error = "NO_DEVICE_SPECIFIED"
                });
                return;
            }

            // Do we have a device serial?
            if (serial == null) {
                Utils.JsonResponse(Response, false, new
                {
                    error = "NO_SERIAL_SPECIFIED"
                });
                return;
            }

            // Is this a valid device?
            var device = Sprocs.GetDevice(deviceId);
            if (device == null) {
                Utils.JsonResponse(Response, false, new
                {
                    error = "INVALID_DEVICE_ID"
                });
                return;
            }

            // See if it is the registered device.
            if (String.IsNullOrWhiteSpace(device.Serial))
            {
                Utils.JsonResponse(Response, false, new
                {
                    error = "UREGISTERED_DEVICE"
                });
                return;
            }

            // See if it is the correct device.
            if (device.Serial != serial)
            {
                Utils.JsonResponse(Response, false, new
                {
                    error = "INVALID_DEVICE_SERIAL"
                });
                return;
            }

            // Looks like we're OK to log it.
            var locatioonLog = new LocationLog();
            locatioonLog.Device = device;
            locatioonLog.Latitude = latitude;
            locatioonLog.Longitude = longitude;
            locatioonLog.TimeStamp = DateTime.Now;

            Sprocs.CreateLocationLog(locatioonLog);

            Utils.JsonResponse(Response, true);
        }
    }
}