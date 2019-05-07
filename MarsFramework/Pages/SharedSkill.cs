using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class SharedSkill
    {

        public SharedSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        #region  Initialize Web Elements 
        //Click on to Share skill
       // [FindsBy(How = How.XPath, Using = "//a[text()='Share Skill']")]
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement ShareSkillLink { get; set; }

        

        //Write Title
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Write a title to describe the service you provide.']")]
        private IWebElement Title { get; set; }

        //Write Decription
        [FindsBy(How = How.XPath, Using = "//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']")]
        private IWebElement Desc { get; set; }

        //Click on Select Categeory Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='categoryId']")]
        private IWebElement CategoryDropdown { get; set; }

        //Click on Select Sub Categeory Dropdown
        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'subcategoryId')]")]
        private IWebElement Subcategory { get; set; }

        //Add New tags
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[@class='ReactTags__tags']/div[@class='ReactTags__selected']/div[@class='ReactTags__tagInput']/input[1]")]
        private IWebElement Tags { get; set; }

        //Select Service Type
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Hourly basis service')]")]
        private IWebElement Hourlybasisservice { get; set; }

        //Select Location Type
        [FindsBy(How = How.XPath, Using = "//div[6]//div[2]//div[1]//div[2]//div[1]//input[1]")]
        private IWebElement onlinetype { get; set; }

        // Enter Avilable Date
        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Start date')]")]
        private IWebElement Startdate { get; set; }

        //Enter Avilable Days
        [FindsBy(How = How.XPath, Using = "//input[@name='Available']")]
        private IList<IWebElement> availableDays { get; set; }

        //Enter Avilable Days
        //  [FindsBy(How = How.XPath, Using = "//div[@class='tooltip-target ui grid']//div[7]//div[1]//div[1]//input[1]")]
        // private IWebElement Friday { get; set; }

        //Select Skill Trade
        [FindsBy(How = How.XPath, Using = "//div[8]//div[2]//div[1]//div[2]//div[1]//input[1]")]
        private IWebElement Credit { get; set; }

        //Enter Credit $
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement Dollarsperhour { get; set; }

        //Upload work sample
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement Uploadsample { get; set; }

        //Enable Service
        [FindsBy(How = How.XPath, Using = "//div[10]//div[2]//div[1]//div[1]//div[1]//input[1]")]
        private IWebElement EnableService { get; set; }

        //Save button
        [FindsBy(How = How.XPath, Using = "//input[@class='ui teal button']")]
        private IWebElement Save { get; set; }

        #endregion


        internal void ShareSkillSteps()
        {
            //extent Reports
            Base.test = Base.extent.StartTest("Create Shared Skill");

            //Click on Share skill link
            Thread.Sleep(2000);
            ShareSkillLink.Click();
            Thread.Sleep(2000);

            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "AddSkill");


            //Enter Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter Description
            Desc.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select Category
            CategoryDropdown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Select Sub category
            Subcategory.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Sub-Category"));

            //Enter Tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));

            //Click on Checkbox
            Startdate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));

            foreach(IWebElement el in availableDays)
            {
                el.Click();
            }

            //Select Credit radio button
            Credit.Click();

            //Enter Credit Service
            Dollarsperhour.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CreditPerService"));

            Save.Click();
            Thread.Sleep(2000);

            string text = Global.GlobalDefinitions.driver.FindElement(By.XPath("//h2[contains(text(),'Manage Listings')]")).Text;

            if (text == "Manage Listings")
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Created Share skill Success");
            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Share Skill creation Unsuccessful");
        }

    }
}



