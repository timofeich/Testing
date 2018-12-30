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
        public void InputYesterdayDepartureDate()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.EnterCityOfDeparture("RIX");
            mainPage.EnterCityOfArrival("MSQ");
            mainPage.EnterDepartureDate();
            Assert.AreEqual("Your selected flight has already departed", mainPage.GetErrorMes());
        }
    }
}
