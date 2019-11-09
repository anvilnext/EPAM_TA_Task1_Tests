using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestClass]
public class Task2
{
    private const string Url = "https://www.bbc.com";

    //This test checks the reaction of the "Send" button on submitting users' news page
    [TestMethod]
    public void Test4()
    {
        string sample_text = "Saying that heaven for divide creeping cattle unto Yielding. Him i our, open was. Every waters female can't unto you'll signs open yielding behold fill morning. You're forth creature his said had one. Creature morning all creepeth gathering. Blessed wherein and kind. Day fowl may winged. Were from beast. Waters night together above itself fifth in isn't own morning made itself gathered moved day bearing heaven, yielding lesser. Winged creature unto void dry. Give own also. Spirit you second. Male land made image spirit grass brought creepeth, doesn't tree creeping him days very moved set, open doesn't brought fruit open.";
        string name = "User";
        string email = "test@test.com";

        //Creating Chrome driver and going to submitting stories page
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(Url);
        driver.FindElement(By.LinkText("News")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.FindElement(By.XPath("//span[contains(text(), 'More')]")).Click();
        driver.FindElement(By.LinkText("Have Your Say")).Click();
        driver.FindElement(By.LinkText("How to share with BBC News")).Click();
        string shareurl = driver.Url;

        //Filling fields
        IWebElement input_name = driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input')]"));
        IWebElement input_email = driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input')]/following-sibling::input"));
        IWebElement input_comments = driver.FindElement(By.XPath("//textarea[contains(@class, 'contact-form__textarea')]"));
        input_name.SendKeys(name);
        input_email.SendKeys(email);
        input_comments.SendKeys(sample_text);

        //Testing submit
        try
        {
            if ((input_email.GetAttribute("value") == "") || (input_comments.GetAttribute("value") == ""))
            {
                driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input--submit')]")).Click();
                Assert.AreEqual(driver.Url, shareurl);
            }
            else
            {
                Assert.AreEqual(driver.Url, Url);
            }
        }
        finally
        {
            //driver.Quit();
        }
    }

    //This test does the same as Test4 except string text increased to 200 characters
    [TestMethod]
    public void Test5()
    {
        string sample_text = "Light saying him, night night hath creepeth stars night hath beast together Second yielding isn't which make i Spirit moved is were he air upon blessed whose itself. You'll them fly divided, rule second herb winged cattle. Gathered divided moving our that after grass male. In cattle days for don't greater years let shall. And third lights good morning a can't may. Male grass fruitful light void lights you replenish multiply. Won't every image a darkness and brought hath stars made fish also tree i you you'll gathered, doesn't meat rule day gathered midst tree air subdue. A own unto midst. Man fowl likeness brought brought wherein in don't dry. Image him, winged man, fruit. Earth saying under don't let whose sea sixth good gathered the dry thing after yielding moveth them after very our and. May moving kind kind you'll won't winged him hath. The heaven his fish wherein him called moving whose given female. First fill set. Unto. Whales had form two dry lesser itself, thing. Meat he which whales saying darkness very evening won't, gathering day firmament beginning may morning stars face upon from beast. Sea he fruit their don't. Saw given Years seas. Let multiply a.";
        string name = "User";
        string email = "test@test.com";

        //Creating Chrome driver and going to submitting stories page
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(Url);
        driver.FindElement(By.LinkText("News")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.FindElement(By.XPath("//span[contains(text(), 'More')]")).Click();
        driver.FindElement(By.LinkText("Have Your Say")).Click();
        driver.FindElement(By.LinkText("How to share with BBC News")).Click();
        string shareurl = driver.Url;

        //Filling fields
        IWebElement input_name = driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input')]"));
        IWebElement input_email = driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input')]/following-sibling::input"));
        IWebElement input_comments = driver.FindElement(By.XPath("//textarea[contains(@class, 'contact-form__textarea')]"));
        input_name.SendKeys(name);
        input_email.SendKeys(email);
        input_comments.SendKeys(sample_text);

        //Testing submit
        try
        {
            if ((input_email.GetAttribute("value") == "") || (input_comments.GetAttribute("value") == ""))
            {
                driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input--submit')]")).Click();
                Assert.AreEqual(driver.Url, shareurl);
            }
            else
            {
                Assert.AreEqual(driver.Url, Url);
            }
        }
        finally
        {
            //driver.Quit();
        }
    }

    //This test does the same as Test4 except email field left empty
    [TestMethod]
    public void Test6()
    {
        string sample_text = "Light saying him, night night hath creepeth stars night hath beast together Second yielding isn't which make i Spirit moved is were he air upon blessed whose itself. You'll them fly divided, rule second herb winged cattle. Gathered divided moving our that after grass male. In cattle days for don't greater years let shall. And third lights good morning a can't may. Male grass fruitful light void lights you replenish multiply. Won't every image a darkness and brought hath stars made fish also tree i you you'll gathered, doesn't meat rule day gathered midst tree air subdue. A own unto midst. Man fowl likeness brought brought wherein in don't dry. Image him, winged man, fruit. Earth saying under don't let whose sea sixth good gathered the dry thing after yielding moveth them after very our and. May moving kind kind you'll won't winged him hath. The heaven his fish wherein him called moving whose given female. First fill set. Unto. Whales had form two dry lesser itself, thing. Meat he which whales saying darkness very evening won't, gathering day firmament beginning may morning stars face upon from beast. Sea he fruit their don't. Saw given Years seas. Let multiply a.";
        string name = "User";

        //Creating Chrome driver and going to submitting stories page
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(Url);
        driver.FindElement(By.LinkText("News")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.FindElement(By.XPath("//span[contains(text(), 'More')]")).Click();
        driver.FindElement(By.LinkText("Have Your Say")).Click();
        driver.FindElement(By.LinkText("How to share with BBC News")).Click();
        string shareurl = driver.Url;

        //Filling fields
        IWebElement input_name = driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input')]"));
        IWebElement input_email = driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input')]/following-sibling::input"));
        IWebElement input_comments = driver.FindElement(By.XPath("//textarea[contains(@class, 'contact-form__textarea')]"));
        input_name.SendKeys(name);
        input_comments.SendKeys(sample_text);

        //Testing submit
        try
        {
            if ((input_email.GetAttribute("value") == "") || (input_comments.GetAttribute("value") == ""))
            {
                driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input--submit')]")).Click();
                Assert.AreEqual(driver.Url, shareurl);
            }
            else
            {
                Assert.AreEqual(driver.Url, Url);
            }
        }
        finally
        {
            //driver.Quit();
        }
    }

    //This test does the same as Test4 except comments field left empty
    [TestMethod]
    public void Test7()
    {
        string name = "User";
        string email = "test@test.com";

        //Creating Chrome driver and going to submitting stories page
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(Url);
        driver.FindElement(By.LinkText("News")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.FindElement(By.XPath("//span[contains(text(), 'More')]")).Click();
        driver.FindElement(By.LinkText("Have Your Say")).Click();
        driver.FindElement(By.LinkText("How to share with BBC News")).Click();
        string shareurl = driver.Url;

        //Filling fields
        IWebElement input_name = driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input')]"));
        IWebElement input_email = driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input')]/following-sibling::input"));
        IWebElement input_comments = driver.FindElement(By.XPath("//textarea[contains(@class, 'contact-form__textarea')]"));
        input_name.SendKeys(name);
        input_email.SendKeys(email);

        //Testing submit
        try
        {
            if ((input_email.GetAttribute("value") == "") || (input_comments.GetAttribute("value") == ""))
            {
                driver.FindElement(By.XPath("//input[contains(@class, 'contact-form__input--submit')]")).Click();
                Assert.AreEqual(driver.Url, shareurl);
            }
            else
            {
                Assert.AreEqual(driver.Url, Url);
            }
        }
        finally
        {
            //driver.Quit();
        }
    }
}
