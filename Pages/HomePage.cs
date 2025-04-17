using OpenQA.Selenium;
using SeleniumOOPTest.Base;

namespace SeleniumOOPTest.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        private By inventoryContainer => By.Id("inventory_container");

        public bool IsInventoryDisplayed()
        {
            return IsElementDisplayed(inventoryContainer);
        }
    }
}
