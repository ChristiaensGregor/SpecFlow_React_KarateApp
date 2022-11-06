using SpecFlow_React_KarateApp.PageObjects;
using SpecFlowCalculator.Specs.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow_React_KarateApp.StepDefinitions
{
    [Binding]
    public class RegisterNewStandardUserStepDefinitions
    {

        private readonly RegisterPageObject _registerPageObject;

        public RegisterNewStandardUserStepDefinitions(SeleniumDriver driver)
        {
            _registerPageObject = new RegisterPageObject(driver.Current);
        }

        [Given(@"\[Alice is on the registration page]")]
        public void GivenAliceIsOnTheRegistrationPage()
        {
        }

        [When(@"\[Alice fills in her email address]")]
        public void WhenAliceFillsInHerEmailAddress()
        {
            _registerPageObject.fillEmail("specflow_test@test.com");
        }

        [When(@"\[Alice fills in her password]")]
        public void WhenAliceFillsInHerPassword()
        {
            _registerPageObject.fillPassword("test1234");
        }

        [When(@"\[Alice presses the register button]")]
        public void WhenAlicePressesTheRegisterButton()
        {
            _registerPageObject.clickRegister();
        }

        [Then(@"\[Alice is registered]")]
        public void ThenAliceIsRegistered()
        {
        }

        [Then(@"\[Alice is redirected to the home page]")]
        public void ThenAliceIsRedirectedToTheHomePage()
        {
        }
    }
}
