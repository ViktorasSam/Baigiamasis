using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDenon.Test
{
    public class SearchAndSortTest : BaseTest
    {
        [Test]
        public static void SearchFieldAndsort()
        {
            _searchAndSort
                .NavigateToDefaultPage()
                .SwitchToFrame()
                .ClosePopup()
                .SwitchToDefault()
                .Wait()
                .SearchFieldInputAndFind()                
                .CheckProductAvailability()
                .DropDownSelect()
                .SelectFromDropDown()
                .PickCheapestItemFromList()
                .CheckIfAvailable();
        }
    }
}
