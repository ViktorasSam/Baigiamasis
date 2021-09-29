using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDenon.Test
{
    public class PromoCodeTest : BaseTest
    {
        [Test]
        public static void PromoCodeTesting()
        {
            _promoCodePage
                .NavigateToDefaultPage()
                .SwitchToFrame()
                .ClosePopup()
                .SwitchToDefault()
                .Wait()
                .NavigateToHeadphones()
                .SelectItem()                
                .AddToBasket()
                .MoveToBasket()
                .ClickPromoCodeQuestion()
                .EnterPromoCode()
                .ClickToAddPromoCode()
                .VerifyPomoCode();


        }
    }
}
