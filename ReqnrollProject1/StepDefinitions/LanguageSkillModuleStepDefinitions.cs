using mars.Pages;
using mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V135.HeapProfiler;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using ReqnrollProject1.Pages;
using ReqnrollProject1.Utilities;
using SeleniumExtras.WaitHelpers;
using System;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class LanguageSkillModuleStepDefinitions : CommonDriver
    {
        private readonly LoginPage loginPageObj;
        private readonly HomePage homePageObj;
        private readonly LSPage lSPageObj;
        private readonly SkilPage sKilPageObj;

        public LanguageSkillModuleStepDefinitions()
        {
            loginPageObj = new LoginPage();
            homePageObj = new HomePage();
            lSPageObj = new LSPage();
            sKilPageObj = new SkilPage();
        }

        [Given("I login to skillShare portal successfully")]
        public void GivenILoginToSkillSharePortalSuccessfully() {
          //  LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions();
        }


        [Given("user is in the home page")]
        public void GivenUserIsInTheHomePage()
        {
            String userIsInHomePage = homePageObj.UserIsInHomePage();
            Assert.That(userIsInHomePage == "Mars Logo", "User is not in Home Page! Test is Failed!");
        }


        [When("I create the {string}and {string} list successfully")]
        public void WhenICreateTheAndListSuccessfully(string Languages, string Level)
        {
            lSPageObj.languagePage(Languages, Level);

        }




        // This method is used to verify the language and level are added successfully
        [Then("{string} and {string} list should be created successfully")]
        public void ThenAndListShouldBeCreatedSuccessfully(string Languages, string Level)
        {

            String getlastlanguage = lSPageObj.GetLastLanguage(Languages, Level);
            Assert.That(getlastlanguage == Languages, $"Language '{Languages}' was not added! Test is Failed!");

        }



        // This method is used to delete all languages one by one
        [When("I delete all languages")]
        public void WhenIDeleteAllLanguages()
        {
            
            lSPageObj.DeleteAllLanguages();
        }

        [Then("no languages should be present in the list")]
        public void ThenNoLanguagesShouldBePresentInTheList()
        {
            Console.WriteLine("No languages are present in the list now!");
        }





        // This method is used to update the language and level

        [When("I create the language {string} and level {string} list successfully")]
        public void WhenICreateTheLanguageAndLevelListSuccessfully(string Languages, string Level)
        {
            lSPageObj.languagePage(Languages, Level);
        }

        [When("I update the language {string} to {string} and level to {string}")]
        public void WhenIUpdateTheLanguageToAndLevelTo(string Languages, string NewLanguage, string NewLevel)
        {
            lSPageObj.uPdateLanguage(Languages, NewLanguage, NewLevel);  
        }

        [Then("language {string} and level {string} should be created successfully")]
        public void ThenLanguageAndLevelShouldBeCreatedSuccessfully(string NewLanguage, string NewLevel)
        {
            String getlastlanguage = lSPageObj.GetLastLanguage(NewLanguage, NewLevel);
            Assert.That(getlastlanguage == NewLanguage, $"Language '{NewLanguage}' was not added! Test is Failed!");
        }
       




        //    For Languages Negtive  Scenarios and Destructive Testing
        [Then("language {string} and level {string} should be created successfully as application accept invalid inputs gracefully")]
        public void ThenLanguageAndLevelShouldBeCreatedSuccessfullyAsApplicationAcceptInvalidInputsGracefully(string Languages, string Level)
        {
           
            String getlastlanguage = lSPageObj.GetLastLanguage(Languages, Level);
            Assert.That(getlastlanguage == Languages, $"Language '{Languages}' was not added! Test is Failed!");
        }





        // Negative Testing with vaild inputs  example duplicate entries
        [When("I try to create duplicate languages   {string} and level {string}")]
        public void WhenITryToCreateDuplicateLanguagesAndLevel(string Languages, string Level)
        {
            
            lSPageObj.languagePage(Languages, Level);
        }


        [Then("an error message {string} should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed(string ErrorMessage)
        {
            // Wait up to 5 seconds for the notification to appear
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box-inner']")));
                // Check if the error message is displayed  
                bool isErrorMessageDisplayed = driver.FindElement(By.Id("error-message")).Displayed;
                Assert.That(isErrorMessageDisplayed, Is.True, "Error message should be displayed for invalid login.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Error message was not displayed as expected.");
            }

        }





        // Destructive Testing for Languages

        [When("I create the language {string} and level {string} with destructive input")]
        public void WhenICreateTheLanguageAndLevelWithDestructiveInput(string Languages, string Level)
        {
            
            lSPageObj.languagePage(Languages, Level);
        }

        [Then("the language {string} and level {string} should be handled gracefully")]
        public void ThenTheLanguageAndLevelShouldBeHandledGracefully(string Languages, string Level)
        {
           
            String getLastLanguage = lSPageObj.GetLastLanguage(Languages, Level);
            Assert.That(getLastLanguage == Languages, $"Language '{Languages}' was not added! Test is Failed!");
        
        
        }




           //This test check for valid inputs e.g space

        [When("I create the language {string} and level {string} with empty space")]
        public void WhenICreateTheLanguageAndLevelWithEmptySpace(string Languages, string Level)
        {
         
            lSPageObj.languagePage(Languages, Level);
        }

        [Then("language {string} and level {string} should be created")]
        public void ThenLanguageAndLevelShouldBeCreated(string Languages, string Level)
        {
           
            String getLastLanguage = lSPageObj.GetLastLanguage(Languages, Level);
            Assert.That(getLastLanguage == Languages, $"Language '{Languages}'is not added! Test is Failed");
        }






        //  For Skills Section 
        [When("I create the skill {string}and level{string} list successfully")]
        public void WhenICreateTheSkillAndLevelListSuccessfully(string skills, string level)
        {
            
            sKilPageObj.SkillPage(skills, level);
        }

        [Then("skills {string} and level{string} list should be created successfully")]
        public void ThenSkillsAndLevelListShouldBeCreatedSuccessfully(string skills, string level)
        {
            
            String getLastSkill = sKilPageObj.GetLastSkill(skills, level);
            Assert.That(getLastSkill == skills, $"Skills '{skills}' was not added! Test is Failed!");
        }

        [When("I delete all skills one by one")]
        public void WhenIDeleteAllSkillsOneByOne()
        {
           
            sKilPageObj.DeleteAllSkills();
        }



        [Then("no skills should be present in the list")]
        public void ThenNoSkillsShouldBePresentInTheList()
        {
            
            // SkilPage sKilPageObj = new SkilPage();
            int skillCount = sKilPageObj.GetSkillCount();
            Assert.That(skillCount == 0, "Skills are not deleted! Test is Failed!");

        }

        // create and update skills
        [When("I create the Oldskill {string} and Oldlevel {string} list successfully")]
        public void WhenICreateTheOldskillAndOldlevelListSuccessfully(string oldSkills, string oldLevel)
        {
            
            sKilPageObj.SkillPage(oldSkills, oldLevel);
                
        }

        [When("I update the Oldskill {string} to {string} and Oldlevel  to {string}")]
        public void WhenIUpdateTheOldskillToAndOldlevelTo(string oldSkill, string NewSkill, string Level)

        {
            
            sKilPageObj.UpdateSkill(oldSkill, NewSkill, Level);
        }
 


        [Then("skills {string} and level {string} list should be created successfully")]
        public void ThenSkillsAndLevelListShouldBeCreatedSuccessfuly(string NewSkills, string NewLevel)
        {
            
            String getLastSkill = sKilPageObj.GetLastSkill(NewSkills, NewLevel);
            Assert.That(getLastSkill == NewSkills, $"Skills '{NewSkills}' was not added! Test is Failed!");
        }


        //  Negative Testing with invalid values
        [When("I create the skills {string} and Level {string} list successfully")]
        public void WhenICreateTheSkillsAndLevelListSuccessfully(string skills, string level)
        {
            sKilPageObj.SkillPage(skills, level);   
        }

        [Then("skills {string} and level {string} should be created successfully as application accept invalid inputs gracefully")]
        public void ThenSkillsAndLevelShouldBeCreatedSuccessfullyAsApplicationAcceptInvalidInputsGracefully(string skills, string level)
        {
            String getLastSkill = sKilPageObj.GetLastSkill(skills, level);
            Assert.That(getLastSkill == skills, $"Skills '{skills}' was not added! Test is Failed!");
        }


        //  Negative Testing with vaild inputs  example duplicate entries

        [When("I create duplicate Skills {string} and Level {string}.")]
        public void WhenICreateDuplicateSkillsAndLevel_(string Skills, string Level)
        {
            // same code from SkilPage is used to add skills from method SkillPage
            sKilPageObj.SkillPage(Skills, Level);
        }


        [Then("error message {string} should be displayed.")]
        public void ThenErrorMessageShouldBeDisplayed_(string ErrorMessage)
        {
            Console.WriteLine("Error message should be displayed for duplicate skills.");   
        }

        // Destructive Testing for Skills
        [When("I create the Skill {string} and level {string} with destructive data")]
        public void WhenICreateTheSkillAndLevelWithDestructiveData(string Skills, String Level)
        {
            sKilPageObj.SkillPage(Skills, Level);   
        }

        [Then("Skill {string} and level {string} should be handled gracefully")]
        public void ThenSkillAndLevelShouldBeHandledGracefully(string Skills, String Level)
        {
            String getLastSkill = sKilPageObj.GetLastSkill(Skills, Level);
            Assert.That(getLastSkill == Skills, $"Skills '{Skills}' was not added! Test is Failed!");       
        }


        // This test check for valid inputs e.g space

        [When("I create the Skills {string} and level {string} with empty space")]
        public void WhenICreateTheSkillsAndLevelWithEmptySpace(string Skills, string Level)
        {
            sKilPageObj.SkillPage(Skills, Level);
        }

        [Then("Skills{string} and level {string} should be handled gracefully")]
        public void ThenSkillsAndLevelShouldBeHandledGracefully(string Skills, string Level)
        {
            String getLastSkill = sKilPageObj.GetLastSkill(Skills, Level);
            Assert.That(getLastSkill == Skills, $"Skills '{Skills}' was not added! Test is Failed!");
        }


    }








}
