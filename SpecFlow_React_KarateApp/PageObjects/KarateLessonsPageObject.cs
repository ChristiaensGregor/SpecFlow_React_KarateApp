using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace SpecFlow_React_KarateApp.PageObjects
{
    internal class KarateLessonsPageObject
    {

        private const string karateLessonsUrl = "http://localhost:3000/";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public KarateLessonsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Navigate().GoToUrl(karateLessonsUrl);
        }

        private IWebElement lessonsButton => _webDriver.FindElement(By.Id("LessonsId"));
        private IWebElement lessonsTitle => _webDriver.FindElement(By.Id("listLessonsTitle"));

        private IWebElement firstLessonTitle => _webDriver.FindElement(By.Id("KarateLessonStandard04102022Id"));
        public String title => firstLessonTitle.Text; 


        public Boolean pageLoads() {
            return true;
        }

        public void clickLessons() {
            lessonsButton.Click();
        }

        public Boolean lessonsLoads()
        {
            var title = lessonsTitle.GetAttribute("value");
            Debug.WriteLine("Value of lessonsTitle:");
            Debug.WriteLine(lessonsTitle.GetAttribute("value"));
            return lessonsTitle.Text == "List Lessons";
        }

        public String firstLessonExpired()
        {
            return WaitUntil(
                () => firstLessonTitle.Text,
                result => !string.IsNullOrEmpty(result));
        }

        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
