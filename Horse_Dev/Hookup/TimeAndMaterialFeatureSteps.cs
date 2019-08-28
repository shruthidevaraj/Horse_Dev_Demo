using Horse_Dev.com.horsedev.pages;
using Horse_Dev.com.hordev.common;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace Horse_Dev.Hookup
{
    [Binding]
    public class TimeAndMaterialFeatureSteps
    {
        IWebDriver driver;
        LoginPage LP;
        HomePage HPage;
        TimeNMaterial TnM;

        [Given(@"I have Lgged in to the portal")]
        public void GivenIHaveLggedInToThePortal()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            LP = new LoginPage(driver);
            LP.LoginSuccess("hari", "123123");
           
        }
        
        [Given(@"I have to navigate to Time and material page")]
        public void GivenIHaveToNavigateToTimeAndMaterialPage()
        {
           
            HPage.ClickOnAdministration();
            TnM.ClickTimenMaterial();
            TnM.ClickOnCreateNew();
          }
        
        [Then(@"I should be able to create time and material sucessfully")]
        public void ThenIShouldBeAbleToCreateTimeAndMaterialSucessfully()
        {
           // TnM.CreateNewItem("Code123", "Description Code 123", "40", "Time");
            IWebElement dropDown = driver.FindElement(By.XPath("//span[@role=\"listbox\"] //span[@class=\"k-icon k-i-arrow-s\"]"));
            dropDown.Click();
            List<IWebElement> DropDownList = new List<IWebElement>(driver.FindElements(By.XPath("//ul[contains(@id,'TypeCode_listbox')]//li")));

            for (int i = 0; i < DropDownList.Count; i++)
            {

                if (DropDownList[i].Text == "Time")
                {
                    DropDownList[i].Click();
                }
            }
            TnM.SetCode("Code123");
            TnM.SetDescription("Description Code 123");
            TnM.SetPricePerUnit("10000");
            TnM.ClickOnSave(); ;
        }
    }
}
