using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MakroTest.PageObjects
{
    partial class SearchResultsPage : BasePage
    {
        string searchTerm = String.Empty;

        public SearchResultsPage(string searchTerm)
        {
            PageFactory.InitElements(Browser.Driver, this);
            this.searchTerm = searchTerm;

        }

        [FindsBy(How = How.CssSelector, Using = "#serp-head span")]
        private IWebElement txtSearchResult { get; set; }

        public SearchResultsPage AssertSearchResult()
        {

            Assert.AreEqual(txtSearchResult.Text, searchTerm);
            
            return this;
        }

        


    
    }
}
