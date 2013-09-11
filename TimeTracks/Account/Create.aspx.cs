using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TimeTracks.Data;

namespace TimeTracks.Account
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Don't re-populate controls on post backs.
            if (!Page.IsPostBack)
            {
                PopulateControls();
            }
        }

        private void PopulateControls()
        {
            // Populate the day dropdown control.
            Sprocs.GetDaysOfWeek().ForEach(day => WeekStartDropDown.Items.Add(day));
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Very basic validation:
            // Check that the passwords match, make sure we have at least an account name.
            if (PasswordTextBox1.Text != PasswordTextBox2.Text || String.IsNullOrWhiteSpace(AccountNameTextBox.Text)) return;

            //TODO
            // Add validation of fields.
            // Create a phone number and email utils validator.
            // Add Phone number creation area.

            // Create items in following order: user, address, location, company, account.
            var user = new User();
            user.Active = true; //first user must be active.
            user.Email = EmailTextBox.Text;
            user.FirstName = FirstNameTextBox.Text;
            user.LastName = LastNameTextBox.Text;
            user.Role = RoleTypes.Admin; //first user can ONLY be an admin.
            user.UserName = UserNameTextBox.Text;


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

            // Create location.
            var location = new Location();
            location.Adderess = adderess;
            location.Name = String.IsNullOrWhiteSpace(LocationNameTextBox.Text) ?
                AccountNameTextBox.Text : LocationNameTextBox.Text;

            // Create company.
            var company = new Company();
            company.Name = String.IsNullOrWhiteSpace(CompanyNameTextBox.Text) ? 
                AccountNameTextBox.Text : CompanyNameTextBox.Text;
            company.Adderess = adderess;
            company.Locations.Add(location);

            // Create account.
            var account = new TimeTracks.Data.Account();
            account.Companies.Add(company);
            account.Users.Add(user);
            account.Name = AccountNameTextBox.Text;
            account.WeekStart = Sprocs.GetDayOfWeek(WeekStartDropDown.SelectedValue);

            // Create the default account.
            Sprocs.CreateAccount(account, user, PasswordTextBox1.Text);

            Response.Redirect("/");
        }
    }
}