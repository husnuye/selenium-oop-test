using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumOOPTest.Base
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        // ✅ Element görünene kadar bekle
        public IWebElement WaitForElementVisible(By locator, int timeout = 60)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // ✅ Element tıklanabilir olana kadar bekle
        public IWebElement WaitUntilClickable(By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        // ✅ Element DOM'da var olana kadar bekle
        public IWebElement WaitUntilExists(By locator)
        {
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }

        // ✅ Sayfa başlığını kontrol et
        public bool IsPageTitle(string expectedTitle)
        {
            return driver.Title.Contains(expectedTitle);
        }

        // ✅ Belirli bir URL içeriyor mu kontrol et
        public bool WaitUntilUrlContains(string partialUrl)
        {
            return wait.Until(ExpectedConditions.UrlContains(partialUrl));
        }

        // ✅ Elementin içinde belirli bir metin var mı?
        public bool WaitUntilTextPresent(By locator, string text)
        {
            return wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        // ✅ Click işlemi
        public void Click(By locator)
        {
            WaitUntilClickable(locator).Click();
        }

        // ✅ Text gönderme
        public void EnterText(By locator, string text)
        {
            var element = WaitForElementVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        // ✅ JavaScript ile tıklama
        public void JsClick(By locator)
        {
            var element = WaitForElementVisible(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        // ✅ Sayfa aşağı kaydırma
        public void ScrollToElement(By locator)
        {
            var element = WaitForElementVisible(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        // ✅ Dropdown: Select by Text
        public void SelectByText(By locator, string visibleText)
        {
            var element = WaitForElementVisible(locator);
            new SelectElement(element).SelectByText(visibleText);
        }

        // ✅ Dropdown: Select by Value
        public void SelectByValue(By locator, string value)
        {
            var element = WaitForElementVisible(locator);
            new SelectElement(element).SelectByValue(value);
        }

        // ✅ Hover işlemi
        public void HoverOverElement(By locator)
        {
            var element = WaitForElementVisible(locator);
            new Actions(driver).MoveToElement(element).Perform();
        }

        // ✅ Element görünür mü?
        public bool IsElementDisplayed(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
