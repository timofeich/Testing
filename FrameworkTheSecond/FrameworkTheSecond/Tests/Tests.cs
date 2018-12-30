using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FrameworkTheSecond.Tests
{
    class Tests
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        [Test]
        public void InputSameCityOfDepartureAndArrival()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.EnterCityOfDeparture("RIX");
            mainPage.EnterCityOfArrivalWhithoutAccept("RIX");
            Assert.AreEqual(mainPage.GetErrorCityChoosing(),"Unfortunately, we do not fly to/from RIX");
        }

        [Test]
        public void InputYesterdayDepartureDate()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.EnterCityOfDeparture("RIX");
            mainPage.EnterCityOfArrival("MSQ");
            mainPage.EnterDepartureDate();
           // Assert.AreEqual(mainPage.GetErrorMes(), "Your selected flight has already departed.");
        }

        [Test]
        public void ChooseRussianLanguage()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.ChangeSiteLanguage();
            Assert.AreEqual(mainPage.GetSiteLanguage(), "Планируйте и бронируйте");
        }

        [Test]
        public void SearchTicketWithoutInputingDate()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.EnterCityOfDeparture("RIX");
            mainPage.EnterCityOfArrival("MSQ");
            mainPage.ChoosingOneWayFlight();
            mainPage.SearchTicket();
            Assert.AreEqual(mainPage.GetErrorMes(), "Please select the departure date.");
        }
    }
}
