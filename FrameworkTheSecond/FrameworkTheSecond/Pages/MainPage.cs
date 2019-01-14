﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkTheSecond.Pages
{
    class MainPage
    {
        private const string BASE_URL = "https://www.airbaltic.com/en-BY/index";

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='To']")]
        private IWebElement cityOfArrival;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='From']")]
        private IWebElement cityOfDeparture;

        [FindsBy(How = How.XPath, Using = "//input[@name='flt_returning_on']")]
        private IWebElement arrivalDate;

        [FindsBy(How = How.XPath, Using = "//i[@class='calendar-marker']")]
        private IWebElement departureDate;

        [FindsBy(How = How.XPath, Using = "//ul[@class ='form-errors']")]
        private IWebElement errorMess;

        [FindsBy(How = How.XPath, Using = "//div[@class='background-overlay-light']")]
        private IWebElement background;

        [FindsBy(How = How.XPath, Using = "//li[@class ='dropdown-item']")]
        private IWebElement enterCity;

        [FindsBy(How = How.XPath, Using = "//div[@class ='btn btn-blue']")]
        private IWebElement acceptCookie;

        [FindsBy(How = How.XPath, Using = "//i[@data-v-1484333a]")]
        private IWebElement closingNewsSubscribing;

        [FindsBy(How = How.XPath, Using = "//div[@class ='header-nav-item pre-header-lang']")]
        private IWebElement changingLanguage;

        [FindsBy(How = How.XPath, Using = "//li[@class ='dropdown-item-empty']")]
        private IWebElement emptyCityList;

        [FindsBy(How = How.XPath, Using = "//span[text() ='One-way']")]
        private IWebElement oneWayFlight;

        [FindsBy(How = How.XPath, Using = "//a[text() ='Русский']")]
        private IWebElement choosingRussianLanguage;

        [FindsBy(How = How.XPath, Using = "//span[text() ='Планируйте и бронируйте']")]
        private IWebElement getSiteLanguage;

        [FindsBy(How = How.XPath, Using = "//button[text() ='Find flights & fares']")]
        private IWebElement searchingTicket;

        [FindsBy(How = How.XPath, Using = "//div[@class ='pax-selector-block']")]
        private IWebElement passengerTypes;

        [FindsBy(How = How.XPath, Using = "//span[@data-v-7e5e3b71][2]")]
        private IWebElement plusOneAdult;

        [FindsBy(How = How.XPath, Using = "//div[@data-v-6abbcb88 and @data-v-7e5e3b71][3]/span[@data-v-7e5e3b71][2]")]
        private IWebElement plusOneInfant;

        [FindsBy(How = How.XPath, Using = "//span[@data-v-6abbcb88]")]
        private IWebElement numberOfAdults;

        [FindsBy(How = How.XPath, Using = "//div[@class ='item-to info-tooltip']")]
        private IWebElement airportName;

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            acceptCookie.Click();
            closingNewsSubscribing.Click();
        }

        public void EnterCityOfDeparture(string departureCity)
        {
            cityOfDeparture.Clear();
            cityOfDeparture.SendKeys(departureCity);
            enterCity.Click();
        }

        public void EnterCityOfArrival(string arrivalCity)
        {
            cityOfArrival.Clear();
            cityOfArrival.SendKeys(arrivalCity);
            enterCity.Click();
        }

        public void EnterCityOfArrivalWhithoutAccept(string arrivalCity)
        {
            cityOfArrival.Clear();
            cityOfArrival.SendKeys(arrivalCity);
        }

        public void EnterCityOfDepartureWhithoutAccept(string departureCity)
        {
            cityOfDeparture.Clear();
            cityOfDeparture.SendKeys(departureCity);
        }

        public void EnterDepartureDate(string someDepartureDate)
        {
            departureDate.Click();
            departureDate.SendKeys(someDepartureDate);
        }

        public void EnterArrivalDate(string someArrivalDate)
        {
            cityOfArrival.Click();
            arrivalDate.SendKeys(someArrivalDate);
        }

        public void ChangeSiteLanguage()
        {
            changingLanguage.Click();
            choosingRussianLanguage.Click();
        }

        public void SearchTicket()
        {
            searchingTicket.Click();
        }

        public void ChoosingOneWayFlight()
        {
            oneWayFlight.Click();
        }

        public void ChoosingTypeOfPassender()
        {
            passengerTypes.Click();
        }

        public void InputNumberOfAdults(int numberOfAdultsPassanger)
        {
            for (int i = 1; i < numberOfAdultsPassanger; i++)
            {
                plusOneAdult.Click();
            }
        }

        public void InputNumberOfInfants(int numberOfInfantPassanger)
        {
            for (int i = 0; i < numberOfInfantPassanger; i++)
            {
                plusOneInfant.Click();
            }
        }

        public string GetAdultsNumber()
        {
            return numberOfAdults.Text;
        }

        public string GetErrorMes()
        {
            return errorMess.Text;
        }

        public string GetAiportName()
        {
            return airportName.Text;
        }

        public string GetErrorCityChoosing()
        {
            return emptyCityList.Text;
        }

        public string GetSiteLanguage()
        {
            return getSiteLanguage.Text;
        }
    }
}
