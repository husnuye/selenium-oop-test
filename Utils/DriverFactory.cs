using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumOOPTest.Utils
{
    public class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--headless"); // headless mod
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--remote-debugging-port=9222");
            options.AddArgument($"--user-data-dir=/tmp/chrome-profile-{Guid.NewGuid()}");
            
            return new ChromeDriver(options);
        }
    }
}
