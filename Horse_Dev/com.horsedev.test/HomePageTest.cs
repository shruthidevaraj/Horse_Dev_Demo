using Horse_Dev.com.hordev.common;
using Horse_Dev.com.horsedev.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse_Dev.com.horsedev.test
{
    class HomePageTest : BaseClass
    {
        IWebDriver driver;
        LoginPage LgnPage;
        HomePage HPage;
                
        [SetUp]
        public void BeforeMethod()
        {
         driver= Initialize();
         LgnPage = new LoginPage(driver);
         LgnPage.LoginSuccess("hari","123123");
         HPage = new HomePage(driver);

        }

        public void Test1()
        {

        }
        [TearDown]
        public void AfterMethod()
        {
            driver.Quit();
        }
    }
}
