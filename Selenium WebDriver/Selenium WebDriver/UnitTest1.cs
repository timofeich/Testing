using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver
{
    [TestClass]
    public class UnitTest1
    {
        //Проверка правильности поиска рейсов
        [TestMethod]
        public void TestMethod1()
        {

            DateTime date = DateTime.Now;
            string todayDate = date.ToString("dd.MM.yyyy");
            string tommorowDate = date.AddDays(2).ToString("dd.MM.yyyy");
            
            IWebDriver driver = new ChromeDriver();            
            driver.Navigate().GoToUrl("https://www.airbaltic.com/en-BY/index");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            
            driver.FindElement(By.XPath("//input[@placeholder='From']")).SendKeys("MSQ");
            driver.FindElement(By.XPath("//div[@class ='airport']")).Click();

            driver.FindElement(By.XPath("//input[@placeholder='To']")).SendKeys("RIX");
            driver.FindElement(By.XPath("//div[@class ='airport']")).Click();

            driver.FindElement(By.XPath("//input[@name='flt_leaving_on']")).SendKeys(todayDate);
            driver.FindElement(By.XPath("//input[@name='flt_returning_on']")).SendKeys(tommorowDate);
            
            driver.FindElement(By.XPath("//div[@class='background-overlay-light']")).Click();
            driver.FindElement(By.XPath("//div[@class='btn btn-blue btn-search']")).Click();

            Assert.AreEqual(driver.FindElement(By.ClassName("item-to info-tooltip")).Text, "MSQ");
            //описание теста в ассерте оставить
            //поменять проверку
            //nUnit использовать
            driver.Quit();
         
        }
    }
}
