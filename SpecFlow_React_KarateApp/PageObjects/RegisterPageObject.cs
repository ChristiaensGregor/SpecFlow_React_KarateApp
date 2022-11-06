using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow_React_KarateApp.PageObjects
{
    internal class RegisterPageObject
    {
        private const string registerUrl = "http://localhost:3000/Register";
        private readonly IWebDriver _webDriver;
        public const int DefaultWaitInSeconds = 5;

        public RegisterPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Navigate().GoToUrl(registerUrl);
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

        private IWebElement register_mail => _webDriver.FindElement(By.Id("email"));
        private IWebElement register_password => _webDriver.FindElement(By.Id("password"));
        private IWebElement register_register => _webDriver.FindElement(By.Id("register_register"));
        
        public void fillEmail(string mail)
        {
            register_mail.SendKeys(mail);
            Thread.Sleep(1000);
        }

        public void fillPassword(string password)
        {
            register_password.SendKeys(password);
            Thread.Sleep(1000);

        }

        public void clickRegister()
        {
            register_register.Click();
            Thread.Sleep(1000);
        }


    }
}
