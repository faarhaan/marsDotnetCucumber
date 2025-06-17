using mars.Pages;
using mars.Utilities;
using OpenQA.Selenium.Chrome;
using Reqnroll;
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
            //  open chrome Browser
            driver = new ChromeDriver();

        }

        [AfterScenario(Order = 100)]
        public void CloseTestRun()
        {
            // Close the browser after test execution
            {
                driver.Quit();
            }
        }
    }  

    
}
