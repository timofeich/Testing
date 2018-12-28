using NUnit.Framework;
using OpenQA.Selenium;

namespace Framework
{
    //Choosing departure date before today's date
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver;
        private const string errorMess = "Please select the departure date.";

        [SetUp]
        public void Init()
        {
            driver= Driver.DriverInstance.GetInstance();
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        [Test]
        public void InputYesterdayDepartureDate()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.EnterCityOfDeparture("RIX");
            mainPage.EnterCityOfArrival("MSQ");
            mainPage.EnterDepartureDate();
            mainPage.SearchTicket();
            Assert.AreEqual(errorMess, mainPage.GetErrorMes());
        }
    }
}

