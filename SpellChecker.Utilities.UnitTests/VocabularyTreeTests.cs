using NUnit.Framework;
using System.Collections;

namespace SpellChecker.Utilities.UnitTests
{
    public class VocabularyTreeTests
    {
        VocabularyTree tree;

        [SetUp]
        public void Setup()
        {
            var text = @"The Character of the New King.=--The third George rudely broke the
German tradition of his family.He resented the imputation that he was a
foreigner and on all occasions made a display of his British sympathies.
To the draft of his first speech to Parliament, he added the popular
phrase: Born and educated in this country, I glory in the name of
Briton. Macaulay, the English historian, certainly of no liking for
high royal prerogative, said of George: The young king was a born
Englishman.All his tastes and habits, good and bad, were English. No
portion of his subjects had anything to reproach him with....His age,
his appearance, and all that was known of his character conciliated
public favor.He was in the bloom of youth; his person and address were
pleasing; scandal imputed to him no vice; and flattery might without
glaring absurdity ascribe to him many princely virtues.
Nevertheless George III had been spoiled by his mother, his tutors, and
his courtiers.Under their influence he developed high and mighty
notions about the sacredness of royal authority and his duty to check
the pretensions of Parliament and the ministers dependent upon it. His
mother had dinned into his ears the slogan: George, be king! Lord
Bute, his teacher and adviser, had told him that his honor required him
to take an active part in the shaping of public policy and the making of
laws.Thus educated, he surrounded himself with courtiers who encouraged
him in the determination to rule as well as reign, to subdue all
parties, and to place himself at the head of the nation and empire";
            tree = new VocabularyTree();
            tree.BuildVocabularyUsingText(text);
        }

        [TestCaseSource(typeof(VocabularyTreeTestData), "TestCases")]
        public bool TestSearch(string serachItem)
        {
            return tree.Search(serachItem);
        }


        public class VocabularyTreeTestData
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData("public").Returns(true);
                    yield return new TestCaseData("head").Returns(true);
                    yield return new TestCaseData("rule").Returns(true);
                    yield return new TestCaseData("zyn").Returns(false);
                    yield return new TestCaseData("ministers").Returns(true);
                }
            }
        }
    }
}