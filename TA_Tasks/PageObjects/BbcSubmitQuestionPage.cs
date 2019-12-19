using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Tasks.PageObjects
{
    public class BbcSubmitQuestionPage
    {
        //VARIANT 1
        private IWebDriver Driver => WebDriverBase.GetDriver();
        private static string XpathBase = "//input[@placeholder='{0}']|//textarea[@placeholder='{0}']";
        private static string Send_button = "//button[contains(text(), 'Submit')]";
        private static string[] Required = { "Name", "Email address", "What questions would you like us to investigate?" };

        Form Form1 = new Form(XpathBase, Send_button, Required);

        public BbcSubmitQuestionPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public void FillForm(Dictionary<string, string> values)
        {
            Form1.FillForm(values);
        }

        public bool CheckForm()
        {
            return Form1.CheckForm();
        }
    }
}
