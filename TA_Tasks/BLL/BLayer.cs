using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA_Tasks.PageObjects;
using TechTalk.SpecFlow;

namespace TA_Tasks.BLL
{
    class BLayer
    {
        private IWebDriver driver;

        public BLayer(IWebDriver driver)
        {
            this.driver = driver;
        }

        //for tests 1-3
        [Given("I opened News Page")]
        public BbcNewsPage GoToNewsPage()
        {
            BbcMainPage main = new BbcMainPage(driver);
            main.GoToPage();
            BbcNewsPage news = main.GoToNewsPage();
            return new BbcNewsPage(driver);
        }

        [When("I check main heading")]
        public string GetMainHeading()
        {
            BbcNewsPage news = new BbcNewsPage(driver);
            return news.GetHeading();
        }

        [Then("the heading should be (.*) as expected")]
        public void CheckMainHeading(string testHeadline)
        {
            BbcNewsPage news = new BbcNewsPage(driver);
            Assert.AreEqual(news.GetHeading(), testHeadline);
        }

        public List<string> GetSecondaryHeadings()
        {
            BbcNewsPage news = new BbcNewsPage(driver);
            return news.GetSecondaryHeadings();
        }

        public string GetResultHeadline()
        {
            BbcNewsPage news = new BbcNewsPage(driver);
            news.Search();
            BbcSearchResultsPage search_res = new BbcSearchResultsPage(driver);
            return search_res.GetResultHeadline();
        }

        //for tests 4-7
        public BbcSubmitStoryPage GoToSubmitPage()
        {
            BbcMainPage main = new BbcMainPage(driver);
            main.GoToPage();
            BbcNewsPage news = main.GoToNewsPage();
            BbcHaveYourSayPage haveyoursay = news.GoToHaveYourSayPage();
            BbcSubmitStoryPage submit = haveyoursay.GoToSubmitPage();
            return new BbcSubmitStoryPage(driver);
        }

        public void FillForm(Dictionary<string, string> values)
        {
            BbcSubmitStoryPage submit = new BbcSubmitStoryPage(driver);
            submit.FillForm(values);
        }

        public bool CheckFields()
        {
            BbcSubmitStoryPage submit = new BbcSubmitStoryPage(driver);
            return submit.CheckFields();
        }
    }
}
