using SpecFlow_React_KarateApp.PageObjects;
using SpecFlowCalculator.Specs.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow_React_KarateApp.StepDefinitions
{
    [Binding]
    public class NavigationUnknownUserStepDefinitions
    {
        private readonly HomePageObject _homePageObject;
        private bool navigationResult;

        public NavigationUnknownUserStepDefinitions(SeleniumDriver driver)
        {
            _homePageObject = new HomePageObject(driver.Current);

        }


        [When(@"\[Bob clicks on the app name in the navigation bar]")]
        public void WhenBobClicksOnTheAppNameInTheNavigationBar()
        {
            navigationResult = _homePageObject.navigateHome();
        }

        [Then(@"\[Bob is navigated to the home page]")]
        public void ThenBobIsNavigatedToTheHomePage()
        {
            navigationResult.Should().BeTrue();
        }

        [Given(@"\[Bob is on the home page]")]
        public void GivenBobIsOnTheHomePage()
        {
            _homePageObject.navigateHome();
        }

        [When(@"\[Bob clicks on the Login setting]")]
        public void WhenBobClicksOnTheLoginSetting()
        {
            navigationResult = _homePageObject.navigateLogin();
        }

        [Then(@"\[Bob is navigated to the login page]")]
        public void ThenBobIsNavigatedToTheLoginPage()
        {
            navigationResult.Should().BeTrue();
        }

        [When(@"\[Bob clicks on the Lessons button in the navigation bar]")]
        public void WhenBobClicksOnTheLessonsButtonInTheNavigationBar()
        {
            navigationResult = _homePageObject.navigateLessons();
        }

        [Then(@"\[Bob is not navigated to the Lessons page]")]
        public void ThenBobIsNotNavigatedToTheLessonsPage()
        {
            navigationResult.Should().BeFalse();
        }

        [When(@"\[Bob clicks on the Users button in the navigation bar]")]
        public void WhenBobClicksOnTheUsersButtonInTheNavigationBar()
        {
            navigationResult = _homePageObject.navigateUsers();
        }

        [Then(@"\[Bob is not navigated to the Users page]")]
        public void ThenBobIsNotNavigatedToTheUsersPage()
        {
            navigationResult.Should().BeFalse();
        }

        [Then(@"\[Bob is automatically navigated to the login page]")]
        public void ThenBobIsAutomaticallyNavigatedToTheLoginPage()
        {
            _homePageObject.checkNavigateLogin().Should().BeTrue();
        }

    }
}
