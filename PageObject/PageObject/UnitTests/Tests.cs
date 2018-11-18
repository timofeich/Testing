using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using PageObject.PageObject;

namespace PageObject
{
    [TestFixture]
    public class Tests
    {
        [TestCase]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            ChoosingCity enter = new ChoosingCity(driver);
            HomePage homePage = new HomePage(driver);
            homePage.goToPage();

            enter.InputDepartureCity("RIX");
            enter.EnterCity();
            enter.EnterArrivalCity("RIX");

            Assert.AreEqual(driver.FindElement(By.ClassName("dropdown-item-empty")).Text, "Unfortunately, we do not fly to/from RIX");
            driver.Quit();
        }
    }
}
