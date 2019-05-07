using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ManageListing
    {
        //***
        public ManageListing()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 

        // View Manage Listings
        [FindsBy(How = How.XPath, Using = "//i[@class='eye icon']")]
        private IWebElement View { get; set; }

        // Edit Manage Listings
        [FindsBy(How = How.XPath, Using = "//i[@class='outline write icon']")]
        private IWebElement Edit { get; set; }

        //Click Remove Icon
        [FindsBy(How = How.XPath, Using = "//i[@class='remove icon']")]
        private IWebElement Delete { get; set; }

        //Click Yes button
        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        private IWebElement DeleteYes { get; set; }

        #endregion

        internal void DeleteSteps()
        {
            //extent Reports
            Base.test = Base.extent.StartTest("Delete Skill");

            Delete.Click();
            Thread.Sleep(1500);

            DeleteYes.Click();
            Thread.Sleep(1500);

            string text1 = Global.GlobalDefinitions.driver.FindElement(By.XPath("//h3[contains(text(),'You do not have any service listings!')]")).Text;
         //   Thread.Sleep(1500);
            if (text1 == "You do not have any service listings!")
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Delete Listings Successful");
            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Delete Listings Unsuccessful");

            
        }
    }
}