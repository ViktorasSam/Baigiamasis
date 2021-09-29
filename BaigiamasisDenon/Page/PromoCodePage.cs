using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDenon.Page
{
    public class PromoCodePage : BasePage
    {
        private const string _pageAddress = "https://www.denonsalonai.lt/";
        private const string _promoCode = "02DS8245";
        private const string _expectedResult = "-5.00%";

        private IWebElement _popup => Driver.FindElement(By.CssSelector("#webform_preview > div"));
        private IWebElement _navigateToHeadphones => Driver.FindElement(By.CssSelector("#content > div.tvcmscategory-slider.container-fluid > div > div.tvcategory-slider-inner-info-box > div > div.owl-stage-outer > div > div:nth-child(4) > div"));
        private IWebElement _selectItem => Driver.FindElement(By.CssSelector("#js-product-list > div > div.products > article:nth-child(1) > div > div.tvproduct-wrapper.grid > div.tvproduct-image > a > img.tvproduct-hover-img.lazy.loaded"));
        private IWebElement _addToBasket => Driver.FindElement(By.CssSelector("#add-to-cart-or-refresh > div.product-add-to-cart > div.tvwishlist-compare-wrapper-page > div > button"));
        private IWebElement _moveToBasket => Driver.FindElement(By.CssSelector("#blockcart-modal > div > div > div.modal-body.tv-addtocart-content-part > div > div.col-md-6.tv-addtocart-content > div > div > a"));
        private IWebElement _promoCodeQuestion => Driver.FindElement(By.CssSelector("#main > div > div.cart-grid-right.col-xs-12.col-lg-4 > div.card.cart-summary > div.cart-detailed-totals > div.block-promo > div > p > a"));
        private IWebElement _promoCodeEntry => Driver.FindElement(By.CssSelector("#promo-code > form > input.promo-input"));
        private IWebElement _clickPromoCode => Driver.FindElement(By.CssSelector("#promo-code > form > button"));
        private IWebElement _actualPromoCodeResult => Driver.FindElement(By.CssSelector("#main > div > div.cart-grid-right.col-xs-12.col-lg-4 > div.card.cart-summary > div.cart-detailed-totals > div.block-promo > div > div > ul > li > div"));
        public PromoCodePage(IWebDriver webDriver) : base(webDriver) { }


        public PromoCodePage NavigateToDefaultPage()
        {
            if (Driver.Url != _pageAddress)
            {
                Driver.Url = _pageAddress;
            }
            return this;
        }

        public PromoCodePage SwitchToFrame()
        {
            Driver.SwitchTo().Frame(0);

            return this;
        }

        public PromoCodePage ClosePopup()
        {
            _popup.Click();

            return this;
        }

        public PromoCodePage SwitchToDefault()
        {
            Driver.SwitchTo().DefaultContent();

            return this;
        }

        public PromoCodePage NavigateToHeadphones()
        {
            //_navigateToHeadphones.Click();
            Driver.Navigate().GoToUrl("https://www.denonsalonai.lt/21-ausines");
            return this;
        }
        public PromoCodePage Wait()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return this;
        }

        public PromoCodePage SelectItem()
        {
            _selectItem.Click();

            return this;
        }
        public PromoCodePage AddToBasket()
        {
            _addToBasket.Click();

            return this;
        }
        public PromoCodePage MoveToBasket()
        {
            _moveToBasket.Click();

            return this;
        }
        public PromoCodePage ClickPromoCodeQuestion()
        {
            _promoCodeQuestion.Click();

            return this;
        }
        public PromoCodePage EnterPromoCode()
        {
            _promoCodeEntry.Clear();
            _promoCodeEntry.SendKeys(_promoCode);

            return this;
        }

        public PromoCodePage ClickToAddPromoCode()
        {
            _clickPromoCode.Click();

            return this;
        }

        public PromoCodePage VerifyPomoCode()
        {
            Assert.AreEqual(_expectedResult, _actualPromoCodeResult.Text, "Entered wrong promo code");

            return this;
        }

    }
}
