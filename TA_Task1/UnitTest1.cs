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

        [TestMethod]
        public void Test1()
        {
            //Strong value to check the headline
            string testHeadline = "India air pollution at 'unbearable levels'";

            //Creating Chrome driver and going to the News page
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com");
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
            List<string> Expected_Results = new List<string>() { "Hong Kong protests: Knife attacker bites man's ear",
                                                        "Nigel Farage will not stand as election candidate",
                                                        "World's most profitable company to go public",
                                                        "'Comfort women' film to be shown in Japan amid row" };

            //List of headlines
            List<string> Actual_Results = new List<string>();

            //Creating Chrome driver and going to the News page
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.FindElement(By.LinkText("News")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Adding headlines
            IWebElement element1 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[3]/div/div[2]/div/a/h3"));
            Actual_Results.Add(element1.Text);
            IWebElement element2 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[5]/div/div[2]/div/a/h3"));
            Actual_Results.Add(element2.Text);
            IWebElement element3 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[8]/div/div[2]/div/a/h3"));
            Actual_Results.Add(element3.Text);
            IWebElement element4 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[11]/div/div[2]/div/a/h3"));
            Actual_Results.Add(element4.Text);

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
            driver.Navigate().GoToUrl("https://www.bbc.com");
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
