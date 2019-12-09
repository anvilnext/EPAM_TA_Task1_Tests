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
        private IWebDriver Driver => WebDriverBase.GetDriver();

        public BbcHaveYourSayPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        //for tests 4-7
        [FindsBy(How = How.LinkText, Using = "How to share with BBC News")]
        private IWebElement How_to_share;

        public BbcSubmitStoryPage GoToSubmitPage()
        {
            How_to_share.Click();
            return new BbcSubmitStoryPage();
        }

        //for variant 1 tests 4-7
        [FindsBy(How = How.LinkText, Using = "Do you have a question for BBC News?")]
        private IWebElement Question_Link;

        public BbcSubmitQuestionPage GoToQuestionPage()
        {
            Question_Link.Click();
            return new BbcSubmitQuestionPage();
        }
    }
}
