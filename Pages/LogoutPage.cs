using OpenQA.Selenium;

namespace SeleniumOOPTest.Pages
{
    public class LogoutPage
    {
        private readonly IWebDriver driver;

        public LogoutPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public IWebElement LogoutMessage => driver.FindElement(By.XPath("//h1[contains(text(), 'Logged In Successfully')]"));
        

        public string GetLogoutMessage()
        {
            return LogoutMessage.Text;
        }
    }
}