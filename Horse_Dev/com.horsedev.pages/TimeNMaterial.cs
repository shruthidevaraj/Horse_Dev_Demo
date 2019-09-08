using Horse_Dev.com.hordev.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Horse_Dev.com.horsedev.pages
{
    class TimeNMaterial
    {
        IWebDriver driver;
        HomePage homePage;
        TimeNMaterial timeNMaterial;

        public TimeNMaterial(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal IWebElement TimenMaterial => driver.FindElement(By.XPath("//a[contains(text(), 'Time & Materials')]"));
        internal IWebElement CreateNew => driver.FindElement(By.CssSelector("a[class='btn btn-primary']"));
        internal IWebElement PricePerUnit => driver.FindElement(By.CssSelector("input[class=\"k-formatted-value k-input\"]"));
        internal IWebElement Code => driver.FindElement(By.Id("Code"));
        internal IWebElement Description => driver.FindElement(By.Id("Description"));
        internal IWebElement Save => driver.FindElement(By.Id("SaveButton"));
        internal IWebElement GoToNext => driver.FindElement(By.CssSelector("a[title='Go to the next page']"));


        internal void SetCode(string TMCode)
        {
            Code.SendKeys(TMCode);
        }
        internal void SetDescription(string Desc)
        {
            Description.SendKeys(Desc);
        }
        internal void SetPricePerUnit(string price)
        {
            PricePerUnit.SendKeys(price);
        }
        internal void ClickTimenMaterial()
        {
            TimenMaterial.Click();
        }
        internal void ClickOnSave()
        {
            Save.Click();
        }
       

        // Create Time and material record 
        internal void CreateNewRecord(string code, string desc, string price, string TypeCode)
        {
            CreateNew.Click();
            var dropDown = driver.FindElement(By.XPath("//span[@role=\"listbox\"] //span[@class=\"k-icon k-i-arrow-s\"]"));
            dropDown.Click();

            //Select the Typecode from the dropdown
            List<IWebElement> DropDownList = new List<IWebElement>(driver.FindElements(By.XPath("//ul[contains(@id,'TypeCode_listbox')]//li")));
            for (int i = 0; i < DropDownList.Count; i++)
            {
                if (DropDownList[i].Text == TypeCode)
                {
                    DropDownList[i].Click();
                }
            }
            Code.SendKeys(code);
            Description.SendKeys(desc);
            PricePerUnit.SendKeys(price);
            Save.Click();

        }

        //Checking the record is existing
        internal int ValidateRecord(string code)
        {
            homePage = new HomePage(driver);
            timeNMaterial = new TimeNMaterial(driver);
            homePage.ClickOnAdministration();
            timeNMaterial.ClickTimenMaterial();
            IWebElement VerifyCode = null;
            while (true)
            {
                for (int i = 1; i <= 10; i++)
                 {
                    //waiting for the element to be visible 
                    string waitingEle = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]";
                    WaitHelper.ElementVisible(driver, waitingEle, "xpath");
                    VerifyCode = driver.FindElement(By.XPath(waitingEle));

                    //check if the code is available in Tome and material 
                    if (VerifyCode.Text == code)
                    {
                        Console.WriteLine("Code exists");
                        return 1;
                    }
                }

                //Navigate to next page if 'nextpage' button is enabled
                if (timeNMaterial.GoToNext.Enabled)
                {
                    IWebElement GoToNextPage = driver.FindElement(By.XPath("//a[@title='Go to the next page']"));
                    GoToNextPage.Click();
                }
                else if(!timeNMaterial.GoToNext.Enabled && VerifyCode.Text!=code)
                {
                    return -1;
                }
            }
        }

        //Edit the existing record
        internal int EditRecord(string code, string NewCode, string Description, string Price, string TypeCode)
        {
            homePage.ClickOnAdministration();
            timeNMaterial.ClickTimenMaterial();
            IWebElement VerifyCode = null;


            while (true)
            {
                for (int i = 1; i <= 10; i++)
                {
                    //waiting for element to be available
                    string waitingEle = "(\"//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]\")";
                    WaitHelper.ElementVisible(driver, waitingEle, "xpath");
                    VerifyCode = driver.FindElement(By.XPath(waitingEle));

                    if (VerifyCode.Text == code)
                    {
                        IWebElement EditBtn = driver.FindElement(By.XPath("(//a[contains(@class,'k-button k-button-icontext k-grid-Edit')])[" + i + "]"));
                        EditBtn.Click();
                        timeNMaterial.Code.Clear();
                        timeNMaterial.SetCode(NewCode);
                        timeNMaterial.Description.Clear();
                        timeNMaterial.SetDescription(Description);
                        timeNMaterial.SetPricePerUnit(Price);
                        timeNMaterial.ClickOnSave();
                        return -1;
                    }
                }
                if (timeNMaterial.GoToNext.Enabled)
                {
                    IWebElement GoToNextPage = driver.FindElement(By.XPath("//a[@title='Go to the next page']"));
                    GoToNextPage.Click();
                }
                else if (!timeNMaterial.GoToNext.Enabled && VerifyCode.Text != code)
                {
                    return -1;
                }
            }
        }

        //Deleting the time and material record
        internal int DeleteRecord(string code)
        {            
            IWebElement VerifyCode = null;
            while (true)
            {
                for (int i = 1; i <= 10; i++)
                {
                    string waitingEle = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]";
                    WaitHelper.ElementVisible(driver, waitingEle, "xpath");
                    VerifyCode = driver.FindElement(By.XPath(waitingEle));
                    if (VerifyCode.Text == code)
                    {
                        IWebElement DeleteBtn = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[5]/a[2]"));
                        DeleteBtn.Click();
                        driver.SwitchTo().Alert().Accept();
                        return 1;
                    }
                }

                if (timeNMaterial.GoToNext.Enabled)
                {
                    IWebElement GoToNextPage = driver.FindElement(By.XPath("//a[@title='Go to the next page']"));
                    GoToNextPage.Click();
                }
                else if (!timeNMaterial.GoToNext.Enabled && VerifyCode.Text != code)
                {
                    return -1;
                }

            }
        }

    }

}