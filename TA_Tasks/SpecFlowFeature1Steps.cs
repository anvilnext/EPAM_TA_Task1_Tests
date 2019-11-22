using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using TA_Tasks.PageObjects;
using TechTalk.SpecFlow;

namespace TA_Task1.SpecFlow
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private IWebDriver driver;

        public SpecFlowFeature1Steps(IWebDriver driver)
        {
            this.driver = driver;
        }

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
    }
}
