using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using TA_Tasks.PageObjects;

namespace TA_Tasks
{
    class Instance
    {
        private IWebDriver driver;

        public Instance(IWebDriver driver)
        {
            this.driver = driver;
        }

        public BbcNewsPage GoToNewsPage()
        {
            BbcMainPage main = new BbcMainPage(driver);
            main.GoToPage();
            BbcNewsPage news = main.GoToNewsPage();
            return new BbcNewsPage(driver);
        }

        public BbcSubmitStoryPage GoToSubmitPage()
        {
            BbcMainPage main = new BbcMainPage(driver);
            main.GoToPage();
            BbcNewsPage news = main.GoToNewsPage();
            BbcHaveYourSayPage haveyoursay = news.GoToHaveYourSayPage();
            BbcSubmitStoryPage submit = haveyoursay.GoToSubmitPage();
            return new BbcSubmitStoryPage(driver);
        }

    }
}
