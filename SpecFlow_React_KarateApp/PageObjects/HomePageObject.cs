using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow_React_KarateApp.PageObjects
{
    internal class HomePageObject
    {
        private const string homeUrl = "http://localhost:3000/";
        private readonly IWebDriver _webDriver;
        public const int DefaultWaitInSeconds = 5;
        public HomePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Navigate().GoToUrl(homeUrl);
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

        private IWebElement navigation_Home => _webDriver.FindElement(By.Id("navigation_Home"));
        private IWebElement navigation_Lessons => _webDriver.FindElement(By.Id("navigation_Lessons"));
        private IWebElement navigation_Users => _webDriver.FindElement(By.Id("navigation_Users"));
        private IWebElement navigation_Settings => _webDriver.FindElement(By.Id("navigation_Settings"));
        //private IWebElement navigation_Settings => _webDriver.FindElement(By.Id("menu-appbar"));
        private IWebElement navigation_Settings_Theme => _webDriver.FindElement(By.Id("navigation_Setting_Theme"));
        private IWebElement navigation_Settings_Login => _webDriver.FindElement(By.Id("navigation_Setting_Login"));
        private IWebElement navigation_Settings_Logout => _webDriver.FindElement(By.Id("navigation_Setting_Logout"));

        public bool navigateHome()
        {
            navigation_Home.Click();
            string url = _webDriver.Url.ToString();
            Thread.Sleep(1000);
            return url == "http://localhost:3000/";
        }

        public bool navigateLessons()
        {
            navigation_Lessons.Click();
            string url = _webDriver.Url.ToString();
            Thread.Sleep(1000);
            return url == "http://localhost:3000/Lessons";
        }

        public bool navigateUsers()
        {
            navigation_Users.Click();
            string url = _webDriver.Url.ToString();
            Thread.Sleep(1000);
            return url == "http://localhost:3000/Users";
        }

        public bool navigateLogin()
        {
            navigation_Settings.Click();
            Thread.Sleep(500);
            navigation_Settings_Login.Click();
            string url = _webDriver.Url.ToString();
            Thread.Sleep(1000);
            return url == "http://localhost:3000/Login";
        }

        public bool checkNavigateLogin()
        {
            string url = _webDriver.Url.ToString();
            Debug.WriteLine(url);
            return url == "http://localhost:3000/login";
        }
    }
}
