using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Page_Object
{
    [TestClass]
    public class UnitTest1
    {

        // Выбор одного города в качестве места отправления и прибытия
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            Enter_city enter = new Enter_city(driver);
            HomePage homePage = new HomePage(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            
            homePage.goToPage();

            enter.Enter_dcity("RIX");
            enter.Enter_result_click();

            enter.Enter_acity("RIX");

            Assert.AreEqual(driver.FindElement(By.ClassName("dropdown-item-empty")).Text,"Unfortunately, we do not fly to/from RIX");

            driver.Close();
            driver.Quit();

        }
    }
}
