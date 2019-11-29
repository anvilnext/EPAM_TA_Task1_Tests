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
        private static IWebDriver driver = new ChromeDriver();
        private BbcMainPage main = new BbcMainPage(driver);
        private BbcNewsPage news = new BbcNewsPage(driver);

        [Given(@"I opened News Page")]
        public BbcNewsPage GoToNewsPage()
        {
            main.GoToPage();
            main.GoToNewsPage();
            return new BbcNewsPage(driver);
        }
        
        [Then(@"the heading should be (.*) as expected")]
        public void CheckHeading(string heading)
        {
            Assert.AreEqual(news.GetHeading(), heading);
        }

        [Then(@"I test secondary headings")]
        public void CheckSecondaryHeadings(Table tableStuff)
        {
            List<string> res = tableStuff.Rows.Select(row => row[0]).ToList();
            Assert.IsTrue(news.GetSecondaryHeadings().SequenceEqual(res));
        }

        [Then(@"I search category of main article and compare to (.*)")]
        public void SearchMainCategory(string category)
        {
            news.Search();
            BbcSearchResultsPage search_res = new BbcSearchResultsPage(driver);
            Assert.AreEqual(search_res.GetResultHeadline(), category);
        }

        [Given(@"I opened Submit Story Page")]
        public BbcSubmitStoryPage GoToSubmitStoryPage()
        {
            main.GoToPage();
            main.GoToNewsPage();
            BbcHaveYourSayPage hys = news.GoToHaveYourSayPage();
            return hys.GoToSubmitPage();
        }

        [Then(@"I fill form")]
        public void FillForm(Table tableStuff)
        {
            string another_url = "https://www.google.com";
            string shareurl = driver.Url;
            List<string> keysList = tableStuff.Rows.Select(row => row[0]).ToList();
            List<string> valuesList = tableStuff.Rows.Select(row => row[1]).ToList();
            Dictionary<string, string> values = new Dictionary<string, string>();
            for (int i = 0; i < keysList.Count; i++)
                values.Add(keysList[i], valuesList[i]);

            BbcSubmitStoryPage sub = new BbcSubmitStoryPage(driver);
            if (sub.FillForm(values) == true)
            {
                Assert.AreEqual(driver.Url, shareurl);
            } else
            {
                Assert.AreEqual(driver.Url, another_url);
            }
        }
    }
}
