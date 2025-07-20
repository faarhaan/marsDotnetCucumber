using mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    public class CertificationPage : CommonDriver
    {
        // Locators as private fields
        private readonly By certificationTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]");
        private readonly By addNewButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");
        private readonly By enterCertificationName = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input");
        private readonly By enterCertifiedFrom = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input");
        private readonly By dropDownYear = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select");
        private readonly By addButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]");
        private readonly By lastCertificate = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]");
        private readonly By deleteIcon = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i");
        private readonly By totalRows = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr");
        private readonly By updateButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[2]/tr/td/div/span/input[1]");

        // Actions as a Methods

        public void InputCertifications(String Certificate, String From, String Year)
        {
            // Go to the Certificate tab
            driver.FindElement(certificationTab).Click();
            // Click on the Add New Button
            driver.FindElement(addNewButton).Click();
            // Enter Certificate Name
            driver.FindElement(enterCertificationName).Clear();
            driver.FindElement(enterCertificationName).SendKeys(Certificate);

            // enter the input for Certified From
            driver.FindElement(enterCertifiedFrom).Clear();
            driver.FindElement(enterCertifiedFrom).SendKeys(From);

            // select year from dropdown menu
            IWebElement dropDownYear1 = driver.FindElement(dropDownYear);
            var _selectElement = new SelectElement(dropDownYear1);
            _selectElement.SelectByText(Year);

            // Press Add button to enter the record in table
            driver.FindElement(addButton).Click();
        }

        public String GetLastCertificate(String Certificate, String From, String Year)
        {
            Thread.Sleep(1000);
            // take code of last certificate and make as a private field name it last certificate and use here
            return driver.FindElement(lastCertificate).Text;
        }

        public void DeleteCertificate()
        {

            Thread.Sleep(1000);
            // Click on delete button to remove the certificate
            driver.FindElement(deleteIcon).Click();
        }



        public void UpdateCertificate(string oldCertificate, string newCertificate, string newFrom, string newYear)
        {
            driver.FindElement(certificationTab).Click();
            Thread.Sleep(1000);

            var rows = driver.FindElements(totalRows);
            foreach (var row in rows)
            {
                var certificateCell = row.FindElement(By.XPath("td[1]"));
                if (certificateCell.Text.Trim().Equals(oldCertificate, StringComparison.OrdinalIgnoreCase))
                {
                    // Click the edit (pencil) icon
                    var editIcon = row.FindElement(By.XPath("td[4]/span[1]/i"));
                    editIcon.Click();

                    // Wait for the input field to be visible
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    wait.Until(drv => drv.FindElement(By.XPath("//td/div/div/div[1]/input")).Displayed);

                    // Now find the input fields using a global XPath
                    var certificateInput = driver.FindElement(By.XPath("//td/div/div/div[1]/input"));
                    certificateInput.Clear();
                    certificateInput.SendKeys(newCertificate);

                    var fromInput = driver.FindElement(By.XPath("//td/div/div/div[2]/input"));
                    fromInput.Clear();
                    fromInput.SendKeys(newFrom);

                    var yearDropdown = driver.FindElement(By.XPath("//td/div/div/div[3]/select"));
                    var selectYear = new SelectElement(yearDropdown);
                    selectYear.SelectByText(newYear);

                    // Click update button
                    var updateBtn = driver.FindElement(By.XPath("//td/div/span/input[1]"));
                    updateBtn.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }
        }
       

    }
}
