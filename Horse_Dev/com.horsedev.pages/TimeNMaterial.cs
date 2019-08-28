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
        internal void ClickOnCreateNew()
        {
            CreateNew.Click();
        }
        internal void CreateNewItem(string code, string desc, string price, string TypeCode)
        {

            CreateNew.Click();
            IWebElement dropDown = driver.FindElement(By.XPath("//span[@role=\"listbox\"] //span[@class=\"k-icon k-i-arrow-s\"]"));
            dropDown.Click();
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

        
        internal void DeleteItem(string code)
        {
            Thread.Sleep(3000);
            while (true)
            {
                for (int i = 1; i <= 10; i++)
                {
                    IWebElement VerifyCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]"));
                    if (VerifyCode.Text == code)
                    {
                        IWebElement DeleteBtn = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[5]/a[2]"));
                        DeleteBtn.Click();
                        driver.SwitchTo().Alert().Accept();
                        return;
                    }
                }

                if (GoToNext.Enabled)
                {
                    IWebElement GoToNextPage = driver.FindElement(By.XPath("//a[@title='Go to the next page']"));
                    GoToNextPage.Click();
                }
            }
        }

    }

}