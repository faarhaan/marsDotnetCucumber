using mars.Pages;
using mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using ReqnrollProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class Hooks : CommonDriver
    {
        [BeforeScenario(Order = 0)]
        public void SetupSteps()
        {
            driver = new ChromeDriver();
          
        }
        [AfterScenario(Order = 100)]
        public static void CleanUpAfterScenario()
        {
            // Clean up all certification after each scenario
            try
            {
                CertificationPage certificationPageObj = new CertificationPage();
                certificationPageObj.DeleteCertificate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Certificate cleanup failed: {ex.Message}");
            }

            // Clean up all educations after each scenario
            try
            {
                EducationPage educationPageObj = new EducationPage();
                educationPageObj.DeleteEducation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Education cleanup failed: {ex.Message}");
            }

            // Clean up all skills after each scenario
            try
            {
                SkilPage skilPageObj = new SkilPage();
                skilPageObj.DeleteAllSkills();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Skills cleanup failed: {ex.Message}");
            }

            // Clean up all languages after each scenario
            try
            {
                LSPage lSPageObj = new LSPage();
                lSPageObj.DeleteAllLanguages();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Languages cleanup failed: {ex.Message}");
            }

        /*    // Optionally, close the browser if not already closed
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Browser quit failed: {ex.Message}");
            }*/
        }

        /*        [AfterScenario(Order = 100)]
                public static void CleanUpAfterScenario()

                {
                    // Clean up all educations after each scenario
                    EducationPage educationPageObj = new EducationPage();
                    educationPageObj.DeleteEducation();

                    // Clean up all skills after each scenario

                    SkilPage skilPageObj = new SkilPage();
                    skilPageObj.DeleteAllSkills();

                    // Clean up all languages (or skills) after all scenarios/examples
                    LSPage lSPageObj = new LSPage();
                    lSPageObj.DeleteAllLanguages();


                    // Optionally, close the browser if not already closed
                    driver.Quit();
                }*/

    }

}


    
