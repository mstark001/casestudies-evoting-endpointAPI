using System;
using System.Collections.Generic;
using eVoting.Interfaces;

namespace eVoting.Services
{
    public class TranslationServerService : ITranslationServerService
    {
        private const string BASESERVERADDRESS = "www.someaddress.com";
        public TranslationServerService()
        {
        }

        public List<string> GetSupportedLanguageCodes()
        {
            //coomunicate with server to get supported languages
            return new List<string>();
        }

        public string TranslatePhrase(string englishPhrase, string langaugeCode)
        {
            //Communicate with server to translate a phrase into sellected langauges
            return "";
        }

        #region Private Helper Functions

        private void Connect()
        {
            //connect and authenitcate here
        }

        #endregion

    }
}
