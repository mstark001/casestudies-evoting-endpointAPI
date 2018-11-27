using eVoting.Interfaces;
using eVoting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eVoting
{
    public partial class SingleTransferableView : BaseVotingView
    {
        #region View Setup and Teardown functions

        private ITranslationServerService _translationServerService;

        public SingleTransferableView(IDependencyService dependencyService) : base(dependencyService)
        {
            _translationServerService = dependencyService.Get<ITranslationServerService>();

            //Matt: Should not be needed when not using WinForms
            InitializeComponent();
        }

        #endregion

        public override void SelectParty(Party party)
        {
            var parties = base.GetPartiesSelected();
            parties.Add(party);
            base.SetPartiesSelected(parties);
        }

        public override void DeselectParty(Party party)
        {
            var parties = base.GetPartiesSelected();
            parties.Remove(party);
            base.SetPartiesSelected(parties);
        }


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
