using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Tasks.PageObjects
{
    public class BbcMainPage
    {
        private IWebDriver Driver => WebDriverBase.GetDriver();

        public BbcMainPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "News")]
        private IWebElement News_page_button;

        public BbcMainPage GoToPage()
        {
            Driver.Navigate().GoToUrl("https://www.bbc.com");
            return new BbcMainPage();
        }

        public BbcNewsPage GoToNewsPage()
        {
            News_page_button.Click();
            return new BbcNewsPage();
        }

    }
}
