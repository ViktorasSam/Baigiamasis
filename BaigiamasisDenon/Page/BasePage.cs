using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDenon.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;
        
        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }
        public void CloseBrowser()
        {
            Driver.Quit();
        }

    }
}

