using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumOOPTest.Utils
{
    public class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();

            // Tarayıcıyı tam ekran aç
            options.AddArgument("--start-maximized");
            options.AddArgument("--incognito"); // Yeni, temiz bir oturum
            options.AddArgument("--headless");  // Arka planda çalıştırmak için

            // Güvenlik ve performans iyileştirmeleri
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--remote-debugging-port=9222");

            // Her test için ayrı bir kullanıcı profili (çakışmaları önler)
            options.AddArgument($"--user-data-dir=/tmp/chrome-profile-{Guid.NewGuid()}");

            // 🔐 Şifre yöneticisi ve popup'ları kapat
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2); // Bildirimleri engelle

            return new ChromeDriver(options);
        }
    }
}