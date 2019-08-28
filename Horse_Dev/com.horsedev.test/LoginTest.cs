using Horse_Dev.com.hordev.common;
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
    class LoginPageTest : BaseClass

    {
        IWebDriver driver;
        LoginPage LP;
        //[SetUp]
        public void BeforeMethod()
        {
            driver = Initialize();
            LP = new LoginPage (driver);
        }

        //[Test]
        public void LoginTest()
        {
            LP.SetUserName("hari");
            LP.SetPassword("123123");
            LP.ClickLogin();
        }

        //[TearDown]
        public void AfterMethod()
        {
            driver.Quit();
        }

    }
}
