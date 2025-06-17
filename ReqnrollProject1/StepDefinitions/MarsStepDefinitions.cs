using System;
using mars.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Reqnroll;
using mars.Utilities;
using NUnit.Framework;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class MarsStepDefinitions : CommonDriver
    {

        [BeforeScenario]
        public void SetupSteps()
        {
            //  open chrome Browser
            driver = new ChromeDriver();

        }


        [Given("I login to Mar portal successfully")]
        public void GivenILoginToMarPortalSuccessfully()
        {
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }

        [When("I create the Language list successfully")]
        public void WhenICreateTheLanguageListSuccessfully()
        {
            // Add languages to the list
            LSPage lSObj = new LSPage();
            lSObj.languagePage(driver);
        }

        [Then("language list shoud be listed successfully")]
        public void ThenLanguageListShoudBeListedSuccessfully()
        {
            LSPage lSObj = new LSPage();
            String getlastlanguage = lSObj.GetLastLanguage(driver);
            Assert.That(getlastlanguage == "Hindi", "Languages are not added! Test is Failed!");
        }

        [When("I create the Skill list successfully")]
        public void WhenICreateTheSkillListSuccessfully()
        {
            // Add Skills to the List
            LSPage lSPageObj = new LSPage();
            lSPageObj.SkillPage(driver);
        }

        [Then("Skill list shoud be listed successfully")]
        public void ThenSkillListShoudBeListedSuccessfully()
        {
            LSPage lSPageObj = new LSPage();
            String getLastSkill = lSPageObj.GetLastSkill(driver);
            Assert.That(getLastSkill == "Selenium", "Skills are not added! Test is Failed");

        }

        [AfterScenario]
        public void CloseTestRun()
        {
           driver.Quit();
        }

    }
}
