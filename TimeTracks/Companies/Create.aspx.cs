using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using TimeTracks.Data;
using TimeTracks.Core;

namespace TimeTracks.Companies
{
    public partial class Create : System.Web.UI.Page
    {
        //private string aspId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CurrentSession.Active || CurrentSession.UserRole != RoleTypes.Admin)
            {
                Forbidden();
                return;
            }
        }

        private void Forbidden()
        {

            // if we get this far, nothing valid was passed and no one is logged in, 404.  
            // TODO: create a proper 404 page.
            Response.Status = "403 Forbidden - You must sign in to access this page. ";
            Response.StatusCode = 403;

            // TODO: an error message would be nice.  Perhaps we should have a 403 re-direct.
            editCompany.Controls.Clear();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Silly hack until we create a proper numeric-only textbox.
            int zipCode = 0;
            Int32.TryParse(ZipCodeTextBox.Text, out zipCode);

            // Create address.
            var adderess = new Adderess();
            adderess.City = CityTextBox.Text;
            adderess.Country = CountryTextBox.Text;
            adderess.State = StateTextBox.Text;
            adderess.StreetAdderess = StreetAdderessTextBox.Text;
            adderess.Suite = SuiteTextBox.Text;
            adderess.ZipCode = zipCode;

            // Create company.
            var company = new Company();
            company.Name = CompanyNameTextBox.Text;
            company.Adderess = adderess;
            company.Account = Sprocs.GetUserAccount(CurrentSession.AspId); // it's the same account we're creating the user from.

            Sprocs.CreateCompany(company);

            Response.Redirect("/");
        }
    }
}