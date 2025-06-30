using mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    public class SkilPage : CommonDriver
    {
        public void SkillPage( String Skills, String Level)
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

            //  Click on Add button to add the skill in the list             
            IWebElement clickOnAddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            clickOnAddButton.Click();
            Thread.Sleep(2000);
        }


        public String GetLastSkill( String Skills, String Level)
        {
            Thread.Sleep(2000);
            // Verify languages are successfully added
            IWebElement lastSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            //Assert.That(lastSkill.Text == "Selenium", "Skills are not added in database! Test is Failed");
            return lastSkill.Text;
        }
        public void DeleteAllSkills()
        {
          /*  // Activate Skill tab so that skills can be deleted
            IWebElement sKillTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            sKillTab.Click();
            Thread.Sleep(1000);
*/
            // Loop through skill rows, click delete for each
            while (true)
            {
                var deleteIcon = driver.FindElements(By.XPath(
                    "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                if (deleteIcon.Count == 0)
                    break;
                deleteIcon[0].Click();
                Thread.Sleep(1000); 

            }
        }

        
        public int GetSkillCount()
        {
            var rows = driver.FindElements(By.XPath(
                "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));
            /*  to access the table rows for logic, First you fetch the table frame xpath which is till div, then you go to table, then move cursor to trace,
                   then rows.count willl work.*/
            return rows.Count;
        }

        public void UpdateSkill(string oldSkill, string newSkill, string newLevel)
        {
            // Go to Skill tab
            var skillTab = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillTab.Click();
            // capture all rows 
            var rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));
            foreach (var row in rows)
            {
                var skillCell = row.FindElement(By.XPath("td[1]"));    // td[1] is the first cell in the row which contains the skill name
                if (skillCell.Text.Trim().Equals(oldSkill, StringComparison.OrdinalIgnoreCase))
                {
                    // Click the edit (pencil) icon
                    var editIcon = row.FindElement(By.XPath("td[3]/span[1]/i"));  // td[3] is the third cell which contains the edit icon   
                    editIcon.Click();
                    Thread.Sleep(1000);

                    // Update skill name
                    var skillInput = row.FindElement(By.XPath("td/div/div[1]/input"));
                    skillInput.Clear();
                    skillInput.SendKeys(newSkill);

                    // Update level
                    var levelDropdown = row.FindElement(By.XPath("td/div/div[2]/select"));
                    var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(levelDropdown);
                    selectElement.SelectByText(newLevel);

                    // Click update button
                    var updateButton = row.FindElement(By.XPath("td/div/span/input[1]"));
                    updateButton.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }


        }

        
    }

    
}
