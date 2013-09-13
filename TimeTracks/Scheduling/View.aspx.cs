using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using TimeTracks.Data;
using TimeTracks.Core;

namespace TimeTracks.Scheduling
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CurrentSession.Active || !(CurrentSession.UserRole == RoleTypes.Admin || CurrentSession.UserRole == RoleTypes.Manager))
            {
                Forbidden();
                return;
            }

            if (!Page.IsPostBack)
            {
                PopulateControls();
            }

            // See if a userid/account was passed.
            var aid = Request["aid"];  // account
            var uid = Request["uid"];  // username

            if (uid != null && aid != null)
            {
                int userId, accountId;
                if (!Int32.TryParse(uid, out userId) || !Int32.TryParse(aid, out accountId)) return;

                // See if it's our account.
                if (accountId != CurrentSession.AccountId)
                {
                    Forbidden();
                    return;
                }

                // Looks like we are good to try and show the locations.
                // We don't really need the account, that was just for the check above.
                ShowLocations(userId);
            }
        }


        // This entire method is a proof-of-concept.  It will not work like this.
        private void ShowLocations(int userId)
        {
            var devices = Sprocs.GetUserDevices(userId);

            foreach (var device in devices) {
                
                var gridView = new GridView();
                var dataTable = new DataTable();
                gridView.RowDataBound += gridView_RowDataBound;
                dataTable.Columns.Add(new DataColumn("TimeStamp", typeof(string)));
                dataTable.Columns.Add(new DataColumn("Longitude", typeof(string)));
                dataTable.Columns.Add(new DataColumn("Latitude", typeof(string)));
                
                foreach (var logloc in device.LocationLogs) {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["TimeStamp"] = Utils.FormatTimeStamp(logloc.TimeStamp);
                    dataRow["Longitude"] = logloc.Longitude.ToString();
                    dataRow["Latitude"] = logloc.Latitude.ToString();

                    //Utils.LinkDataRow()

                    dataTable.Rows.Add(dataRow);
                }
                gridView.DataSource = dataTable;
                gridView.DataBind();

                if (devices.Count > 1) {
                    var devicename = new Label();
                    devicename.Text = device.Name;
                    viewScheduling.Controls.Add(devicename);
                }
                viewScheduling.Controls.Add(gridView);

            }
        }

        void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow &&
                e.Row.Cells[0].Text != Utils.NON_DATA_ROW)
            {

                HyperLink hl = new HyperLink();
                hl.NavigateUrl = String.Format("show?lat={0}&lng={1}",
                    e.Row.Cells[2].Text, e.Row.Cells[1].Text);

                hl.Text = e.Row.Cells[0].Text;
                e.Row.Cells[0].Controls.Add(hl);


                if (e.Row.Cells[0].Text == Utils.NON_DATA_ROW)
                {
                    e.Row.Cells[0].Text = "";
                }
            }
        }

        private void Forbidden()
        {

            // if we get this far, nothing valid was passed and no one is logged in, 404.  
            // TODO: create a proper 404 page.
            Response.Status = "403 Forbidden - You must sign in to access this page.";
            Response.StatusCode = 403;

            // TODO: an error message would be nice.  Perhaps we should have a 403 re-direct.
            viewScheduling.Controls.Clear();
        }

        private void PopulateControls()
        {
            // Add context menu items to master.
            var linkList = new List<KeyValuePair<string, string>>();
            var master = Master as SiteMaster;

            foreach (var user in Sprocs.GetUsers(CurrentSession.AccountId))
            {
                /* TODO: pretty URLs.
                linkList.Add(new KeyValuePair<string, string>(
                    user.UserName,  String.Format(
                    "/scheduling/view/{0}/{1}", CurrentSession.AccountId, user.Id)));
                 */
                linkList.Add(new KeyValuePair<string, string>(
                    user.UserName, String.Format(
                    "/scheduling/view?aid={0}&uid={1}", CurrentSession.AccountId, user.Id)));
            }

            master.UpdateContextMenu(linkList);
        }
    }
}