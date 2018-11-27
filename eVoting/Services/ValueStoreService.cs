using System;
using System.Collections.Generic;
using eVoting.Interfaces;
using eVoting.Models;

namespace eVoting.Services
{
    public class ValueStoreService : IValueStoreService
    {
        private ITranslationServerService _translationServerService;

        ////
        //Shared across the different Views
        private bool _accessibility = false;
        private double _zoomFactor = 1;
        private string _selectedLanguageCode = "en";
        private List<string> _availableLangaugeCodes = new List<string>();

        private Election _selectedElection;
        private bool _loggedIn;
        private string _votingCode;
        ////

        public ValueStoreService(ITranslationServerService translationServerService)
        {
            _translationServerService = translationServerService;
        }

        //Getters
        public bool GetAccessibility()
        {
            return _accessibility;
        }

        public string GetVotingCode()
        {
            return _votingCode;
        }

        public bool GetLoggedIn()
        {
            return _loggedIn;
        }

        public Election GetSelectedElection()
        {
            return _selectedElection;
        }

        public double GetZoomFactor()
        {
            return _zoomFactor;
        }

        public string GetSelectedLangaugeCode()
        {
            return _selectedLanguageCode;
        }

        public List<string> GetAvailableLanguageCodes()
        {
            if (_availableLangaugeCodes?.Count == 0)
            {
                var langauges = _translationServerService.GetSupportedLanguageCodes();
                _availableLangaugeCodes.AddRange(langauges);
            }

            return _availableLangaugeCodes;
        }


        //Setters
        public void SetAccessibility(bool accessibility)
        {
            _accessibility = accessibility;
        }

        public void SetVotingCode(string votingCode)
        {
            _votingCode = votingCode;
        }

        public void SetLoggedIn(bool value)
        {
            _loggedIn = value;
        }

        public void SetSelectedElection(Election election)
        {
            _selectedElection = election;
        }

        public void SetZoomFactor(double zoomFactor)
        {
            _zoomFactor = zoomFactor;
        }

        public void SetSelectedLangaugeCode(string languageCode)
        {
            _selectedLanguageCode = languageCode;
        }

        public void SetAvailableLanguageCodes(List<string> availableLangaugeCodes)
        {
            _availableLangaugeCodes = availableLangaugeCodes;
        }
    }
}
