using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using TA_Tasks.PageObjects;
using TechTalk.SpecFlow;

namespace TA_Tasks
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private IWebDriver Driver => WebDriverBase.GetDriver();
        private BbcMainPage Main = new BbcMainPage();
        private BbcNewsPage News = new BbcNewsPage();
        private BbcSubmitStoryPage SubmitPage = new BbcSubmitStoryPage();
        private BbcSubmitQuestionPage QuestionPage = new BbcSubmitQuestionPage();

        [Given(@"I opened News Page")]
        public BbcNewsPage GoToNewsPage()
        {
            Main.GoToPage().GoToNewsPage();
            return new BbcNewsPage();
        }
        
        [Then(@"the heading should be (.*) as expected")]
        public void CheckHeading(string heading)
        {
            try
            {
                Assert.AreEqual(News.GetHeading(), heading);
            }
            finally
            {
                WebDriverBase.CloseDriver();
            }
        }

        [Then(@"I test secondary headings")]
        public void CheckSecondaryHeadings(Table tableStuff)
        {
            List<string> res = tableStuff.Rows.Select(row => row[0]).ToList();
            try
            {
                Assert.IsTrue(News.GetSecondaryHeadings().SequenceEqual(res));
            }
            finally
            {
                WebDriverBase.CloseDriver();
            }
        }

        [Then(@"I search category of main article and compare to (.*)")]
        public void SearchMainCategory(string category)
        {
            News.Search();
            BbcSearchResultsPage Search_res = new BbcSearchResultsPage();
            try
            {
                Assert.AreEqual(Search_res.GetResultHeadline(), category);
            }
            finally
            {
                WebDriverBase.CloseDriver();
            }
        }

        [Given(@"I opened Submit Story Page")]
        public BbcSubmitStoryPage GoToSubmitStoryPage()
        {
            Main.GoToPage().GoToNewsPage();
            BbcHaveYourSayPage Hys = News.GoToHaveYourSayPage();
            return Hys.GoToSubmitPage();
        }

        [When(@"I fill form with (.*); (.*); (.*); (.*); (.*)")]
        public void FillForm2(string name, string email, string town, string number, string comments)
        {
            //List<string> keysList = tableStuff.Header.ToList();
            //List<string> valuesList = tableStuff.Rows.Select(row => row[0]).ToList();
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("Name", name);
            values.Add("Your E-mail address", email);
            values.Add("Town & Country", town);
            values.Add("Your telephone number", number);
            values.Add("Comments", comments);
            SubmitPage.FillForm(values);
        }

        [Then(@"I check required field (.*)")]
        public void CheckField(string check_field)
        {
            SubmitPage.CheckField(check_field);
        }

        [Then(@"I decide whether to press Send button")]
        public void CheckSendButton()
        {
            string another_url = "https://www.google.com";
            string shareurl = Driver.Url;

            try
            {
                if (SubmitPage.CheckForm() == false)
                {
                    Assert.AreEqual(Driver.Url, shareurl);
                }
                else
                {
                    Assert.AreEqual(Driver.Url, another_url);
                }
            }
            finally
            {
                WebDriverBase.CloseDriver();
            }
        }

        //variant 1
        [Given(@"I opened Submit Question Page")]
        public BbcSubmitQuestionPage GoToSubmitQuestionPage()
        {
            Main.GoToPage().GoToNewsPage();
            BbcHaveYourSayPage Hys = News.GoToHaveYourSayPage();
            return Hys.GoToQuestionPage();
        }

        [When(@"I fill form1 with (.*); (.*); (.*); (.*); (.*)")]
        public void FillForm1(string name, string email, string age, string postcode, string comments)
        {
            //List<string> keysList = tableStuff.Header.ToList();
            //List<string> valuesList = tableStuff.Rows.Select(row => row[0]).ToList();
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("Name", name);
            values.Add("Email address", email);
            values.Add("Age", age);
            values.Add("Postcode", postcode);
            values.Add("What questions would you like us to investigate?", comments);
            QuestionPage.FillForm(values);
        }

        [Then(@"I check required question field (.*)")]
        public void CheckFieldQ(string check_field)
        {
            QuestionPage.CheckField(check_field);
        }

        [Then(@"I decide whether to press Submit button")]
        public void CheckSubmitButton()
        {
            string another_url = "https://www.google.com";
            string shareurl = Driver.Url;

            try
            {
                if (QuestionPage.CheckForm() == false)
                {
                    Assert.AreEqual(Driver.Url, shareurl);
                }
                else
                {
                    Assert.AreEqual(Driver.Url, another_url);
                }
            }
            finally
            {
                WebDriverBase.CloseDriver();
            }
        }
    }
}
