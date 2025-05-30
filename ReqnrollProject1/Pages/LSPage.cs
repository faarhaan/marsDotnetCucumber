using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Audits;

namespace mars.Pages
{
    public class LSPage : CommonDriver
    {
        public void languagePage(IWebDriver driver)
        {
            // Check Language Functionality
            // Click on Add new button to add Language & Skill Level
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            //Now enter Languae English 
            IWebElement enterLanguageName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            enterLanguageName.SendKeys("English");

            // click on dropdown and select "Fluent"
            IWebElement dropDownLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            dropDownLevel.Click();

            IWebElement selectLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[4]"));
            selectLevel.Click();

            // Click on Add button to add 2nd  language in list
            IWebElement clickOnAddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            clickOnAddButton.Click();
            Thread.Sleep(3000);

            // Click on Add New Button to add 2nd Language "Hindi" & Skill Level
            IWebElement addNewButton1 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton1.Click();
            Thread.Sleep(2000);
            // Clear the pre-exiting language in type box
            IWebElement clearLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            clearLanguageTextBox.Clear();

            // Enter Langauge Hindi & Select Level Native
            IWebElement enterSecondLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            enterSecondLanguage.SendKeys("Hindi");

            IWebElement dropDownHindiLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[5]"));
            dropDownHindiLevel.Click();

            IWebElement selectHindiLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[5]"));
            selectHindiLevel.Click();
            // Click on Add Button

            IWebElement clickOnAddButton2ndTime = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            clickOnAddButton2ndTime.Click();
           
            /*if (lastLanguage.Text == "Hindi")
            {
                Console.WriteLine("Languages are successfully added in database! Test is Passed");
            }
            else
            {
                Console.WriteLine("Languages are not added! Test is Failed");
            }*/

        }
        public String GetLastLanguage(IWebDriver driver)
        {
            Thread.Sleep(2000);
            // Verify Languages are created Successfully.
            IWebElement lastLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[1]"));
            return lastLanguage.Text;
            //Assert.That(lastLanguage.Text == "Hindi", "Languages are not added! Test is Failed!");
            
        }

        /*        public void UpdateLastRecord(IWebDriver driver)
                {
                    // Update Last Language Record
                    IWebElement clickOnPencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
                    clickOnPencilIcon.Click();
                    Thread.Sleep(4000);
                    // Clear the language
                    IWebElement removeLangugae = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td/div/div[1]/input"));
                    removeLangugae.Clear();

                    // enter new Language
                    IWebElement enter3rdLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td/div/div[1]/input"));
                    enter3rdLanguage.SendKeys("French");

                    // update the list
                    IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td/div/span/input[1]"));
                    updateButton.Click();

                }*/

        public void SkillPage(IWebDriver driver)
        {
            // Go to Skill tab
            IWebElement skillTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillTab.Click();

            // Click on Add New Button
            IWebElement clickOnAddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            clickOnAddNewButton.Click();
            //
            IWebElement pad = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]"));
            //Enter 1st skill and choose level
            IWebElement enterFirstSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            enterFirstSkill.Clear();
            enterFirstSkill.SendKeys("C-sharp");
            // click on dropdown and select level "Intermediate"
            IWebElement dropDownLevel1 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            IWebElement selectFirstSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[3]"));
            selectFirstSkillLevel.Click();
            //  Click on Add button to add the skill in the list             
            IWebElement clickOnAddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            clickOnAddButton.Click();
            Thread.Sleep(2000);





            // Now Add the 2nd Skill I know so Click on Add New Button
            IWebElement clickOnAddNewButton2 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            clickOnAddNewButton2.Click();

            //Enter 2nd skill and choose level
            IWebElement enterSecondSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            enterSecondSkill.Clear();
            enterSecondSkill.SendKeys("Java");
            // click on dropdown and select level "Intermediate"
            IWebElement dropDownLevel2 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));

            IWebElement selectSecondSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[3]"));
            selectSecondSkillLevel.Click();
            //  Click on Add button to add the skill in the list
            IWebElement clickOnAddButton2 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            clickOnAddButton2.Click();
            Thread.Sleep(2000);



            //  Now Add my 3rd Skill so Click on Add New Button

            IWebElement clickOnAddNewButton3 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            clickOnAddNewButton3.Click();
            //Enter 3rd skill and choose level
            IWebElement enterThirdSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            enterThirdSkill.Clear();
            enterThirdSkill.SendKeys("Selenium");
            // click on dropdown and select level "Intermediate"
            IWebElement dropDownLevel3 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            IWebElement selectThirdSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[3]"));
            selectThirdSkillLevel.Click();
            //  Click on Add button to add the skill in the list
            IWebElement clickOnAddButton3 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            clickOnAddButton3.Click();
          
           
         /*   if (lastSkill.Text == "Selenium")
            {
                Console.WriteLine(" Skills are successfully updated in database! Test is Passed ");
            }
            else
            {
                Console.WriteLine("Skills are not added in database! Test is Failed");
            }*/
        }
        public String GetLastSkill(IWebDriver driver)
        {
            Thread.Sleep(2000);
            // Verify languages are successfully added
            IWebElement lastSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[3]/tr/td[1]"));
            Assert.That(lastSkill.Text == "Selenium", "Skills are not added in database! Test is Failed");
            return lastSkill.Text;
        }

    }



}
