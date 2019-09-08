
using Horse_Dev.com.hordev.common;
using Horse_Dev.com.hordev.utilities;
using Horse_Dev.com.horsedev.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Horse_Dev.Hookup
{
    [Binding]
    public class TimeAndMaterialFeatureSteps : Steps
    {
        IWebDriver driver;
        LoginPage loginInstance;
        HomePage homepInstace;
        TimeNMaterial timeNMaterial;
        BaseClass baseInstance = null;
        ExcelDataUtil DataUtil;

        [Given(@"I have Logged into the portal")]
        public void GivenIHaveLggedInToThePortal()
        {

            baseInstance = new BaseClass();
            driver = baseInstance.Initialize();
            loginInstance = new LoginPage(driver);
            loginInstance.LoginTest("hari", "123123");
            DataUtil = new ExcelDataUtil();
           
        }

       
        [Given(@"I have to navigate to Time and material page")]
        public void GivenIHaveToNavigateToTimeAndMaterialPage()
        {
            homepInstace = new HomePage(driver);
            timeNMaterial = new TimeNMaterial(driver);
            homepInstace.ClickOnAdministration();
            timeNMaterial.ClickTimenMaterial();
        }

        
        [Then(@"I should be able to create time and material sucessfully")]
        public void ThenIShouldBeAbleToCreateTimeAndMaterialSucessfully()
        {
            DataUtil.GetDataInCollection("C:\\Users\\Shruthi Devaraj\\Desktop\\Me\\TimeAndMaterialTestData.xlsx", "TimeAndMaterial");
            string Code = DataUtil.ReadData(2, "Code");
            string TypeCode = DataUtil.ReadData(2, "TypeCode");

            string Description = DataUtil.ReadData(2, "Description");
            Console.WriteLine(DataUtil.ReadData(2, "Price"));
            //string Price = DataUtil.ReadData(2, "Price");
            string Price = "100";
            timeNMaterial.CreateNewRecord(Code, Description, Price, TypeCode);

        }

        [Then(@"search for particular Time/Material Item and verify if Time/Material is present")]
        public void ThenSearchForParticularTimeMaterialItemAndVerifyIfTimeMaterialIsPresent()
        {
            DataUtil.GetDataInCollection("C:\\Users\\Shruthi Devaraj\\Desktop\\Me\\TimeAndMaterialTestData.xlsx", "ValidateRecord");
            Given("I have Logged into the portal");
            Given("I have to navigate to Time and material page");
            String CodeToValidate = DataUtil.ReadData(1,"Code");
            int result = timeNMaterial.ValidateRecord("CodeToValidate");
            Assert.IsTrue(result > 0,"Time Material record Exists");
        }

        [Given(@"I have to search for Item which needs to be edited")]
        public void GivenIHaveToSearchForItemWhichNeedsToBeEdited()
        {
            Given("I have Logged into the portal");
            Given("I have to navigate to Time and material page");
        }

        [Then(@"Edit and save it and verify if the Time/material item is edited")]
        public void ThenEditAndSaveItAndVerifyIfTheTimeMaterialItemIsEdited()
        {

            DataUtil.GetDataInCollection("C:\\Users\\Shruthi Devaraj\\Desktop\\Me\\TimeAndMaterialTestData.xlsx", "EditTimeAndMaterial");

            string CodeToEdit = DataUtil.ReadData(2, "Code");
            string NewCode = DataUtil.ReadData(2, "NewCode");
            string Description = DataUtil.ReadData(2, "Description");

            string TypeCode = DataUtil.ReadData(2, "TypeCode");
            int result = timeNMaterial.EditRecord(CodeToEdit,NewCode,Description,"100",TypeCode);
            Assert.IsTrue(result > 0,"REcord Editted successfully");
        }

        [Given(@"I have to search for Item which needs to be deleted and delete it")]
        public void GivenIHaveToSearchForItemWhichNeedsToBeDeletedAndDeleteIt()
        {
            Given("I have Logged into the portal");
            Given("I have to navigate to Time and material page");
        }

        [Then(@"verify if Time/Material is deleted")]
        public void ThenVerifyIfTimeMaterialIsDeleted()
        {
            DataUtil.GetDataInCollection("C:\\Users\\Shruthi Devaraj\\Desktop\\Me\\TimeAndMaterialTestData.xlsx", "DeleteTimeAndMaterial");
            string Code = DataUtil.ReadData(2, "Code");
            int result = timeNMaterial.DeleteRecord(Code);
            Assert.IsTrue(result > 0,"Record deleted successfully");
            driver.Quit();

        }


        [AfterScenario]
        public void Diposable()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }


    }
}