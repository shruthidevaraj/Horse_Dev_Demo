using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse_Dev.com.hordev.common
{
    class BaseClass
    {
        IWebDriver driver;

        public IWebDriver Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
