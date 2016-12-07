using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace MakroTest.PageObjects
{
   partial class HomePage : BasePage
    {
        
        public HomePage()
        {
            PageFactory.InitElements(Browser.Driver, this);
        }        

        [FindsBy(How = How.CssSelector, Using = "#hero-pager .micon")]
        public IList<IWebElement> bulletHeroBanner { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#hero-banner img")]
        public IList<IWebElement> imgHeroBanners { get; set; }

        public HomePage OpeningHoursDisplayed()
        {
            Assert.IsTrue(liOpening.Displayed);
            Assert.IsTrue(txtOpeningHours.Displayed);
            Assert.IsTrue(liOpening.Text != null);

            return this;
        }

        public HomePage StoreLinkAssert()
        {
            foreach (IWebElement e in liStores)
            {
                Assert.IsTrue(txtCurrentStore.Text != e.GetAttribute("value"));
            }


            return this;
        }

        public HomePage AssertHeroBanner()
        {
            var srcAttributes = imgHeroBanners.Select(r => r.GetAttribute("src")).ToList();
            Assert.AreEqual(srcAttributes.Count(), srcAttributes.Distinct().ToList().Count());
            return this;
        }

        public HomePage AssertBulletList()
        {
            foreach (IWebElement e in bulletHeroBanner)
            {

            }
            return this;
        }
    }
}
