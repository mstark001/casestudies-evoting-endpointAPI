using System;
using System.Collections.Generic;

namespace eVoting.Interfaces
{
    public interface IAccessibleValueService
    {
        bool GetAccessibility();
        double GetZoomFactor();
        string GetSelectedLangaugeCode();
        List<string> GetAvailableLanguageCodes();
        void SetAccessibility(bool accessibility);
        void SetZoomFactor(double zoomFactor);
        void SetSelectedLangaugeCode(string languageCode);
        void SetAvailableLanguageCodes(List<string> availableLangaugeCodes);

    }
}
