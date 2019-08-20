
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse_Dev
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            Login(driver);
            CreateNewItem(driver);
            driver.Quit();
        }

       
         static void Login(IWebDriver driver)
        {
            //Navigating to URL
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            
            //Identifying username web Elemwnt
            IWebElement UserName = driver.FindElement(By.Id("UserName"));
            UserName.SendKeys("hari");

            //Identifying password 
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            //Identifying Login button
            IWebElement LoginButton = driver.FindElement(By.XPath("//input[@value='Log in']"));
            LoginButton.Click();
        }

        static void CreateNewItem(IWebDriver driver)
        {
            //Clicking on the Administration
            IWebElement Admistration = driver.FindElement(By.XPath("//div[3]//ul//li[5]//a[@role=\"button\"]"));
            Admistration.Click();

            driver.FindElement(By.XPath("//a[contains(text(), 'Time & Materials')]")).Click();

            IWebElement CreateNew = driver.FindElement(By.CssSelector("a[class='btn btn-primary']"));
            CreateNew.Click();

            //Finding code WebElement and Sending Code
            IWebElement Code = driver.FindElement(By.Id("Code"));
            Code.SendKeys("CODE12");

            //Finding the description webElement and passing some description
            IWebElement Description = driver.FindElement(By.Id("Description"));
            Description.SendKeys("Materials");

            //Finding the PricePerUnit webElement 
            IWebElement PricePerUnit = driver.FindElement(By.CssSelector("input[class=\"k-formatted-value k-input\"]"));
            PricePerUnit.SendKeys("20");

            //Clicking on save button
            IWebElement Save = driver.FindElement(By.Id("SaveButton"));
            Save.Click();
        }
    }
}
