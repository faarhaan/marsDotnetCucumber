using mars.Pages;
using mars.Utilities;
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
    /*    [Binding]
        public class Hooks : CommonDriver
        {
            [BeforeScenario(Order = 0)]
            public void SetupSteps()
            {
                driver = new ChromeDriver();
            }

            [AfterScenario(Order = 100)]
            //[Scope(Tag = "languages")]
            public void CleanUpLanguages()
            {
                var lSPageObj = new LSPage();
                lSPageObj.DeleteAllLanguages();
                driver.Quit();
            }

            [AfterScenario(Order = 100)]
            [Scope(Tag = "skills")]
            public void CleanUpSkills()
            {
                var skilPageObj = new SkilPage();
                skilPageObj.DeleteAllSkills();
                driver.Quit();
            }
        }*/

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
         
            // Clean up all skills after each scenario
          
            SkilPage skilPageObj = new SkilPage();
            skilPageObj.DeleteAllSkills();
            
            // Clean up all languages (or skills) after all scenarios/examples
            LSPage lSPageObj = new LSPage();
            lSPageObj.DeleteAllLanguages();


            // Optionally, close the browser if not already closed
            driver.Quit();
        }
        
    }

}


    
