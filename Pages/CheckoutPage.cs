using OpenQA.Selenium;
using SeleniumOOPTest.Base;
using System;

namespace SeleniumOOPTest.Pages
{
    public class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver) { }

        private By firstNameField => By.Id("first-name");
        private By lastNameField => By.Id("last-name");
        private By postalCodeField => By.Id("postal-code");
        private By continueButton => By.Id("continue");
        private By finishButton => By.Id("finish");
        private By successMessage => By.ClassName("complete-header");

        public void FillCheckoutInformation(string firstName, string lastName, string postalCode)
        {
            EnterText(firstNameField, firstName);
            EnterText(lastNameField, lastName);
            EnterText(postalCodeField, postalCode);
        }

        public void ClickContinue()
        {
            Click(continueButton);
        }

        public void ClickFinish()
        {
            Click(finishButton);
        }

        public bool IsCheckoutComplete()
        {
            return IsElementDisplayed(successMessage);
        }

        //  Eğer "OK" popup'ı varsa kapat
        public void ClosePopupIfExists()
        {
            try
            {
                var popup = driver.FindElement(By.XPath("//button[text()='OK']"));
                if (popup.Displayed)
                    popup.Click();
            }
            catch (NoSuchElementException)
            {
                // Popup yoksa bir şey yapma
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Popup kontrol hatası: {ex.Message}");
            }
        }
    }
}