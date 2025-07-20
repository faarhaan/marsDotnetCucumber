using mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    public class EducationPage : CommonDriver
    {
        // Locators as private fields
        private readonly By educationTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]");
        private readonly By addNewButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div");
        private readonly By inputUniversity = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input");
        private readonly By dropDownCountry = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select");
        private readonly By dropDownTitle = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select");
        private readonly By inputDegree = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input");
        private readonly By dropDownYear = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select");
        private readonly By addButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]");
        private readonly By lastUniversityCell = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]");
        private readonly By lastCountryCell = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]");
        private readonly By deleteIcon = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i");
        private readonly By editIcon = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i");
        // Locators for update method  as private fields
        private readonly By updateDropDownTitle = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[1]/select");
        private readonly By updateDegree = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[2]/input");
        private readonly By updateDropDownYear = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[3]/select");
        private readonly By updateButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]");
        private readonly By totalRows = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr");
        public void InputEducation(String University, String Country, String Title, String Degree, String GraduationYear)
        {
            // Go to Skill tab
            driver.FindElement(educationTab).Click();

            // Click on Add New Button
            driver.FindElement(addNewButton).Click();

            //Enter College/University Name 
            driver.FindElement(inputUniversity).Clear();
            driver.FindElement(inputUniversity).SendKeys(University);

            // click on Country dropdown and select  "Australia"
            IWebElement dropDownCountry1 = driver.FindElement(dropDownCountry);
            var selectElement1 = new SelectElement(dropDownCountry1);
            selectElement1.SelectByText(Country);

            // click on Title dropdown
            IWebElement dropDownTitle1 = driver.FindElement(dropDownTitle);
            var selectElement = new SelectElement(dropDownTitle1);
            selectElement.SelectByText(Title);

            // Enter the degree Name
            driver.FindElement(inputDegree).SendKeys(Degree);

            // click on Year dropDown
            IWebElement dropDownYear1 = driver.FindElement(dropDownYear);
            var selectElement2 = new SelectElement(dropDownYear1);
            selectElement2.SelectByText(GraduationYear);
            //  Click on Add button to add the education in the list             
            driver.FindElement(addButton).Click();
            Thread.Sleep(2000);
        }
        public String GetLastUniversity(String University, String Country, String Title, String Degree, String GraduationYear)
        {
            Thread.Sleep(2000);
            // Verify education is successfully added
            return driver.FindElement(lastUniversityCell).Text;

        }

        public String GetLastCountry(String University, String Country, String Title, String Degree, String GraduationYear)
        {
            Thread.Sleep(2000);
            // Verify education row successfully by using 2 methods
            return driver.FindElement(lastCountryCell).Text;
        }

        public void DeleteEducation()
        {
            // As there will be 1 row so I will use 1 line code
            Thread.Sleep(1000);
            IWebElement deleteEducation = driver.FindElement(deleteIcon);
            deleteEducation.Click();
            /*  // Loop through skill rows, click delete for each
              while (true)
              {
                  var deleteIconList3 = driver.FindElements(deleteIcons);
                  if (deleteIconList3.Count == 0)
                      break;
                  deleteIconList3[0].Click();
                  Thread.Sleep(1000);

              }*/
        }
        public void UpdateEducation(string oldUniversity, string University, string Country, String Title, string Degree, string GraduationYear)
        {
           
            // Go to Education tab
            driver.FindElement(educationTab).Click();

            // Get all rows in the education table
            var rows = driver.FindElements(totalRows);
            foreach (var row in rows)              
            {
                // Match by University name only
                var universityCell = row.FindElement(By.XPath("td[2]"));
                if (universityCell.Text.Trim().Equals(oldUniversity, StringComparison.OrdinalIgnoreCase))
                {
                    // Click the edit (pencil) icon
                    var editIcon = row.FindElement(By.XPath("td[6]/span[1]/i"));
                    editIcon.Click();
                    Thread.Sleep(1000);

                    // Update University
                    var universityInput = row.FindElement(By.XPath("td/div/div[1]/input"));
                    universityInput.Clear();
                    universityInput.SendKeys(University);

                    // Update Country
                    var countryDropdown = row.FindElement(By.XPath("td/div/div[2]/select"));
                    var selectCountry = new SelectElement(countryDropdown);
                    selectCountry.SelectByText(Country);

                    // Update Title
                    var titleDropdown = row.FindElement(updateDropDownTitle);
                    var selectTitle = new SelectElement(titleDropdown);
                    Thread.Sleep(1000); // Wait for dropdown to be ready
                    selectTitle.SelectByText(Title);

                    // Update Degree
                    var degreeInput = row.FindElement(updateDegree);
                    degreeInput.Clear();
                    degreeInput.SendKeys(Degree);

                    // Update Graduation Year
                    var graduationYearDropdown = row.FindElement(updateDropDownYear);
                    var selectYear = new SelectElement(graduationYearDropdown);
                    selectYear.SelectByText(GraduationYear);

                    // Click update button
                    var updateButton1 = row.FindElement(updateButton);
                    updateButton1.Click();
                    Thread.Sleep(1000);
                    break; // Stop after updating the first match
                }
            }




        
            



        }
    }
       
        



}
