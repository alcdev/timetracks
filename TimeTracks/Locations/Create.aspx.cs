using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using TimeTracks.Data;
using TimeTracks.Core;

namespace TimeTracks.Locations
{
    public partial class Create : System.Web.UI.Page
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
        }

        private void PopulateControls()
        {
            // Populate dropdown controls.
            Sprocs.GetCompanies(CurrentSession.AccountId).ForEach(company => 
                CompanyDropDown.Items.Add(new ListItem(company.Name, company.Id.ToString())));
        }

        private void Forbidden()
        {

            // if we get this far, nothing valid was passed and no one is logged in, 404.  
            // TODO: create a proper 404 page.
            Response.Status = "403 Forbidden - You must sign in to access this page. ";
            Response.StatusCode = 403;

            // TODO: an error message would be nice.  Perhaps we should have a 403 re-direct.
            editLocation.Controls.Clear();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Nothing is validated.

            // Silly hack until we create a proper numeric-only textbox.
            int zipCode = 0, companyId = 0;
            Int32.TryParse(ZipCodeTextBox.Text, out zipCode);
            Int32.TryParse(CompanyDropDown.SelectedValue, out companyId);

            // Create address.
            var adderess = new Adderess();
            adderess.City = CityTextBox.Text;
            adderess.Country = CountryTextBox.Text;
            adderess.State = StateTextBox.Text;
            adderess.StreetAdderess = StreetAdderessTextBox.Text;
            adderess.Suite = SuiteTextBox.Text;
            adderess.ZipCode = zipCode;

            // Create location.
            var location = new Location();
            location.Adderess = adderess;
            location.Name = LocationNameTextBox.Text;
            location.Company = Sprocs.GetCompany(companyId);

            Sprocs.CreateLocation(location);

            Response.Redirect("/");
        }
    }
}