using eVoting.Exceptions;
using eVoting.Interfaces;
using eVoting.Models;
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
    public partial class VoteView : BaseView
    {

        private ITranslationServerService _translationServerService;
        private IVotingServerService _votingServerService;
        private IValueStoreService _valueStoreService;
        private ILoginService _loginService;

        private List<Election> _elections;
        
        


        #region View Setup and Teardown functions

        public VoteView(IDependencyService dependencyService) : base(dependencyService)
        {
            _translationServerService = dependencyService.Get<ITranslationServerService>();
            _votingServerService = dependencyService.Get<IVotingServerService>();
            _loginService = dependencyService.Get<ILoginService>();
            _valueStoreService = dependencyService.Get<IValueStoreService>();


            //Matt: Should not be needed when not using WinForms
            InitializeComponent();
        }


        public override void Setup()
        {
            ShowAllElections();
        }

        public override void Teardown()
        {
            _elections.Clear();
        }

        public void ShowAllElections()
        {
            _elections = _votingServerService.GetCurrentElections();
            Redraw();

        }

        public void SelectElection(Election election)
        {
            ViewType type;
            switch (election.GetElectionType())
            {
                case ElectionType.FPTP:
                    type = ViewType.FirstPastThePostView;
                    break;

                case ElectionType.Preferential:
                    type = ViewType.PreferentialView;
                    break;

                case ElectionType.STV:
                    type = ViewType.SingleTransferableView;
                    break;

                default:
                    throw new ArgumentException();
            }

            _valueStoreService.SetSelectedElection(election);
            App.NavigateToView(type);
        }

       

        public void LogoutAndReturn()
        {
            try
            {
                if (!_loginService.Logout())
                    throw new NotAuthenticatedException();

                App.NavigateToView(ViewType.LoginView);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Logout Failed - Exception: {ex}");
                //Show on UI why the login failed (IE Servers down or incorrect password, or frontend validation failed, etc!)
            }
        }


        #endregion


        #region Private Helper Functions

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
