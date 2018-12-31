﻿using System;
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
        private static DateTime date = DateTime.Now;
        private string yesterdayDate = date.AddDays(-1).ToString("dd.MM.yyyy");
        private string todayDate = date.AddDays(0).ToString("dd.MM.yyyy");
        private string tomorrowDate = date.AddDays(+1).ToString("dd.MM.yyyy");

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
            mainPage.EnterDepartureDate(yesterdayDate);
            Assert.AreEqual(mainPage.GetErrorMes(), "Your selected flight has already departed.");
        }

        public void InputArrivalDateEarlierThanDeparture()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.EnterCityOfDeparture("RIX");
            mainPage.EnterCityOfArrival("MSQ");
            mainPage.EnterDepartureDate(tomorrowDate);
            mainPage.EnterArrivalDate(todayDate);
            Assert.AreEqual(mainPage.GetErrorMes(), "The date of the inbound flight cannot be earlier than the " +
            "date of the outbound flight. Please adjust your selection.");
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
            mainPage.SearchTicket();
            Assert.AreEqual(mainPage.GetErrorMes(), "Please select the departure date.");
        }



    }
}
