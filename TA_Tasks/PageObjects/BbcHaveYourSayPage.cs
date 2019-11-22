using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Tasks.PageObjects
{
    public class BbcHaveYourSayPage
    {
        private IWebDriver driver;

        public BbcHaveYourSayPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //dor tests 4-7
        [FindsBy(How = How.LinkText, Using = "How to share with BBC News")]
        private IWebElement how_to_share;

        public BbcSubmitStoryPage GoToSubmitPage()
        {
            how_to_share.Click();
            return new BbcSubmitStoryPage(driver);
        }
    }
}
