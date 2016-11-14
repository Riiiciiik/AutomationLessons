using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
        public void AssertHoursAndStores()
        {
            var page = new HomePageMakro();
            page.OpeningHoursDisplayed()
                .StoreLinkAssert();
        }

        [Test]
        public void AssertMenus()
        {
            var page = new HomePageMakro();
            page.AssertNavigation();
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            Browser.Driver.Close();
        }
        
    }
}
