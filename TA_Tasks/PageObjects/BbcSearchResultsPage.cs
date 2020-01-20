using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Tasks.PageObjects
{
    public class BbcSearchResultsPage
    {
        private IWebDriver Driver => WebDriverBase.GetDriver();

        public BbcSearchResultsPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        //[FindsBy(How = How.XPath, Using = "//ol[contains(@class, 'search-results')]//h1//a")]
        [FindsBy(How = How.CssSelector, Using = "ol[class*='search-results'] h1 a")]
        private IWebElement Result_headline;

        //first header in search results
        public string GetResultHeadline()
        {
            return Result_headline.Text;
        }

    }
}
