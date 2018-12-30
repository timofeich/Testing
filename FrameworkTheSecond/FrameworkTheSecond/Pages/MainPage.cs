using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkTheSecond.Pages
{
    class MainPage
    {
        private const string BASE_URL = "https://www.airbaltic.com/en-BY/index";
        private static DateTime date = DateTime.Now;
        private string yesterdayDate = date.AddDays(-1).ToString("dd.MM.yyyy");

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='To']")]
        private IWebElement cityOfArrival;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='From']")]
        private IWebElement cityOfDeparture;

        [FindsBy(How = How.XPath, Using = "//input[@name='flt_returning_on']")]
        private IWebElement arrivalDate;

        [FindsBy(How = How.XPath, Using = "//input[@name='flt_leaving_on']")]
        private IWebElement departureDate;

        [FindsBy(How = How.XPath, Using = "//ul[@class ='form-errors']")]
        private IWebElement errorMess;

        [FindsBy(How = How.XPath, Using = "//div[@class='background-overlay-light']")]
        private IWebElement background;

        [FindsBy(How = How.XPath, Using = "//div[@class ='airport']")]
        private IWebElement enterCity;

        [FindsBy(How = How.XPath, Using = "//div[@class ='btn btn-blue']")]
        private IWebElement acceptCookie;

        [FindsBy(How = How.XPath, Using = "//div[@class ='header-nav-item pre-header-lang']")]
        private IWebElement changingLanguage;

        [FindsBy(How = How.XPath, Using = "//li[@class ='dropdown-item-empty']")]
        private IWebElement emptyCityList;

        [FindsBy(How = How.XPath, Using = "//div[text() ='One-way']")]
        private IWebElement oneWayFlight;

        [FindsBy(How = How.XPath, Using = "//a[text() ='Русский']")]
        private IWebElement choosingRussianLanguage;

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
            background.Click();
        }

        public void EnterCityOfArrivalWhithoutAccept(string arrivalCity)
        {
            cityOfArrival.Clear();
            cityOfArrival.SendKeys(arrivalCity);
        }

        public void EnterDepartureDate()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementByName('flt_leaving_on').removeAttribute('readonly',0);");
            departureDate.SendKeys(yesterdayDate);
        }

        public void EnterArrivalDate()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementByName('flt_returning_on').removeAttribute('readonly',0);");
            arrivalDate.SendKeys(yesterdayDate);
        }

        public void ChangeSiteLanguage(string languageName)
        {
            changingLanguage.Click();
            choosingRussianLanguage.Click();

        }

        public void ChoosingOneWayFlight()
        {
            oneWayFlight.Click();
        }

        public string GetErrorMes()
        {
            return errorMess.Text;
        }

        public string GetErrorCityChoosing()
        {
            return emptyCityList.Text;
        }
    }
}
