using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TA_Tasks.BLL;

namespace TA_Tasks
{

    [TestClass]
    public class Task2
    {
        private string another_url = "https://www.google.com";
        private IWebDriver driver = new ChromeDriver();
        private string name = "User";
        private string email = "test@test.com";

        //This test checks the reaction of the "Send" button on submitting users' news page
        [TestMethod]
        public void Test4()
        {
            //Values to fill fields
            string sample_text = "Saying that heaven for divide creeping cattle unto Yielding. Him i our, open was. Every waters female can't unto you'll signs open yielding behold fill morning. You're forth creature his said had one. Creature morning all creepeth gathering. Blessed wherein and kind. Day fowl may winged. Were from beast. Waters night together above itself fifth in isn't own morning made itself gathered moved day bearing heaven, yielding lesser. Winged creature unto void dry. Give own also. Spirit you second. Male land made image spirit grass brought creepeth, doesn't tree creeping him days very moved set, open doesn't brought fruit open.";
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                {"Name", name },
                {"Email", email },
                {"Comments", sample_text}
            };
            
            //Going to the submitting stories page
            BLayer bl = new BLayer(driver);
            bl.GoToSubmitPage();

            string shareurl = driver.Url;

            //Filling fields
            bl.FillForm(values);

            //Testing submit
            try
            {
                if (bl.CheckFields() == true)
                {
                    Assert.AreEqual(driver.Url, shareurl);
                }
                else
                {
                    Assert.AreEqual(driver.Url, another_url);
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
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                {"Name", name },
                {"Email", email },
                {"Comments", sample_text}
            };

            //Going to the submitting stories page
            BLayer bl = new BLayer(driver);
            bl.GoToSubmitPage();

            string shareurl = driver.Url;

            //Filling fields
            bl.FillForm(values);

            //Testing submit
            try
            {
                if (bl.CheckFields() == true)
                {
                    Assert.AreEqual(driver.Url, shareurl);
                }
                else
                {
                    Assert.AreEqual(driver.Url, another_url);
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
            string sample_text = "Saying that heaven for divide creeping cattle unto Yielding. Him i our, open was. Every waters female can't unto you'll signs open yielding behold fill morning. You're forth creature his said had one. Creature morning all creepeth gathering. Blessed wherein and kind. Day fowl may winged. Were from beast. Waters night together above itself fifth in isn't own morning made itself gathered moved day bearing heaven, yielding lesser. Winged creature unto void dry. Give own also. Spirit you second. Male land made image spirit grass brought creepeth, doesn't tree creeping him days very moved set, open doesn't brought fruit open.";
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                {"Name", name },
                {"Email", "" },
                {"Comments", sample_text}
            };

            //Going to the submitting stories page
            BLayer bl = new BLayer(driver);
            bl.GoToSubmitPage();

            string shareurl = driver.Url;

            //Filling fields
            bl.FillForm(values);

            //Testing submit
            try
            {
                if (bl.CheckFields() == true)
                {
                    Assert.AreEqual(driver.Url, shareurl);
                }
                else
                {
                    Assert.AreEqual(driver.Url, another_url);
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
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                {"Name", name },
                {"Email", email },
                {"Comments", ""}
            };

            //Going to the submitting stories page
            BLayer bl = new BLayer(driver);
            bl.GoToSubmitPage();

            string shareurl = driver.Url;

            //Filling fields
            bl.FillForm(values);

            //Testing submit
            try
            {
                if (bl.CheckFields() == true)
                {
                    Assert.AreEqual(driver.Url, shareurl);
                }
                else
                {
                    Assert.AreEqual(driver.Url, another_url);
                }
            }
            finally
            {
                //driver.Quit();
            }
        }
    }

}