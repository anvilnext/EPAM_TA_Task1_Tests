using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TA_Tasks.PageObjects
{
    public class BbcNewsPage
    {
        private IWebDriver Driver => WebDriverBase.GetDriver();

        public BbcNewsPage()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PageFactory.InitElements(Driver, this);
        }

        //for test1
        [FindsBy(How = How.XPath, Using = "//h3[contains(@class, 'gs-c-promo-heading__title')]")]
        private IWebElement Heading;

        public string GetHeading()
        {
            return Heading.Text;
        }

        //for test2
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'nw-c-top-stories__secondary-item')]//h3")]
        private IList<IWebElement> Actual_headings;

        public List<string> GetSecondaryHeadings()
        {
            List<string> secondary_headings = new List<string>();
            for (int i = 0; i < Actual_headings.Count; i++)
                secondary_headings.Add(Actual_headings[i].Text);
            return secondary_headings;
        }

        //for test3
        [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'nw-o-link--no-visited-state')]//span")]
        private IWebElement Category_element;

        [FindsBy(How = How.Id, Using = "orb-search-q")]
        private IWebElement Search_field;

        [FindsBy(How = How.XPath, Using = "//button[text()='Search the BBC']")]
        private IWebElement Search_button;

        public BbcSearchResultsPage Search()
        {
            Search_field.SendKeys(Category_element.Text);
            Search_button.Click();
            return new BbcSearchResultsPage();
        }

        //for tests 4-7
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'More')]")]
        private IWebElement More_button;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Have Your Say')]")]
        private IWebElement Have_your_say;

        public BbcHaveYourSayPage GoToHaveYourSayPage()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            More_button.Click();
            Have_your_say.Click();
            return new BbcHaveYourSayPage();
        }

    }
}
