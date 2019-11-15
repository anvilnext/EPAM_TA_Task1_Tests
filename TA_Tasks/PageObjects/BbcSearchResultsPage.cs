using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Tasks.PageObjects
{
    class BbcSearchResultsPage
    {
        private IWebDriver driver;

        public BbcSearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//ol[contains(@class, 'search-results')]//h1//a")]
        private IWebElement result_headline;

        public string GetResultHeadline()
        {
            return result_headline.Text;
        }

    }
}
