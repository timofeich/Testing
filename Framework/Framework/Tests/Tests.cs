using NUnit.Framework;

namespace Framework
{
    //Choosing departure date before today's date
    [TestFixture]
    public class Tests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string errorMess = "Your selected flight has already departed.";

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [TestCase]
        public void Test1()
        {         
            steps.InputYesterdayDepartureDate("17.11.2018");
            Assert.AreEqual(errorMess, steps.ErrorMessage());
        }
    }
}

