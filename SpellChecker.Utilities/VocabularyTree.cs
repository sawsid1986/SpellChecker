using SpellChecker.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace SpellChecker.Utilities
{
    public class VocabularyTree: IVocabulary
    {
        private readonly BinaryTree<string> Tree;
        public VocabularyTree()
        {
            Tree = new BinaryTree<string>();            
        }

        private void BuildTree(string text)
        {
            var matches = Regex.Matches(text.ToLower(), @"\w+[^\s]*\w+|\w");
            foreach (Match match in matches)
            {
                Tree.Insert(match.Value);
            }
        }

        public bool Search(string keyword)
        {
            return Tree.Find(keyword.ToLower());
        }

        public void BuildVocabularyUsingText(string vocabularyText)
        {
            BuildTree(vocabularyText);
        }
    }
}
