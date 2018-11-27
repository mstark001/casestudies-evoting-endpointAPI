using System;
using System.Collections.Generic;
using System.Windows.Forms;
using eVoting.Interfaces;

namespace eVoting.Models
{
    public abstract class BaseView : Form
    {
        private ITranslationServerService _translationServerService;
        private IValueStoreService _accessibleValueService;



        public abstract void Setup();
        public abstract void Teardown();

        protected abstract void TranslatePage();
        protected abstract void Redraw();

        public BaseView(IDependencyService dependencyService)
        {
            _translationServerService = dependencyService.Get<ITranslationServerService>();
            _accessibleValueService = dependencyService.Get<IValueStoreService>();
        }

        public virtual void SetAccesibilityMode(bool accessibility)
        {
            _accessibleValueService.SetAccessibility(accessibility);
            Redraw();
        }

        public virtual void SetZoomFactor(double zoomFactor)
        {
            _accessibleValueService.SetZoomFactor(zoomFactor);
            Redraw();
        }

        public virtual void SetSelectedLangaugeCode(string languageCode)
        {
            _accessibleValueService.SetSelectedLangaugeCode(languageCode);
            TranslatePage();
            Redraw();
        }



        //Getters
        public ITranslationServerService GetTranslationService()
        {
            return _translationServerService;
        }

        public bool GetAccesibilityMode()
        {
            return _accessibleValueService.GetAccessibility();
        }

        public double GetZoomFactor()
        {
            return _accessibleValueService.GetZoomFactor();
        }

        public string GetSelectedLanguageCode()
        {
            return _accessibleValueService.GetSelectedLangaugeCode();
        }

        public List<string> GetAvailableLangaugeCodes()
        {
            return _accessibleValueService.GetAvailableLanguageCodes();
        }
        
    }
}
