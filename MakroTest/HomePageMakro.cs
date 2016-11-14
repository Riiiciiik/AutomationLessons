using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakroTest
{
    class HomePageMakro
    {

        public string baseBackgroundColor = "rgba(251, 228, 0, 1)";
        public string baseColor = "rgba(25, 57, 121, 1)";

        public string hoverBackgroundColor = "rgba(255, 255, 255, 1)";
        public string hoverColor = "rgba(25, 57, 121, 1)";


        public HomePageMakro()
        {
            PageFactory.InitElements(Browser.Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".opening .text")]
        public IWebElement txtOpeningHours { get; set; }

        [FindsBy(How = How.ClassName, Using = "opening")]
        public IWebElement liOpening { get; set; }

        [FindsBy(How = How.Id, Using = "pageph_0_UIStoreInfo_ControlStoreDetailLink")]
        public IWebElement txtCurrentStore { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inner-scrollbar li input")]
        public IList<IWebElement> liStores { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".main-nav>ul>li")]
        public IList<IWebElement> linksMainNav { get; set; }       

        
        public HomePageMakro OpeningHoursDisplayed()
        {
            Assert.IsTrue(liOpening.Displayed);
            Assert.IsTrue(txtOpeningHours.Displayed);
            Assert.IsTrue(liOpening.Text != null);

            return this;
        }
        public HomePageMakro StoreLinkAssert()
        {
            foreach (IWebElement e  in liStores)
            {
                Assert.IsTrue(txtCurrentStore.Text != e.GetAttribute("value"));
            }


            return this;
        }

        public HomePageMakro AssertNavigation()
        {
           var evfewv = linksMainNav.Take(linksMainNav.Count - 3);
            foreach (IWebElement e in linksMainNav)
            {
                
                AssertBaseColors(e.FindElement(By.TagName("a")));
                Browser.Builder.MoveToElement(e).Perform();
                AssertHoverColors(e.FindElement(By.TagName("a")));               
            }

            return this;
        }

        
        private void AssertHoverColors(IWebElement element)
        {
            Assert.AreEqual(hoverBackgroundColor, element.GetCssValue("background-color"));
            Assert.AreEqual(hoverColor, element.GetCssValue("color"));
        }

        private void AssertBaseColors(IWebElement element)
        {
            Assert.AreEqual(baseBackgroundColor, element.GetCssValue("background-color"));
            Assert.AreEqual(baseColor, element.GetCssValue("color"));

        }
    }
}
