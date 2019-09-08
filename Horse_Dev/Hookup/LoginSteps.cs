using Horse_Dev.com.hordev.common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Horse_Dev.Hookup
{
    [Binding]
    public class LoginSteps : BaseClass
    {
        
        LoginPage LoginInstance;

        [Given(@"Launch the chrome browser and navigate to the portal")]
        public void GivenLaunchTheChromeBrowserAndNavigateToThePortal()
        {

            Initialize();
            Console.WriteLine("After initialize() method");
        }
        
        [When(@"I have entered a valid (.*) and (.*)")]
        public void WhenIHaveEnteredAValidAnd(string UserName, string Password)
        {
            LoginInstance = new LoginPage(driver);
            LoginInstance.SetUserName(UserName);
            LoginInstance.SetPassword(Password);
           
        }

        [When(@"click on login button")]
        public void WhenClickOnLoginButton()
        {
            LoginInstance.ClickLogin();
        }
        
        [Then(@"Login successfully and should be  on the Home page")]
        public void ThenLoginSuccessfullyAndShouldBeOnTheHomePage()
        {
            string userName = driver.FindElement(By.XPath(".//*[@id='logoutForm']/ul/li/a")).Text;
            Assert.AreEqual("Hello hari!", userName);
        }

        [When(@"User enter a invalid  (.*) and  (.*)")]
        public void WhenUserEnterAInvalidHariAnd(string username, string password)
        {
            LoginInstance = new LoginPage(driver);
            LoginInstance.SetUserName(username);
            LoginInstance.SetPassword(password);
            LoginInstance.ClickLogin();
        }

        [Then(@"Login should fail and stay on login page")]
        public void ThenLoginShouldFailAndStayOnLoginPage()
        {
            var ErrorMessage = driver.FindElement(By.XPath(".//*[@class ='validation-summary-errors']/ul/li")).Text;
            Console.WriteLine(ErrorMessage);
            Assert.AreEqual(ErrorMessage, "Invalid username or password.");
        }

        [AfterScenario]
        public void CloseDriver()
        {
            if(driver != null)
            {
                driver.Quit();
            }
        }
    }
}
