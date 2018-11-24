using System;
using System.Collections.Generic;

namespace eVoting.Interfaces
{
    public interface ITranslationServerService
    {
        List<string> GetSupportedLanguageCodes();
        string TranslatePhrase(string englishPhrase, string langaugeCode);
    }
}
