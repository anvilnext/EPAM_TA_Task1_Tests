using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using TA_Tasks;
using TA_Tasks.PageObjects;
using TA_Tasks.BLL;

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
            string testHeadline = "Ex-US ambassador 'intimidated' by Trump";

            BLayer bl = new BLayer(driver);
            
            //Testing headline
            try
            {
                Assert.AreEqual(bl.GetMainHeading(), testHeadline);
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

            BLayer bl = new BLayer(driver);

            //Testing headlines
            try
            {
                Assert.IsTrue(bl.GetSecondaryHeadings().SequenceEqual(Expected_Results));
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

            BLayer bl = new BLayer(driver);

            //Testing headline
            try
            {
                Assert.AreEqual(bl.GetResultHeadline(), testHeadline);
            }
            finally
            {
                driver.Quit();
            }
        }
    }

}