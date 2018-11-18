using OpenQA.Selenium;

namespace Framework.Steps
{
    class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void InputYesterdayDepartureDate()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.EnterCityOfDeparture("RIX");         
            mainPage.EnterCityOfArrival("MSQ");
            mainPage.EnterDepartureDate();
            mainPage.BackgroundClicked();
        }

        public string ErrorMessage()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.GetErrorMes();
        }
    }
}
