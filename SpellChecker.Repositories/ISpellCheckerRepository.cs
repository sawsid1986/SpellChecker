using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker.Repositories
{
    public interface ISpellCheckerRepository
    {
        bool IsSpellingCorrect(string word);
        string[] FindWordSuggestions(string word);
    }
}
