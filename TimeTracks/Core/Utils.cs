using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

//using TimeTracks.API;
//using TimeTracks.Data;

namespace TimeTracks.Core
{
    public static class Utils
    {
        // TODO: make a proper private helper.
        public static void JsonResponse(HttpResponse response, bool status, object data)
        {
            var success = status ? "success" : "failed";
            var json = JsonConvert.SerializeObject(new { status = success, data });

            response.Clear();
            response.ContentType = "text/json; charset=utf-8";  //"application/jspn; charset=utf-8"; <-- this is correct, but causes Chrome to d/l the file.
            response.Write(json);
            response.End();
        }

        public static void JsonResponse(HttpResponse response, bool status) {
            var success = status ? "success" : "failed";
            var json = JsonConvert.SerializeObject(new {status = success});

            response.Clear();
            response.ContentType = "text/json; charset=utf-8";  
            response.Write(json);
            response.End();
        }

    }
}