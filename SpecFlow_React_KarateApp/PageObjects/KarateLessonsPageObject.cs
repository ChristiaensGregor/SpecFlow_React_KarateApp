using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace SpecFlow_React_KarateApp.PageObjects
{
    internal class KarateLessonsPageObject
    {

        private const string karateLessonsUrl = "http://localhost:3000/Lessons";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public KarateLessonsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Navigate().GoToUrl(karateLessonsUrl);
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

        private IWebElement lessonsButton => _webDriver.FindElement(By.Id("navigation_Lessons"));
        private IWebElement lessonsTitle => _webDriver.FindElement(By.Id("listLessonsTitle"));

        private IWebElement firstLessonTitle => _webDriver.FindElement(By.Id("KarateLessonStandard01112022"));
        public String title => firstLessonTitle.Text;

        public void clickLessons()
        {
            lessonsButton.Click();
        }

        public String checkLessonsTitle()
        {
            return WaitUntil(
                () => lessonsTitle.Text, 
                result => !string.IsNullOrEmpty(result));
        }

        public String firstLessonExpired()
        {
            return WaitUntil(
                () => firstLessonTitle.Text,
                result => !string.IsNullOrEmpty(result));
        }
    }
}
