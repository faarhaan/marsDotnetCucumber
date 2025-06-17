using mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Audits;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mars.Pages
{
    public class LSPage : CommonDriver
    {
        public void languagePage(IWebDriver driver, String Languages, String Level)
        {
            // Check Language Functionality
            // Click on Add new button to add Language & Skill Level
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            /////Now enter Languae English 
            IWebElement enterLanguageName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            enterLanguageName.SendKeys(Languages);

            /* // click on dropdown and select "Fluent"
             IWebElement dropDownLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
             dropDownLevel.Click();

             IWebElement selectLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[4]"));
             selectLevel.Click();
             */

            //Use SelectElement.SelectByText(Level) to select the dropdown value directly by its visible text, matching your scenario outline value. This is the cleanest and most maintainable approach.
            // Select Level from dropdown using SelectElement
            IWebElement dropDownLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            var selectElement = new SelectElement(dropDownLevel);
            selectElement.SelectByText(Level);



            // Click on Add button to add 2nd  language in list
            IWebElement clickOnAddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            clickOnAddButton.Click();
            Thread.Sleep(3000);

        }
        public String GetLastLanguage(IWebDriver driver, String Languages, String Level)
        {
            Thread.Sleep(3000);
            // Verify Languages are created Successfully.
            IWebElement lastLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return lastLanguage.Text;                               
            //Assert.That(lastLanguage.Text == "Hindi", "Languages are not added! Test is Failed!");
            
        }

        
        public void NotAvailableAddNewButton(IWebDriver driver)
        {
            // Capture the of Add New Button when available 
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
        }
        public void DeleteAllLanguages(IWebDriver driver)
        {
            IWebElement deleteIcon = driver.FindElement(By.XPath(
                "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]"));
            // Loop through language rows, click delete for each
            while (true)
            {
                var deleteIcons = driver.FindElements(By.XPath(
                    "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                if (deleteIcons.Count == 0)
                    break;
                deleteIcons[0].Click();
                Thread.Sleep(1000); // Wait for row to be removed
            }
        }


        public void SkillPage(IWebDriver driver, String Skills, String Level)
        {
            // Go to Skill tab
            IWebElement skillTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillTab.Click();

            // Click on Add New Button
            IWebElement clickOnAddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            clickOnAddNewButton.Click();
            // Click on the skill pad to enter the skill
            IWebElement pad = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]"));
            //Enter 1st skill 
            IWebElement enterFirstSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            enterFirstSkill.Clear();
            enterFirstSkill.SendKeys(Skills);
            // click on dropdown and select level "Intermediate"
            IWebElement dropDownLevel1 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            var selectElement1 = new SelectElement(dropDownLevel1);
            selectElement1.SelectByText(Level);

            /* IWebElement selectFirstSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[3]"));
             selectFirstSkillLevel.Click();*/

            //  Click on Add button to add the skill in the list             
            IWebElement clickOnAddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            clickOnAddButton.Click();
            Thread.Sleep(2000);
        }
           
        
        public String GetLastSkill(IWebDriver driver, String Skills, String Level)
        {
            Thread.Sleep(2000);
            // Verify languages are successfully added
            IWebElement lastSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            //Assert.That(lastSkill.Text == "Selenium", "Skills are not added in database! Test is Failed");
            return lastSkill.Text;
        }
        public void DeleteAllSkills(IWebDriver driver)
        {
            // Activate Skill tab so that language can be deleted
            IWebElement sKillTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2] "));
            sKillTab.Click();
            // Loop through skill rows, click delete for each
            while (true)
            {
                var deleteIcon = driver.FindElements(By.XPath(
                    "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                if (deleteIcon.Count == 0)
                    break;
                deleteIcon[0].Click();
                Thread.Sleep(1000); //  this time is mandatory if you want simple asser with message 

            }
        }

        public int GetSkillCount(IWebDriver driver)
        {
            var rows = driver.FindElements(By.XPath(
                "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));
              /*  to access the table rows for logic, First you fetch the table frame xpath which is till div, then you go to table, then move cursor to trace,
                     then rows.count willl work.*/
            return rows.Count;
        }


    }



}
