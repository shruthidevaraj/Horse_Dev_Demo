using Horse_Dev.com.hordev.common;
using Horse_Dev.com.horsedev.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Horse_Dev.com.horsedev.test
{
    class TimeNMaterialTest : BaseClass
    {
        IWebDriver driver;
        LoginPage LP;
        HomePage HPage;
        TimeNMaterial TnM;

        [SetUp]
        public void BeforeMethod()
        {
            driver = Initialize();
            LP = new LoginPage(driver);
            LP.LoginSuccess("hari", "123123");
            HPage = new HomePage(driver);
            TnM = new TimeNMaterial(driver);
        }

        [Test]
        public void AddItemTest()
        {
            HPage.ClickOnAdministration();
            TnM.ClickTimenMaterial();
            TnM.ClickOnCreateNew();
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
            TnM.SetCode("CODE1234");
            TnM.SetDescription("Description for Code 1234");
            TnM.SetPricePerUnit("100");
            TnM.ClickOnSave();
        }

        [Test]
        public void ValidateItemTest()
        {
            HPage.ClickOnAdministration();
            TnM.ClickTimenMaterial();
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            while (true)
            {
                for (int i = 1; i <= 10; i++)
                {
                    IWebElement VerifyCode = Wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]"))));
                    if (VerifyCode.Text == "CODE@")
                    {
                        Console.WriteLine("Code exists");
                        Assert.IsTrue(true);
                        return;
                    }
                }
                if (TnM.GoToNext.Enabled)
                {
                    IWebElement GoToNextPage = driver.FindElement(By.XPath("//a[@title='Go to the next page']"));
                    GoToNextPage.Click();
                }
            }
        }

        [Test]
        public void EditValidationTest()
        {
            HPage.ClickOnAdministration();
            TnM.ClickTimenMaterial();
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            while (true)
            {
                for (int i = 1; i <= 10; i++)
                {
                    IWebElement VerifyCode = Wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]"))));
                    if (VerifyCode.Text == "CODE@")
                    {
                        IWebElement EditBtn = driver.FindElement(By.XPath("(//a[contains(@class,'k-button k-button-icontext k-grid-Edit')])[" + i + "]"));
                        EditBtn.Click();
                        TnM.Code.Clear();
                        TnM.SetCode("CODE@");
                        TnM.Description.Clear();
                        TnM.SetDescription("New Description");
                        TnM.SetPricePerUnit("40");
                        TnM.ClickOnSave();
                        return;
                    }
                }
                if (TnM.GoToNext.Enabled)
                {
                    IWebElement GoToNextPage = driver.FindElement(By.XPath("//a[@title='Go to the next page']"));
                    GoToNextPage.Click();
                }
            }
        }

        [Test]
        public void DeleteItemTest()
        {
            HPage.ClickOnAdministration();
            TnM.ClickTimenMaterial();
            TnM.DeleteItem("test");
        }

        [TearDown]
        public void AfterMethod()
        {
            driver.Quit();
        }
    }
}
