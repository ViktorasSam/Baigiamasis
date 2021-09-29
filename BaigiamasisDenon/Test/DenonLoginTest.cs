using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDenon.Test
{
    public class DenonLoginTest : BaseTest
    {
        [Test]
        public static void LoginTest()
        {
            _denonLoginPage
                .NavigateToLoginPage()
                .InsertLoginName()
                .InsertLoginPassword()
                .ClickLoginButton()
                .PressLoginInfoButton()
                .VerifyLoginName();

        }

    }
}
