using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA_Tasks.PageObjects
{
    public class BbcSubmitStoryPage
    {
        private IWebDriver driver;
        private string xpathBase = "//label[contains(text(), '')]/following-sibling::";

        public BbcSubmitStoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //for tests 4-7
        [FindsBy(How = How.XPath, Using = "//input[contains(@class, 'contact-form__input--submit')]")]
        private IWebElement send_button;

        public bool FillForm(Dictionary<string, string> values)
        {
            foreach (string field in values.Keys)
            {
                if (field != "Comments")
                {
                    driver.FindElement(By.XPath(xpathBase.Insert(26, field) + "input")).SendKeys(values[field]);
                }
                else
                {
                    driver.FindElement(By.XPath(xpathBase.Insert(26, field) + "textarea")).SendKeys(values[field]);
                }
            }

            if ((values["Your E-mail address"] == "") || (values["Comments"] == ""))
            {
                send_button.Click();
                return true;
            }
            else
            {
                return false;
            }
        }

        //public bool CheckFields()
        //{
        //    List<IWebElement> required = driver.FindElements(By.XPath("//span[contains(text(), 'required')]/../following-sibling::input")).ToList();
        //    List<string> res = new List<string>();
        //    for (int i = 0; i < required.Count; i++)
        //        res[i] = required[i].Text;

        //    if ((res.Count == 0) || (res.Contains("")) || (driver.FindElement(By.XPath("//span[contains(text(), 'required')]/../following-sibling::textarea")).GetAttribute("value") == ""))
        //    {
        //        send_button.Click();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
