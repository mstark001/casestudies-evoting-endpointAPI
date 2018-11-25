using eVoting.Exceptions;
using eVoting.Interfaces;
using eVoting.Models;
using eVoting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eVoting
{
    public partial class RegisterView : BaseView
    {
        private ILoginService _loginService;
        private ITranslationServerService _translationServerService;

        private Country _country;
        private string _nationality;
        private DateTime _dob;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _governmentId;
        private Address _address;
     
  
        #region View Setup and Teardown functions

        public RegisterView(IDependencyService dependencyService) : base (dependencyService)
        {
            _loginService = dependencyService.Get<ILoginService>();
            _translationServerService = dependencyService.Get<ITranslationServerService>();

            //Matt: Should not be needed when not using WinForms
            InitializeComponent();
        }


        public override void Setup()
        {
            SetCountry(null);
            SetNationality(null);
            SetDateOfBirth(DateTime.MinValue);
            SetFirstName(null);
            SetMiddleName(null);
            SetLastName(null);
            SetGovernmentId(null);
            SetAddress(null);
        }

        public override void Teardown()
        {
            SetCountry(null);
            SetNationality(null);
            SetDateOfBirth(DateTime.MinValue);
            SetFirstName(null);
            SetMiddleName(null);
            SetLastName(null);
            SetGovernmentId(null);
            SetAddress(null);
        }

        #endregion


        public void SetCountry(Country country)
        {
            _country = country;
        }

        public void SetNationality(string nationality)
        {
            _nationality = nationality;
        }

        public void SetDateOfBirth(DateTime date)
        {
            _dob = date;
        }

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }

        public void SetMiddleName(string middleName)
        {
            _middleName = middleName;
        }

        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }

        public void SetGovernmentId(string governmentId)
        {
            _governmentId = governmentId;
        }

        public void SetAddress(Address address)
        {
            _address = address;
        }

        public void Register()
        {
            if (!ValidForm())
                throw new ArgumentException();  //Display on page somewhere


            var user = new RegisterUser();
            user.SetAddress(_address);
            user.SetCountry(_country);
            user.SetDateOfBirth(_dob);
            user.SetFirstName(_firstName);
            user.SetGovernmentId(_governmentId);
            user.SetLastName(_lastName);
            user.SetMiddleName(_middleName);
            user.SetNationality(_nationality);

            if (!_loginService.RegisterNewUser(user))
                throw new ArgumentException(); //Display on page somewhere

            //Register success - navigate back to home
            App.NavigateToView(ViewType.LoginView);
        }



        #region Private Helper Functions

        private bool ValidForm()
        {
            //Front end validation of the form entries
            return true;
        }

        protected override void TranslatePage()
        {
            //use _selectedLanguageCode to translate the page using _translationService
            var translatedText = _translationServerService.TranslatePhrase("Some webpage text", base.GetSelectedLanguageCode());
            //set translatedText somewhere in the UI
        }

        protected override void Redraw()
        {
            //Redrawe the page here, account for font size, the current variables for the text, and any accessibility functions
        }

        #endregion


    }
}
