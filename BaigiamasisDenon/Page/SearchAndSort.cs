using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaigiamasisDenon.Page
{
    public class SearchAndSort : BasePage
    {
        private const string _pageAddress = "https://www.denonsalonai.lt/";
        private const string _brandToFind = "BANG & OLUFSEN";
        private const string _productsAreAvailable = "produktai";
        private const string _available = "Prieinamas";
        private const string _lastItem = "Paskutinė prekė";


        private IWebElement _popup => Driver.FindElement(By.CssSelector("#webform_preview > div"));
        private IWebElement _searchFeald => Driver.FindElement(By.CssSelector("#_desktop_search > div > div > div.tvsearch-header-display-full > div > form > div.tvheader-top-search > div > input"));
        private IWebElement _availableProducts => Driver.FindElement(By.CssSelector("#js-product-list-top > div.col-sm-6.col-md-4.col-lg-4.tv-left-search-totle-product > div > p"));
        private IWebElement _dropDownClick => Driver.FindElement(By.CssSelector("#js-product-list-top > div.col-sm-12.col-md-4.col-lg-4.tvall-page-shortby > div > div > button"));
        private IWebElement _dropDownSelect => Driver.FindElement(By.CssSelector("#js-product-list-top > div.col-sm-12.col-md-4.col-lg-4.tvall-page-shortby > div > div > div > a:nth-child(4)"));
        private IWebElement _pickCheapestItem => Driver.FindElement(By.CssSelector("#js-product-list > div > div > article:nth-child(1) > div > div.tvproduct-wrapper.grid > div.tvproduct-image > a"));
        private IWebElement _productAvailability => Driver.FindElement(By.CssSelector("#product-availability"));

        public SearchAndSort(IWebDriver webDriver) : base(webDriver) { }

        public SearchAndSort NavigateToDefaultPage()
        {
            if (Driver.Url != _pageAddress)
            {
                Driver.Url = _pageAddress;
            }
            return this;
        }

        public SearchAndSort SwitchToFrame()
        {
            Driver.SwitchTo().Frame(0);

            return this;
        }

        public SearchAndSort ClosePopup()
        {
            _popup.Click();

            return this;
        }

        public SearchAndSort SwitchToDefault()
        {
            Driver.SwitchTo().DefaultContent();

            return this;
        }

        public SearchAndSort Wait()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return this;
        }

        public SearchAndSort SearchFieldInputAndFind()
        {
            _searchFeald.SendKeys(_brandToFind);
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();
            
            return this;
        }
        
        public SearchAndSort CheckProductAvailability()
        {
            Assert.True(_availableProducts.Text.Contains(_productsAreAvailable));

            return this;
        }

        public SearchAndSort DropDownSelect()
        {
            _dropDownClick.Click();
            
            return this;
        }

        public SearchAndSort SelectFromDropDown()
        {
            _dropDownSelect.Click();

            return this;
        }

        public SearchAndSort PickCheapestItemFromList()
        {
            _pickCheapestItem.Click();

            return this;
        }

        public SearchAndSort CheckIfAvailable()
        {
            
            switch (_productAvailability.Text)
            {
                case _available:
                    Assert.AreEqual(_available, _productAvailability.Text);
                    break;
                case _lastItem:
                    Assert.AreEqual(_lastItem, _productAvailability.Text);
                    break;
                default:
                    Assert.Fail("Product not available");
                    break;
            }
            return this;
        }

    }
}
