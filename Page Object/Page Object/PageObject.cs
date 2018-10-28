using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Page_Object
{
    public class Enter_city
    {
        private IWebDriver driver;

        By d_city = By.XPath("//input[@placeholder='From']");
        By a_city = By.XPath("//input[@placeholder='To']");
        By enter_result = By.XPath("//div[@class ='airport']");

        public Enter_city(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Enter_dcity(string city)
        {
            driver.FindElement(d_city).Clear();
            driver.FindElement(d_city).SendKeys(city);
        }

        public void Enter_acity(string city)
        {
            driver.FindElement(a_city).Clear();
            driver.FindElement(a_city).SendKeys(city);
        }

        public void Enter_result_click()
        {
            driver.FindElement(enter_result).Click();
        }
    }

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
