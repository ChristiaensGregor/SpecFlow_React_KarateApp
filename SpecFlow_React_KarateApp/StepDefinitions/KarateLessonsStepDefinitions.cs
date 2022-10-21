using SpecFlow_React_KarateApp.PageObjects;
using SpecFlowCalculator.Specs.Drivers;



namespace SpecFlow_React_KarateApp.StepDefinitions
{
    [Binding]
    public class KarateLessonsStepDefinitions
    {

        private readonly KarateLessonsPageObject _karateLessonsPageObject;

        public KarateLessonsStepDefinitions(SeleniumDriver driver)
        {
            _karateLessonsPageObject = new KarateLessonsPageObject(driver.Current);

        }

        [Given(@"Bob can access the KarateApp and the Lessons tab")]
        public void GivenBobCanAccessTheKarateAppAndTheLessonsTab()
        {
            _karateLessonsPageObject.pageLoads().Should().BeTrue();
        }

        [When(@"Bob clicks on the Lessons tab")]
        public void WhenBobClicksOnTheLessonsTab()
        {
            _karateLessonsPageObject.clickLessons();
        }

        [Then(@"The application navigates to the lesson list")]
        public void ThenTheApplicationNavigatesToTheLessonList()
        {
            _karateLessonsPageObject.lessonsLoads().Should().BeTrue();
        }

        [Then(@"The first lesson is Expired")]
        public void ThenTheFirstLessonIsExpired()
        {
            var title = _karateLessonsPageObject.firstLessonExpired();
            title.Should().Contain("Expired");
        }
    }
}
