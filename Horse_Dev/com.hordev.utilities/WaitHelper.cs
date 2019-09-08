using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse_Dev.com.hordev.utilities
{
    class WaitHelper
    {
        
        public static void ElementVisible(IWebDriver driver, String element, String locatorType)
        {
            try
            {
                if (locatorType == "xpath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                    IWebElement Element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(element)));
                }else if (locatorType == "className")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                    IWebElement Element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(element)));
                }
                else if(locatorType == "id")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                    IWebElement Element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(element)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
