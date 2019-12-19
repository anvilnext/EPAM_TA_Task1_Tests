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

        [Given(@"I opened News Page")]
        public BbcNewsPage GoToNewsPage()
        {
            Main.GoToPage().GoToNewsPage();
            return new BbcNewsPage();
        }
        
        [Then(@"the heading should be (.*) as expected")]
        public void CheckHeading(string heading)
        {
            Assert.AreEqual(heading, News.GetHeading());
        }

        [Then(@"I test secondary headings")]
        public void CheckSecondaryHeadings(Table tableStuff)
        {
            List<string> res = tableStuff.Rows.Select(row => row[0]).ToList();
            Assert.IsTrue(News.GetSecondaryHeadings().SequenceEqual(res));
        }

        [Then(@"I search category of main article and compare to (.*)")]
        public void SearchMainCategory(string category)
        {
            News.Search();
            BbcSearchResultsPage Search_res = new BbcSearchResultsPage();
            Assert.AreEqual(category, Search_res.GetResultHeadline());
        }

        //variant 2 page
        [Given(@"I opened Submit Story Page")]
        public BbcSubmitStoryPage GoToSubmitStoryPage()
        {
            Main.GoToPage().GoToNewsPage();
            BbcHaveYourSayPage Hys = News.GoToHaveYourSayPage();
            return Hys.GoToSubmitPage();
        }

        //variant 1 page
        [Given(@"I opened Submit Question Page")]
        public BbcSubmitQuestionPage GoToSubmitQuestionPage()
        {
            Main.GoToPage().GoToNewsPage();
            BbcHaveYourSayPage Hys = News.GoToHaveYourSayPage();
            return Hys.GoToQuestionPage();
        }

        //other methods work with both variants because of static class Helper
        [When(@"I fill form with values")]
        public void FillForm(Table tableStuff)
        {
            Dictionary<string, string> form_filling = tableStuff.Rows[0].ToDictionary(p => p.Key, p => p.Value);
            Helper.FillForm(form_filling);
        }

        [Then(@"I make sure that I submitted a (.*)")]
        public void CheckForm(string pagetype)
        {
            string another_url = "https://www.google.com";
            string shareurl = Driver.Url;

            if (Helper.CheckForm(pagetype) == false)
            {
                Assert.AreEqual(shareurl, Driver.Url);
            }
            else
            {
                Assert.AreEqual(another_url, Driver.Url);
            }
        }
    }
}
