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
        private Dictionary<string, string> values;

        private string xname = "//input[contains(@class, 'contact-form__input')]";
        private string xemail = "//input[contains(@class, 'contact-form__input')]/following-sibling::input";
        private string xcomments = "//textarea[contains(@class, 'contact-form__textarea')]";

        public BbcSubmitStoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //for tests 4-7
        [FindsBy(How = How.XPath, Using = "//input[contains(@class, 'contact-form__input--submit')]")]
        private IWebElement send_button;

        public void FillForm(Dictionary<string, string> values)
        {
            this.values = values;
            foreach (string field in values.Keys)
            {
                switch (field)
                {
                    case "Name":
                        driver.FindElement(By.XPath(xname)).SendKeys(values["Name"]);
                        break;
                    case "Email":
                        driver.FindElement(By.XPath(xemail)).SendKeys(values["Email"]);
                        break;
                    case "Comments":
                        driver.FindElement(By.XPath(xcomments)).SendKeys(values["Comments"]);
                        break;
                }
            }
        }

        public bool CheckFields()
        {
            if ((driver.FindElement(By.XPath(xemail)).GetAttribute("value") == "") || ((driver.FindElement(By.XPath(xcomments)).GetAttribute("value") == "")))
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
