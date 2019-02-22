using SpellChecker.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker.Repositories
{
    public class SpellCheckRespository : ISpellCheckerRepository
    {
        private readonly IVocabulary _vocabulary;

        public SpellCheckRespository(IVocabulary vocabulary, ITextReader reader)
        {
            _vocabulary = vocabulary;
            BuildVocabularyUsingText(reader);
        }

        private void BuildVocabularyUsingText(ITextReader reader)
        {
            var text = reader.ReadText();
            _vocabulary.BuildVocabularyUsingText(text);
        }

        public bool IsSpellingCorrect(string word)
        {
            return _vocabulary.Search(word);
        }
    }
}
