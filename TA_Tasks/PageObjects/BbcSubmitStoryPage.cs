using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Tasks.PageObjects
{
    class BbcSubmitStoryPage
    {
        private IWebDriver driver;

        public BbcSubmitStoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //for tests 4-7
        [FindsBy(How = How.XPath, Using = "//input[contains(@class, 'contact-form__input')]")]
        private IWebElement input_name;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class, 'contact-form__input')]/following-sibling::input")]
        private IWebElement input_email;

        [FindsBy(How = How.XPath, Using = "//textarea[contains(@class, 'contact-form__textarea')]")]
        private IWebElement input_comments;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class, 'contact-form__input--submit')]")]
        private IWebElement send_button;

        public void FillName(string text_name)
        {
            input_name.SendKeys(text_name);
        }

        public void FillEmail(string text_email)
        {
            input_email.SendKeys(text_email);
        }

        public void FillComments(string text_comments)
        {
            input_comments.SendKeys(text_comments);
        }

        public bool CheckFields()
        {
            if ((input_email.GetAttribute("value") == "") || (input_comments.GetAttribute("value") == ""))
            {
                send_button.Click();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
