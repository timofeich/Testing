using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Framework.Pages
{
    public class MainPage
    {       
        private const string BASE_URL = "https://www.airbaltic.com/en-BY/index";
        private static DateTime date = DateTime.Now;
        private string yesterdayDate = date.AddDays(-1).ToString("dd.MM.yyyy");

        [FindsBy(How = How.XPath, Using = "//div[@class='btn btn-blue btn-search']")]
        private IWebElement buttonSearchTicket;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='To']")]
        private IWebElement cityOfArrival;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='From']")]
        private IWebElement cityOfDeparture;

        [FindsBy(How = How.XPath, Using = "//input[@name='flt_leaving_on']")]
        private IWebElement departureDate;

        [FindsBy(How = How.XPath, Using = "//ul[@class ='form-errors']")]
        private IWebElement errorMess;

        [FindsBy(How = How.XPath, Using = "//div[@class='background-overlay-light']")]
        private IWebElement background;

        [FindsBy(How = How.XPath, Using = "//div[@class ='airport']")]
        private IWebElement enterCity;



        private IWebDriver driver;


        public MainPage(IWebDriver driver)
        { 
            this.driver = driver;
        
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
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

        public void SearchTicket()
        {   

            buttonSearchTicket.Click();
        }


        public void EnterDepartureDate()
        {
            departureDate.SendKeys(yesterdayDate);
        }

        public string GetErrorMes()
        {
            return errorMess.Text;
        }

    }
}
