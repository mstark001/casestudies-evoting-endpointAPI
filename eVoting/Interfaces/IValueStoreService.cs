using eVoting.Models;
using System;
using System.Collections.Generic;

namespace eVoting.Interfaces
{
    public interface IValueStoreService
    {
        bool GetAccessibility();
        double GetZoomFactor();
        string GetSelectedLangaugeCode();
        List<string> GetAvailableLanguageCodes();
        void SetAccessibility(bool accessibility);
        void SetZoomFactor(double zoomFactor);
        void SetSelectedLangaugeCode(string languageCode);
        void SetAvailableLanguageCodes(List<string> availableLangaugeCodes);
        Election GetSelectedElection();
        bool GetLoggedIn();
        void SetLoggedIn(bool value);
        void SetSelectedElection(Election election);
        string GetVotingCode();
        void SetVotingCode(string votingCode);
    }
}
