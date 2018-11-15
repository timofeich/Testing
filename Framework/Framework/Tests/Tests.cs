using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Framework
{
    //Choosing departure date before today's date

    [TestFixture]
    public class Tests
    {
        
        [Test]
        public void CanChooseDepDateBeforeTodayDate()
        {
            //resharper
            //1)open site
            //2)dep city
            //3)arr city
            //4)One way
            //5)Enter yesterday date
            //6)isEqual(Your selected flight...)
            //7)Quit();
            private Steps.Steps steps = new Steps.Steps();

        [Test]
        public void OneCanLoginGithub()
        {
            steps.EnterCities(USERNAME, PASSWORD);
            Assert.AreEqual(USERNAME, steps.GetLoggedInUserName());
        }
    }
    }
}
