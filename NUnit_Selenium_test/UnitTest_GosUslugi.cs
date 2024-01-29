using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NUnit_Selenium_test
{
    public class Tests_GosUslugi
    {
        private IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            var pathChrome = new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver(pathChrome);
        }

        [Test]
        public async Task TestGosUslugi()
        {
            driver.Navigate().GoToUrl("https://www.gosuslugi.ru/");
            IWebElement loginButton = Utils.WaitElementForVisible(driver, By.CssSelector("button.login-button"));
            loginButton.Click();

            IWebElement recoverButton1 = Utils.WaitElementForVisible(driver, By.XPath("//button[text()=' Не удаётся войти? ']"));
            recoverButton1.Click();
            IWebElement recoverButton2 = Utils.WaitElementForVisible(driver, By.XPath("//button[text()=' восстановления пароля ']"));
            recoverButton2.Click();

            IWebElement recoverHeader = Utils.WaitElementForVisible(driver, By.XPath("//h3[text()=' Восстановление пароля ']"));

            Assert.IsTrue(recoverHeader != null);
        }
        [TearDown]
        public void TeardownBrowser()
        {
            driver.Close();
        }
    }
}