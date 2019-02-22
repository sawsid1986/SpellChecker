using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker.Utilities
{
    public interface IFindWordSuggestion
    {
        string[] FindSuggestions(string word);
    }
}
