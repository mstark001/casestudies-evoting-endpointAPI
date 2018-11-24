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
    public partial class LoginView : BaseView
    {
        private ILoginService _loginService;
        private ITranslationServerService _translationServerService;

        private string _postCode;
        private string _votingCode;

        #region View Setup and Teardown functions

        public LoginView(IDependencyService dependencyService) : base (dependencyService)
        {
            _loginService = dependencyService.Get<ILoginService>();
            _translationServerService = dependencyService.Get<ITranslationServerService>();

            //Matt: Should not be needed when not using WinForms
            InitializeComponent();
        }


        public override void Setup()
        {
            SetVotingCode("");
            SetPostCode("");
        }

        public override void Teardown()
        {
            SetVotingCode("");
            SetPostCode("");
        }

        #endregion


        public void SetPostCode(string postcode)
        {
            _postCode = postcode;
        }

        public void SetVotingCode(string votingCode)
        {
            _votingCode = votingCode;
        }

        public void Login()
        {
            try
            {
                if (!ValidPostCode(_postCode) || !ValidVotingCode(_votingCode))
                    throw new ArgumentException();

                if (!_loginService.Login(_postCode, _votingCode))
                    throw new NotAuthenticatedException();

                //Login Success - proceed to voting page
                App.NavigateToView(ViewType.VotingView);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Login Failed - Exception: {ex}");
                //Show on UI why the login failed (IE Servers down or incorrect password, or frontend validation failed, etc!)
            }

        }

        public void Register()
        {
            App.NavigateToView(ViewType.RegisterView);
        }


        #region Private Helper Functions

        private bool ValidPostCode(string postcode)
        {
            //Front end postcode validation
            return true;
        }

        private bool ValidVotingCode(string votingCode)
        {
            //Front end voting code validation
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
