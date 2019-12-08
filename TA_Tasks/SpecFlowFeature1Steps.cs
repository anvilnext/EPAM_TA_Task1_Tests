﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [When(@"I fill form")]
        public void FillForm(Table tableStuff)
        {
            List<string> keysList = tableStuff.Rows.Select(row => row[0]).ToList();
            List<string> valuesList = tableStuff.Rows.Select(row => row[1]).ToList();

            Dictionary<string, string> values = new Dictionary<string, string>();
            for (int i = 0; i < keysList.Count; i++)
                values.Add(keysList[i], valuesList[i]);

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
    }
}
