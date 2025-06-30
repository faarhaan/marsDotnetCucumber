using mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Audits;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mars.Pages
{
    public class LSPage : CommonDriver
    {
        public void languagePage( String Languages, String Level)
        {
            // Check Language Functionality
            // Click on Add new button to add Language & Skill Level
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            /////Now enter Languae English 
            IWebElement enterLanguageName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            enterLanguageName.SendKeys(Languages);

            // Select Level from dropdown using SelectElement
            IWebElement dropDownLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            var selectElement = new SelectElement(dropDownLevel);
            selectElement.SelectByText(Level);


            // Click on Add button to add 2nd  language in list
            IWebElement clickOnAddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            clickOnAddButton.Click();
            Thread.Sleep(3000);

        }
        public String GetLastLanguage(String Languages, String Level)
        {
            Thread.Sleep(3000);
            // Verify Languages are created Successfully.
            IWebElement lastLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return lastLanguage.Text;
            //Assert.That(lastLanguage.Text == "Hindi", "Languages are not added! Test is Failed!");

        }


        public void NotAvailableAddNewButton()
        {
            // Capture the of Add New Button when available 
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
        }
        public void DeleteAllLanguages()
        {
            IWebElement LanguagePage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
               
            // Loop through language rows, click delete for each
            while (true)
            {
                var deleteIcons = driver.FindElements(By.XPath(
                    "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                if (deleteIcons.Count == 0)
                    break;
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(deleteIcons[0])).Click();
                /*    deleteIcons[0].Click();
                    Thread.Sleep(1000); // Wait for row to be removed*/

                try
                {
                    // Click the first delete icon
                    deleteIcons[0].Click();
                    // Wait for the row to be removed
                    Thread.Sleep(1000);
                }
                catch (StaleElementReferenceException)
                {
                    // If a stale element exception occurs, continue the loop to re-find elements
                    continue;
                }
            }
        }  
        
        public void uPdateLanguage(String Languages,String NewLanguage, String NewLevel)
        {
            // Activate Language tab so that languages can be updated
            IWebElement LanguageTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            LanguageTab.Click();

            // Capture all rows of table
            var rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));
            foreach(var row in rows)                
            {
                // Check if the first cell contains the language to be updated
                var languageCell = row.FindElement(By.XPath("./td[1]"));
                if (languageCell.Text.Trim().Equals(Languages))
                {
                    // Click on the pencil icon to edit the language
                    var editIcon = row.FindElement(By.XPath("./td[3]/span[1]/i"));
                    editIcon.Click();
                    Thread.Sleep(1000);
                    
                    // enter new language name
                    var languageInput = row.FindElement(By.XPath("td/div/div[1]/input"));
                    languageInput.Clear();
                    languageInput.SendKeys(NewLanguage);
                    // Select new level from dropdown
                    var levelDropdown = row.FindElement(By.XPath("td/div/div[2]/select"));
                    var selectElement = new SelectElement(levelDropdown);
                    selectElement.SelectByText(NewLevel);
                    // Click on Update button
                    var updateButton = row.FindElement(By.XPath("td/div/span/input[1]"));                   
                    updateButton.Click();
                    Thread.Sleep(2000); // Wait for update to complete
                    break; // Exit loop after updating the first matching language
                }
            }
        }
    }   
}
