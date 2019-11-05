﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EPAM_TA
{
    [TestClass]
    public class UnitTest1
    {
        private const string Url = "https://www.bbc.com";

        [TestMethod]
        public void Test1()
        {
            //Strong value to check the headline
            string testHeadline = "Nine US citizens killed in Mexico attack";

            //Creating Chrome driver and going to the News page
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            driver.FindElement(By.LinkText("News")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Testing headline
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[1]/div/div/div[1]/div/a/h3"));
            try
            {
                Assert.AreEqual(element.Text, testHeadline);
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
            List<string> Expected_Results = new List<string>() { "'Regret' as US begins exit from UN climate accord",
                                                        "Chilean President Piñera 'will not resign'",
                                                        "Facebook changes product branding to FACEBOOK",
                                                        "NZ tourist lost at sea 'survived on boiled sweets'",
                                                        "Pilot gets life ban after woman's cockpit photo" };

            //List of headlines
            List<string> Actual_Results = new List<string>();

            //Creating Chrome driver and going to the News page
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            driver.FindElement(By.LinkText("News")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Adding headlines
            //gs-c-promo nw-c-promo gs-o-faux-block-link gs-u-pb gs-u-pb+@m nw-p-default gs-c-promo--inline gs-c-promo--stacked@m nw-u-w-auto gs-c-promo--flex
            //List<IWebElement> ElementCollection = driver.FindElements(By.ClassName(".gs-c-promo nw-c-promo gs-o-faux-block-link gs-u-pb gs-u-pb+@m nw-p-default gs-c-promo--inline gs-c-promo--stacked@m nw-u-w-auto gs-c-promo--flex")).ToList();

            //for (int i = 0; i<ElementCollection.Count; i++)
            //{
            //    Assert.AreEqual(Expected_Results[i], ElementCollection[i]);
            //}

            IWebElement element1 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[3]/div/div[2]/div/a/h3"));
            Actual_Results.Add(element1.Text);
            IWebElement element2 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[5]/div/div[2]/div/a/h3"));
            Actual_Results.Add(element2.Text);
            IWebElement element3 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[8]/div/div[2]/div/a/h3"));
            Actual_Results.Add(element3.Text);
            IWebElement element4 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[9]/div/div[2]/div/a/h3"));
            Actual_Results.Add(element4.Text);
            IWebElement element5 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[11]/div/div[2]/div/a/h3"));
            Actual_Results.Add(element5.Text);

            //Testing headlines
            try
            {
                Assert.IsTrue(Expected_Results.SequenceEqual(Actual_Results));
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void Test3()
        {
            //Creating Chrome driver and going to the News page
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            driver.FindElement(By.LinkText("News")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Storing and entering text
            string category = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[1]/div/div/div[1]/ul/li[2]/a/span")).Text;
            driver.FindElement(By.XPath("/html/body/header/div/div[1]/div[3]/form/div/input[1]")).SendKeys(category);
            driver.FindElement(By.XPath("/html/body/header/div/div[1]/div[3]/form/div/button")).Click();

            //Testing headline
            string testHeadline = "India";
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[6]/section[2]/ol[1]/li[1]/article/div/h1/a"));
            try
            {
                Assert.AreEqual(element.Text, testHeadline);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}