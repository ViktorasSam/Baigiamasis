using BaigiamasisDenon.Page;
using BaigiamasisDenon.Drivers;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaigiamasisDenon.Tools;

namespace BaigiamasisDenon.Test
{
    public class BaseTest
    {
        protected static IWebDriver Driver;

        public static DenonLoginPage _denonLoginPage;
        public static PromoCodePage _promoCodePage;
        public static SearchAndSort _searchAndSort;

        [OneTimeSetUp]
        public static void SetUp()
        {
            Driver = CustomDriver.GetChromeDriver();

            _denonLoginPage = new DenonLoginPage(Driver);
            _promoCodePage = new PromoCodePage(Driver);
            _searchAndSort = new SearchAndSort(Driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(Driver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Driver.Close();
        }
    }

}
