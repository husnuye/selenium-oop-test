using OpenQA.Selenium;

namespace SeleniumOOPTest.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Username => driver.FindElement(By.Id("username"));
        private IWebElement Password => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("submit"));




        public void Login(string username, string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            LoginButton.Click();
        }
    }
}
