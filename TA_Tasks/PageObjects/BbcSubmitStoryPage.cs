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
        private IWebDriver Driver => WebDriverBase.GetDriver();
        private static string XpathBase = "//label[contains(text(), '{0}')]/following-sibling::*";
        private static string Send_button = "//input[contains(@type, 'submit')]";
        private static string[] Required = { "Your E-mail address", "Comments" };

        Form Form2 = new Form(XpathBase, Send_button, Required);
        
        public BbcSubmitStoryPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public void FillForm(Dictionary<string, string> values)
        {
            Form2.FillForm(values);
        }

        public bool CheckForm()
        {
            return Form2.CheckForm();
        }
    }
}
