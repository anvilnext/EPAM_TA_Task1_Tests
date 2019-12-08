using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TA_Tasks
{
    static class WebDriverBase
    {
        private static IWebDriver Driver;
        public static IWebDriver GetDriver()
        {
            if (Driver == null)
            {
                Driver = new ChromeDriver();
            }
            return Driver;
        }

        public static void CloseDriver()
        {
            Driver.Quit();
        }
    }
}
