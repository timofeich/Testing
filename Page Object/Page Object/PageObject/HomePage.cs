using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Page_Object.PageObject
{
    public class HomePage
    {

        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://www.airbaltic.com/en-BY/index");
        }

    }
}
