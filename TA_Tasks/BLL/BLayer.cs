using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA_Tasks.PageObjects;

namespace TA_Tasks.BLL
{
    class BLayer
    {
        private IWebDriver driver;

        public BLayer(IWebDriver driver)
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
