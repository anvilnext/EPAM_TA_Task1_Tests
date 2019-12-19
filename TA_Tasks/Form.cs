using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Tasks
{
    public class Form
    {
        private IWebDriver Driver => WebDriverBase.GetDriver();
        private string XpathBase;
        private string Send_button;
        private string[] Required;
        private bool AllRequiredNotEmpty = true;

        public Form(string XpathBase, string Send_button, string[] Required)
        {
            this.XpathBase = XpathBase;
            this.Send_button = Send_button;
            this.Required = Required;
        }

        public void FillForm(Dictionary<string, string> values)
        {
            foreach (string field in values.Keys)
            {
                Driver.FindElement(By.XPath(string.Format(XpathBase, field))).SendKeys(values[field]);
            }
        }

        //if empty required field found - set the value to false
        public bool CheckForm()
        {
            foreach (string s in Required)
            {
                if (Driver.FindElement(By.XPath(string.Format(XpathBase, s))).GetAttribute("value") == "")
                {
                    AllRequiredNotEmpty = false;
                } 
            }

            if (AllRequiredNotEmpty == false)
            {
                Driver.FindElement(By.XPath(Send_button)).Click();
            }

            return AllRequiredNotEmpty;
        }
    }
}
