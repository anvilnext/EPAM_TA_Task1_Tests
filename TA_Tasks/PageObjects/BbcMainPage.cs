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
        private IWebDriver driver;

        public BbcMainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "News")]
        private IWebElement news_page_button;

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://www.bbc.com");
        }

        public BbcNewsPage GoToNewsPage()
        {
            news_page_button.Click();
            return new BbcNewsPage(driver);
        }

    }
}
