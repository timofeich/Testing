using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Globalization;

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
            string today_date = date.ToString("dd.MM.yyyy");
            string tommorow_date = date.AddDays(2).ToString("dd.MM.yyyy");
            
            IWebDriver driver = new ChromeDriver();            
            driver.Navigate().GoToUrl("https://www.airbaltic.com/en-BY/index");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            
            //enter depature city
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='From']")));
            driver.FindElement(By.XPath("//input[@placeholder='From']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='From']")).SendKeys("MSQ");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class ='airport']")));
            driver.FindElement(By.XPath("//div[@class ='airport']")).Click();

            //enter city of arrival
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='To']")));
            driver.FindElement(By.XPath("//input[@placeholder='To']")).SendKeys("RIX");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class ='airport']")));
            driver.FindElement(By.XPath("//div[@class ='airport']")).Click();

            //enter current date and current date + 2
            driver.FindElement(By.XPath("//input[@name='flt_leaving_on']")).SendKeys(today_date);
            driver.FindElement(By.XPath("//input[@name='flt_returning_on']")).SendKeys(tommorow_date);

            //click find button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='background-overlay-light']")));
            driver.FindElement(By.XPath("//div[@class='background-overlay-light']")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@type='submit']")));
            driver.FindElement(By.XPath("//div[@class='btn btn-blue btn-search']")).Click();

            Assert.AreEqual(driver.FindElement(By.ClassName("airport-name")).Text, "Minsk");

            driver.Close();
            driver.Quit();
         
        }
    }
}
