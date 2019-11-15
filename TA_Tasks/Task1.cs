using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using TA_Tasks;
using TA_Tasks.PageObjects;

namespace TA_Tasks
{

    [TestClass]
    public class Task1
    {
        private IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void Test1()
        {
            //Strong value to check the headline
            string testHeadline = "'Russia directed rebels' accused in MH17 disaster ";

            //Going to the News page
            Instance instance = new Instance(driver);
            BbcNewsPage news = instance.GoToNewsPage();

            //Testing headline
            try
            {
                Assert.AreEqual(news.GetHeading(), testHeadline);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void Test2()
        {
            //List of strong values to check headlines
            List<string> Expected_Results = new List<string>() { "Trump denies asking attorney general to clear him",
                                                                 "Holocaust survivor under guard amid death threats",
                                                                 "Protesters forcibly cut off Bolivia mayor's hair",
                                                                 "Beach in Finland covered in rare 'ice eggs'",
                                                                 "Chris Brown's clothes sale leaves fans angry" };

            //Going to the News page
            Instance instance = new Instance(driver);
            BbcNewsPage news = instance.GoToNewsPage();

            //Testing headlines
            try
            {
                //Assert.IsTrue(news.GetSecondaryHeadings().SequenceEqual(Expected_Results));
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void Test3()
        {
            //Strong value to check the headline
            string testHeadline = "D-Block Europe";

            //Going to the News page
            Instance instance = new Instance(driver);
            BbcNewsPage news = instance.GoToNewsPage();

            //Invoking search
            BbcSearchResultsPage result = news.Search();

            //Testing headline
            try
            {
                Assert.AreEqual(result.GetResultHeadline(), testHeadline);
            }
            finally
            {
                driver.Quit();
            }
        }
    }

}