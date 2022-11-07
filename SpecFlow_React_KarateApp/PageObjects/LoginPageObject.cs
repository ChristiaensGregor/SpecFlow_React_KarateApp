using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow_React_KarateApp.PageObjects
{
    internal class LoginPageObject
    {
        private const string loginUrl = "http://localhost:3000/Login";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public LoginPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Navigate().GoToUrl(loginUrl);
        }
        private T? WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });
        }
        private IWebElement login_mail => _webDriver.FindElement(By.Id("email"));
        private IWebElement login_password => _webDriver.FindElement(By.Id("password"));
        private IWebElement login_register_prompt => _webDriver.FindElement(By.Id("login_register_prompt"));
        private IWebElement login_login_button => _webDriver.FindElement(By.Id("login_login"));

        public void fillEmail(string mail)
        {
            login_mail.SendKeys(mail);
            Thread.Sleep(1000);
        }

        public void fillPassword(string password)
        {
            login_password.SendKeys(password);
            Thread.Sleep(1000);

        }

        public void clickLogin()
        {
            login_login_button.Click();
            Thread.Sleep(2000);
        }

        public void navigateRegister()
        {
            login_register_prompt.Click();
            Thread.Sleep(1000);
        }
    }
}
