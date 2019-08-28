using OpenQA.Selenium;
using System;

namespace Horse_Dev
{
    internal class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement UserName => driver.FindElement(By.Id("UserName"));
        IWebElement Password => driver.FindElement(By.Id("Password"));
        IWebElement LoginButton => driver.FindElement(By.XPath("//input[@value='Log in']"));

        public void SetUserName(String USN)
        {
            UserName.SendKeys(USN);
        }

        public void SetPassword(String pwrd)
        {
            Password.SendKeys(pwrd);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }
        
        internal void LoginSuccess(String Username, String password)
        {
            SetUserName(Username);
            SetPassword(password);
            ClickLogin();
        }
    }
}