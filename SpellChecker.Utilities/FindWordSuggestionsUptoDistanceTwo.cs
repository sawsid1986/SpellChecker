using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker.Utilities
{
    public class FindWordSuggestionsUptoDistanceTwo : IFindWordSuggestion
    {
        private readonly char[] ALPHABET_ARRAY = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private readonly IVocabulary _vocabulary;

        public FindWordSuggestionsUptoDistanceTwo(IVocabulary vocabulary)
        {
            _vocabulary = vocabulary;
        }

        public string[] FindSuggestions(string word)
        {
            var distanceOneSuggestions = EditWordUptoDistanceOne(word.ToLower());
            var distanceTwoSuggestions = new List<string>();
            var finalSuggestions = new List<string>();
            foreach (var suggested in distanceOneSuggestions)
            {
                distanceTwoSuggestions.AddRange(EditWordUptoDistanceOne(suggested));

                if (_vocabulary.Search(suggested) && !finalSuggestions.Contains(suggested))
                {
                    finalSuggestions.Add(suggested);
                }
            }

            foreach (var suggested in distanceTwoSuggestions)
            {
                if (_vocabulary.Search(suggested) && !finalSuggestions.Contains(suggested))
                {
                    finalSuggestions.Add(suggested);
                }
            }


            return finalSuggestions.ToArray();
        }

        public string[] EditWordUptoDistanceOne(string word)
        {
            List<string> result = new List<string>();

            result.AddRange(AddingOneCharacter(word));

            result.AddRange(RemoveOneCharacter(word));

            result.AddRange(TransposeAdjucentCharacters(word));

            result.AddRange(SubstituteAnyCharacter(word));

            return result.ToArray();
        }

        public List<string> SubstituteAnyCharacter(string word)
        {
            List<string> result = new List<string>();
            for (var i = 0; i < word.Length; i++)
            {
                for (var j = 0; j < ALPHABET_ARRAY.Length; j++)
                {
                    result.Add(String.Join("", word.Substring(0, i), ALPHABET_ARRAY[j], word.Substring(i + 1, word.Length - i - 1)));
                }
            }
            return result;
        }

        public List<string> TransposeAdjucentCharacters(string word)
        {
            List<string> result = new List<string>();
            for (var i = 0; i < word.Length - 1; i++)
            {
                result.Add(string.Join("", word.Substring(0, i), word.Substring(i + 1, 1), word.Substring(i, 1), word.Substring(i + 2, word.Length - i - 2)));
            }
            return result;
        }

        public List<string> RemoveOneCharacter(string word)
        {
            List<string> result = new List<string>();
            for (var i = 0; i < word.Length; i++)
            {
                result.Add(string.Join("", word.Substring(0, i), word.Substring(i + 1, word.Length - i - 1)));
            }
            return result;
        }

        public List<string> AddingOneCharacter(string word)
        {
            List<string> result = new List<string>();
            for (var i = 0; i < word.Length; i++)
            {
                for (var j = 0; j < ALPHABET_ARRAY.Length; j++)
                {
                    result.Add(String.Join("", word.Substring(0, i), ALPHABET_ARRAY[j], word.Substring(i, word.Length - i)));
                }
            }
            return result;
        }
    }
}
