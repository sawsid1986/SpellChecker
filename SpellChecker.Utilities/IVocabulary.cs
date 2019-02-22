using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker.Utilities
{
    public interface IVocabulary
    {
        void BuildVocabularyUsingText(string text);
        bool Search(string keyword); 
    }
}
