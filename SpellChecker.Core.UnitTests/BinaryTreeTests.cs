using NUnit.Framework;
using System.Collections;

namespace SpellChecker.Core.UnitTests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [TestCaseSource(typeof(BinarySearchTestData), "TestCases")]
        public bool TestSearch(string[] array, string serachItem)
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            tree.InsertFromArray(array);
            return tree.Find(serachItem);
        }


        public class BinarySearchTestData
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(new string[] { "Apple" }, "Lemon").Returns(false);
                    yield return new TestCaseData(new string[0], "Lemon").Returns(false);
                    yield return new TestCaseData(new string[] { "Apple" }, "Apple").Returns(true);
                    yield return new TestCaseData(new string[] { "Apple", "Lemon", "Orange" }, "Orange").Returns(true);
                    yield return new TestCaseData(new string[] { "Apple", "Lemon", "Orange" }, "Appricot").Returns(false);
                }
            }
        }
    }
}