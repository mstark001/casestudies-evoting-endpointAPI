using System;
using System.Collections.Generic;
using eVoting.Interfaces;

namespace eVoting.Services
{
    public class AccessibleValueService : IAccessibleValueService
    {
        private ITranslationServerService _translationServerService;

        ////
        //Shared across the different Views
        private bool _accessibility = false;
        private double _zoomFactor = 1;
        private string _selectedLanguageCode = "en";
        private List<string> _availableLangaugeCodes = new List<string>();
        ////

        public AccessibleValueService(ITranslationServerService translationServerService)
        {
            _translationServerService = translationServerService;
        }

        //Getters
        public bool GetAccessibility()
        {
            return _accessibility;
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
