using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse_Dev.com.hordev.common
{
    public class BaseClass
    {
       internal IWebDriver driver;

        public IWebDriver Initialize()
        {
            driver = new ChromeDriver(); //research about global driver or browser factory 
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
