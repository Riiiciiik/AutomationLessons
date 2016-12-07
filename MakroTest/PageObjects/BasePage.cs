using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakroTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MakroTest.PageObjects
{
    class BasePage
    {

        public BasePage()
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

        [FindsBy(How = How.CssSelector, Using = ".search button")]
        private IWebElement btnSearch { get; set; }

        [FindsBy(How = How.Id, Using = "pageph_0_UIHeader_ControlSearchField")]
        private IWebElement txtSearch { get; set; }

        public BasePage AssertNavigation()
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
            Assert.AreEqual(Properties.hoverBackgroundColor, element.GetCssValue("background-color"));
            Assert.AreEqual(Properties.hoverColor, element.GetCssValue("color"));
        }

        private void AssertBaseColors(IWebElement element)
        {
            Assert.AreEqual(Properties.baseBackgroundColor, element.GetCssValue("background-color"));
            Assert.AreEqual(Properties.baseColor, element.GetCssValue("color"));

        }

        public SearchResultsPage SearchFor(string searchText, bool type)
        {
            txtSearch.Clear();
            txtSearch.SendKeys(searchText);

            if (type)
                btnSearch.Click();
            else
                txtSearch.SendKeys(Keys.Enter);

            return new SearchResultsPage(searchText);
        }
    }
}
