using OpenQA.Selenium;
using SeleniumOOPTest.Base;

namespace SeleniumOOPTest.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        // Locators
        private By usernameField => By.Id("user-name");
        private By passwordField => By.Id("password");
        private By loginButton => By.Id("login-button");

        // Methods
        public void Login(string username, string password)
        {
            EnterText(usernameField, username);
            EnterText(passwordField, password);
            Click(loginButton);
        }
    }
}
