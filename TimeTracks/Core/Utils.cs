using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

using TimeTracks.Data;

namespace TimeTracks.Core
{
    public static class Utils
    {
        public static string NON_DATA_ROW
        {
            get { return "$NULLDATA$"; }
        }

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

        public static void LinkDataRow(GridViewRowEventArgs gridView, int cellNumber, string url)
        {
            if (gridView.Row.RowType == DataControlRowType.DataRow &&
                gridView.Row.Cells[cellNumber].Text !=
                NON_DATA_ROW)
            {
                HyperLink hl = new HyperLink();
                hl.NavigateUrl = string.Format(url, gridView.Row.Cells[cellNumber].Text);
                hl.Text = gridView.Row.Cells[cellNumber].Text;

                gridView.Row.Cells[cellNumber].Controls.Add(hl);
            }

            if (gridView.Row.Cells[cellNumber].Text == NON_DATA_ROW)
            {
                gridView.Row.Cells[cellNumber].Text = "";
            }
        }

        public static string FormatTimeStamp(DateTime timeStamp)
        {
            return string.Format("{0:ddd, hh:mm tt (M/d/yyyy)}", timeStamp);
        }

    }
}