using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace WebDriver
{
    [TestFixture]
    public class Tests
    {
        //Проверка правильности поиска рейсов
        [TestCase]
        public void Test1()
        {
            DateTime date = DateTime.Now;
            string todayDate = date.ToString("dd.MM.yyyy");
            string tommorowDate = date.AddDays(2).ToString("dd.MM.yyyy");

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.airbaltic.com/en-BY/index");

            driver.FindElement(By.XPath("//input[@placeholder='From']")).SendKeys("MSQ");
            driver.FindElement(By.XPath("//div[@class ='airport']")).Click();

            driver.FindElement(By.XPath("//input[@placeholder='To']")).SendKeys("RIX");
            driver.FindElement(By.XPath("//div[@class ='airport']")).Click();

            driver.FindElement(By.XPath("//input[@name='flt_leaving_on']")).SendKeys(todayDate);
            driver.FindElement(By.XPath("//input[@name='flt_returning_on']")).SendKeys(tommorowDate);
            driver.FindElement(By.XPath("//div[@class='background-overlay-light']")).Click();
            driver.FindElement(By.XPath("//div[@class='btn btn-blue btn-search']")).Click();

            Assert.AreEqual(driver.FindElement(By.ClassName("airport-name")).Text, "Minsk");

            driver.Quit();
        }
    }
}

