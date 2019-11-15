using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TA_Tasks.PageObjects
{
    class BbcNewsPage
    {
        private IWebDriver driver;

        public BbcNewsPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PageFactory.InitElements(driver, this);
        }

        //for test1
        [FindsBy(How = How.XPath, Using = "//h3[contains(@class, 'gs-c-promo-heading__title')]")]
        private IWebElement heading;

        public string GetHeading()
        {
            return heading.Text;
        }

        //for test2
        //[FindsBy(How = How.XPath, Using = "//div[contains(@class, 'nw-c-top-stories__secondary-item')]//h3")]
        //private IReadOnlyCollection<IWebElement> actual_headings_coll;

        //public List<string> GetSecondaryHeadings()
        //{
        //    List<IWebElement> actual_headings = actual_headings_coll.ToList();
        //    List<string> secondary_headings = new List<string>();
        //    for (int i = 0; i < actual_headings.Count; i++)
        //        secondary_headings.Add(actual_headings[i].Text);
        //    return secondary_headings;
        //}

        //for test3
        [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'nw-o-link--no-visited-state')]//span")]
        private IWebElement category_element;

        [FindsBy(How = How.Id, Using = "orb-search-q")]
        private IWebElement search_field;

        [FindsBy(How = How.XPath, Using = "//button[text()='Search the BBC']")]
        private IWebElement search_button;

        public BbcSearchResultsPage Search()
        {
            search_field.SendKeys(category_element.Text);
            search_button.Click();
            return new BbcSearchResultsPage(driver);
        }

        //for tests 4-7
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'More')]")]
        private IWebElement more_button;

        [FindsBy(How = How.LinkText, Using = "Have Your Say")]
        private IWebElement have_your_say;

        public BbcHaveYourSayPage GoToHaveYourSayPage()
        {
            more_button.Click();
            have_your_say.Click();
            return new BbcHaveYourSayPage(driver);
        }

    }
}
