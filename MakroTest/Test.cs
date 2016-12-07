using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MakroTest.PageObjects;

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
        public void Search()
        {
            var page = new HomePage();
            page.SearchFor("maso", false);
        }
        [Test]
        public void AssertHoursAndStores()
        {
            var page = new HomePage();
            page.OpeningHoursDisplayed()
                .StoreLinkAssert();
        }

        [Test]
        public void AssertMenus()
        {
            var page = new HomePage();
            page.AssertNavigation();
        }

        [Test]
        public void AssertHero()
        {
            var page = new HomePage()
                .AssertHeroBanner();
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            Browser.Driver.Close();
        }
        
    }
}
