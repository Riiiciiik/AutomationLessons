using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakroTest
{
    public class Test
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Browser.CreateDriver();
            Browser.Navigate();
        }

        [Test]
        public void Assert()
        {
            var page = new HomePageMakro();
            page.OpeningHoursDisplayed()
                .StoreLinkAssert();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Browser.Driver.Quit();
        }
        
    }
}
