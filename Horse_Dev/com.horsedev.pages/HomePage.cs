using OpenQA.Selenium;
using System;
using System.Threading;

namespace Horse_Dev
{
    internal class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement Admistration => driver.FindElement(By.XPath("//div[3]//ul//li[5]//a[@role=\"button\"]"));


        public void ClickOnAdministration() {
          
            Admistration.Click();
        }

    }
}