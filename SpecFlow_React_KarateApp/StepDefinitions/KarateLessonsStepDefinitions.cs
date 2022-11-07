using SpecFlow_React_KarateApp.PageObjects;
using SpecFlowCalculator.Specs.Drivers;



namespace SpecFlow_React_KarateApp.StepDefinitions
{
    [Binding]
    public class KarateLessonsStepDefinitions
    {

        private readonly KarateLessonsPageObject _karateLessonsPageObject;
        private readonly HomePageObject _homePageObject;
        private readonly LoginPageObject _loginPageObject;

        public KarateLessonsStepDefinitions(SeleniumDriver driver)
        {
            _karateLessonsPageObject = new KarateLessonsPageObject(driver.Current);
            _homePageObject = new HomePageObject(driver.Current);
            _loginPageObject = new LoginPageObject(driver.Current);

        }
        [Given(@"Bob is logged in")]
        public void GivenBobIsLoggedIn()
        {
            _homePageObject.navigateLogin();
            _loginPageObject.fillEmail("react_test@test.com");
            _loginPageObject.fillPassword("test1234");
            _loginPageObject.clickLogin();
        }

        [When(@"Bob clicks on the Lessons tab")]
        public void WhenBobClicksOnTheLessonsTab()
        {
            _karateLessonsPageObject.clickLessons();
        }

        [Then(@"The application navigates to the lesson list")]
        public void ThenTheApplicationNavigatesToTheLessonList()
        {
            _karateLessonsPageObject.checkLessonsTitle().Should().NotBeNullOrEmpty();
        }

        [Then(@"The first lesson is Expired")]
        public void ThenTheFirstLessonIsExpired()
        {
            var title = _karateLessonsPageObject.firstLessonExpired();
            title.Should().Contain("Expired");
        }
    }
}
