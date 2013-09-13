using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Google.Maps;
using Google.Maps.StaticMaps;
using Google.Maps.Geocoding;

namespace TimeTracks.Scheduling
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["lat"] != null && Request["lng"] != null)
            {
                ShowMap(Request["lat"], Request["lng"]);
            }

            if (Request["loc"] != null)
            {
                var loc = Request["loc"].ToString();
                ShowMap(loc);
            }
        }

        private void ShowMap(string latitude, string longitude)
        {            
            double lat, lng;
            if (!Double.TryParse(latitude, out lat) || !Double.TryParse(longitude, out lng)) return;
            
            var map = new StaticMapRequest();
            var latlon = new LatLng(lat, lng);
            map.Center = latlon;
            map.Size = new System.Drawing.Size(400, 400);
            map.Zoom = 15;
            map.Sensor = false;
            map.Markers.Add(latlon);

            var imgTagSrc = map.ToUri();
            locationImage.ImageUrl = imgTagSrc.ToString();
        }

        private void ShowMap(string loc)
        {
            var map = new StaticMapRequest();
            var clifton = new Location(loc);
            var latlon = new LatLng(41.498333300000000000, -81.693888899999990000);
            map.Center = latlon;
            map.Size = new System.Drawing.Size(400, 400);
            map.Zoom = 14;
            map.Sensor = false;
            map.Markers.Add(latlon);

            var imgTagSrc = map.ToUri();
            locationImage.ImageUrl = imgTagSrc.ToString();
        }
    }
}