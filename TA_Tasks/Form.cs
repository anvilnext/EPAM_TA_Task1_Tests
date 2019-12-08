using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Tasks
{
    class Form
    {
        private IWebDriver Driver => WebDriverBase.GetDriver();
        private string XpathBase;
        private string Send_button;
        private bool AllRequiredNotEmpty = true;

        public Form(string XpathBase, string Send_button)
        {
            this.XpathBase = XpathBase;
            this.Send_button = Send_button;
        }

        public void FillForm(Dictionary<string, string> values)
        {
            foreach (string field in values.Keys)
            {
                Driver.FindElement(By.XPath(string.Format(XpathBase, field))).SendKeys(values[field]);
            }
        }

        //if empty required field found - set the field to false
        public void CheckField(string check_field)
        {
            if (Driver.FindElement(By.XPath(string.Format(XpathBase, check_field))).GetAttribute("value") == "")
                AllRequiredNotEmpty = false;
        }

        public bool CheckForm()
        {
            if (AllRequiredNotEmpty == false)
            {
                Driver.FindElement(By.XPath(Send_button)).Click();
            }

            return AllRequiredNotEmpty;
        }
    }
}
