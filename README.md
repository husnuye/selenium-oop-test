# selenium-oop-test
# 🧪 Selenium OOP Test Automation Project

A professional test automation framework built with C# using Selenium WebDriver and NUnit. This project demonstrates clean architecture, OOP principles, and Allure reporting integration. It includes modular page objects and test scenarios like login, logout, and checkout flows.

---

## 🚀 Technologies & Tools

- ✅ C# (.NET 8)
- ✅ Selenium WebDriver
- ✅ NUnit
- ✅ Allure Report
- ✅ GitHub Actions CI
- ✅ ChromeDriver
- ✅ Page Object Model (POM)
- ✅ Git + GitHub

---

## 🧩 Folder Structure
SeleniumOOPTest/
│
├── Base/                  → Test base and reusable logic
├── Pages/                 → Page Object classes (Login, Home, Checkout, Logout)
├── Tests/                 → Test classes
├── Utils/                 → Config reader, Driver factory
├── .github/workflows/     → CI config with Allure report
├── appsettings.json       → Base URL & configuration
├── README.md              → You are here!
└── run-tests.sh           → Bash script for local test runs

---

## 📋 How to Run Locally

```bash
# Optional: Kill existing Chrome sessions
pkill -f chromedriver
pkill -f "Google Chrome"

# Then run:
./run-tests.sh

🧪 Sample Test Scenarios
	•	✅ Login with valid credentials
	•	✅ Logout and redirection to login page
	•	✅ Add item to cart and complete checkout

⸻

### 📈 Allure Report (GitHub Actions)

View the latest Allure Report from GitHub Actions:  
👉 **[Click here to see the Allure Report](https://husnuye.github.io/selenium-oop-test/)**

✅ GitHub Actions automatically generates this report on every `main` branch push.

⸻

💡 CI Integration

This project includes full CI/CD with GitHub Actions.
	•	Runs on every main branch push
	•	Builds the project
	•	Executes tests
	•	Publishes Allure Report to GitHub Pages
	•	(Optional) Stores Allure as artifact

⸻

👤 Author

Husnuye Yasar
Test Automation Engineer
🌐 GitHub: husnuye

⸻

📄 License

MIT License
