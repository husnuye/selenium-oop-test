using OpenQA.Selenium;
using SeleniumOOPTest.Base;

namespace SeleniumOOPTest.Pages
{
    public class LogoutPage : BasePage
    {
        public LogoutPage(IWebDriver driver) : base(driver) { }

        // Menü butonu
        private By menuButton => By.Id("react-burger-menu-btn");

        // Logout linki
        private By logoutLink => By.Id("logout_sidebar_link");

        // Logout sonrası mesaj (isteğe bağlı kullanılabilir)
        private By logoutMessage => By.XPath("//*[contains(text(), 'Logged Out Successfully')]");

        public void Logout()
        {
            Click(menuButton);
            WaitForElementVisible(logoutLink, 5);
            Click(logoutLink);
        }

        public string GetLogoutMessage()
        {
            return WaitForElementVisible(logoutMessage).Text;
        }
    }
}