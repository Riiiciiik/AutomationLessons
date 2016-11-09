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



        public HomePageMakro OpeningHoursDisplayed()
        {
            System.Threading.Thread.Sleep(1000);
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
    }
}
