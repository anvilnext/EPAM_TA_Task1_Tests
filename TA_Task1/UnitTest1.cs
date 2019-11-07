using System;
using System.Collections.Generic;
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
            string testHeadline = "Nato alliance is brain dead, says Macron";

            //Creating Chrome driver and going to the News page
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            driver.FindElement(By.LinkText("News")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Testing headline
            IWebElement element = driver.FindElement(By.XPath("//h3[contains(@class, 'gs-c-promo-heading__title')]"));

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
            List<string> Expected_Results = new List<string>() { "Trump denies asking attorney general to clear him",
                                                                 "Holocaust survivor under guard amid death threats",
                                                                 "Protesters forcibly cut off Bolivia mayor's hair",
                                                                 "Beach in Finland covered in rare 'ice eggs'",
                                                                 "Chris Brown's clothes sale leaves fans angry" };

            //List of headlines
            List<string> Actual_Results = new List<string>();

            //Creating Chrome driver and going to the News page
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            driver.FindElement(By.LinkText("News")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Finding elements
            List<IWebElement> Actual_Results_elements = driver.FindElements(By.XPath("//div[contains(@class, 'nw-c-top-stories__secondary-item')]//h3")).ToList();
            for (int i = 0; i < Actual_Results_elements.Count; i++)
                Actual_Results.Add(Actual_Results_elements[i].Text);

            //Testing headlines
            try
            {
                Assert.IsTrue(Actual_Results.SequenceEqual(Expected_Results));
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

            //Creating Chrome driver and going to the News page
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            driver.FindElement(By.LinkText("News")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Storing and entering text
            string category = driver.FindElement(By.XPath("//a[contains(@class, 'nw-o-link--no-visited-state')]//span")).Text;
            driver.FindElement(By.Id("orb-search-q")).SendKeys(category);
            driver.FindElement(By.XPath("//button[text()='Search the BBC']")).Click();

            //Testing headline
            IWebElement element = driver.FindElement(By.XPath("//ol[contains(@class, 'search-results')]//a"));
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
