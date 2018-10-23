using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NUnit.Framework;
using RaceReg.Model;

namespace Tests
{

    [TestFixture]
    public class DatabaseTests
    {
        private ObservableCollection<Affiliation> Affiliations;

        [Test]
        public void TestMethod1()
        {
            IRaceRegDB testDB = new TestDatabase();

            Affiliations = new ObservableCollection<Affiliation>(testDB.RefreshAffiliations().Result);

            string result = "";

            for(int i = 0; i < Affiliations.Count; i++)
            {
                result += Affiliations[i].Abbreviation + "\n";
            }

            Assert.AreEqual("abc\nabc\nabc\nabc\nabc\nabc\n", result);
        }
    }
}
