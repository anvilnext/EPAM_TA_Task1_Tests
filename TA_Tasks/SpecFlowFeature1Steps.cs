using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using TA_Tasks.BLL;
using TA_Tasks.PageObjects;
using TechTalk.SpecFlow;

namespace TA_Tasks
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private static IWebDriver driver = new ChromeDriver();
        //BLayer bl = new BLayer(driver);

        [Given(@"I opened News Page")]
        public BbcNewsPage GoToNewsPage()
        {
            BbcMainPage main = new BbcMainPage(driver);
            main.GoToPage();
            BbcNewsPage news = main.GoToNewsPage();
            return new BbcNewsPage(driver);
        }
        
        [Then(@"the heading should be (.*) as expected")]
        public void CheckHeading(string heading)
        {
            BbcNewsPage news = new BbcNewsPage(driver);
            Assert.AreEqual(news.GetHeading(), heading);
        }

        [Then(@"I test (.*)")]
        public void CheckSecondaryHeadings(string stuff, Table tableStuff)
        {
            BbcNewsPage news = new BbcNewsPage(driver);
            Assert.AreEqual(news.GetSecondaryHeadings(), tableStuff);
        }

        //[Then(@"the heading should be (.*) as expected")]
        //public void (string p0)
        //{
        //    ScenarioContext.Current.Pending();
        //}
    }
}
