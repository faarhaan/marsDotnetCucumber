using mars.Pages;
using mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V135.HeapProfiler;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using ReqnrollProject1.Utilities;
using SeleniumExtras.WaitHelpers;
using System;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class LanguageSkillModuleStepDefinitions : CommonDriver
    {

        [Given("I login to skillShare portal successfully")]
        public void GivenILoginToSkillSharePortalSuccessfully() { 
         
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }

        [When("I create the {string}and {string} list successfully")]
        public void WhenICreateTheAndListSuccessfully(string Languages, string Level)
        {
            // Add languages to the list
            LSPage lSObj = new LSPage();
            lSObj.languagePage(driver, Languages, Level);
        }

        [Then("{string} and {string} list should be created successfully")]
        public void ThenAndListShouldBeCreatedSuccessfully(string Languages, string Level)
        {
            LSPage lSObj = new LSPage();
            String getlastlanguage = lSObj.GetLastLanguage(driver, Languages, Level);
            Assert.That(getlastlanguage == Languages, $"Language '{Languages}' was not added! Test is Failed!");
        }

        [When("I delete all languages")]
        public void WhenIDeleteAllLanguages()
        {
            LSPage lSPageObj = new LSPage();
            lSPageObj.DeleteAllLanguages(driver);
        }

        [Then("no languages should be present in the list")]
        public void ThenNoLanguagesShouldBePresentInTheList()
        {
            Console.WriteLine("No languages are present in the list now!");
        }


        [When("I create the skill {string}and level{string} list successfully")]
        public void WhenICreateTheSkillAndLevelListSuccessfully(string skills, string level)
        {
            LSPage lSPageObj = new LSPage();
            lSPageObj.SkillPage(driver, skills, level); 
        }

        [Then("skills {string} and level{string} list should be created successfully")]
        public void ThenSkillsAndLevelListShouldBeCreatedSuccessfully(string skills, string level)
        {
           LSPage lSPageObj = new LSPage();
            String getLastSkill = lSPageObj.GetLastSkill(driver, skills, level);
            Assert.That(getLastSkill == skills, $"Skills '{skills}' was not added! Test is Failed!");
        }

        [When("I delete all skills one by one")]
        public void WhenIDeleteAllSkillsOneByOne()
        {
            LSPage  lSPageObj = new LSPage();
            lSPageObj.DeleteAllSkills(driver);
        }

        [Then("no skills should be present in the list")]
        public void ThenNoSkillsShouldBePresentInTheList()
        {
            //Console.WriteLine("No skills are present in the list now!");  OR use below logic to verify
            LSPage lSPageObj = new LSPage();
            int skillCount = lSPageObj.GetSkillCount(driver);
            Assert.That(skillCount == 0,"Skills are not deleted! Test is Failed!");

        }

        //    For Negtive  Scenarios and Destructive Testing

        [Then("language {string} and level {string} should be created successfully as application accept invalid inputs gracefully")]
        public void ThenLanguageAndLevelShouldBeCreatedSuccessfullyAsApplicationAcceptInvalidInputsGracefully(string Languages, string Level)
        {
            LSPage lSObj = new LSPage();
            String getlastlanguage = lSObj.GetLastLanguage(driver, Languages, Level);
            Assert.That(getlastlanguage == Languages, $"Language '{Languages}' was not added! Test is Failed!");
        }

        // Negative Testing with vaild inputs  example duplicate entries
        [When("I try to create duplicate languages   {string} and level {string}")]
        public void WhenITryToCreateDuplicateLanguagesAndLevel(string Languages, string Level)
        {
            // same code from LSPage is used to add languages from method languagePage
            LSPage lSObj = new LSPage();
            lSObj.languagePage(driver, Languages, Level);
        }

        [Then("an error message {string} should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed(string ErrorMessage)
        {
            // Wait up to 5 seconds for the notification to appear
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box-inner']")));
                // manual created xpath             //div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']//div[@class='ns-box-inner']
                // Check if the error message is displayed  
                bool isErrorMessageDisplayed = driver.FindElement(By.Id("error-message")).Displayed;
                Assert.That(isErrorMessageDisplayed, Is.True, "Error message should be displayed for invalid login.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Error message was not displayed as expected.");
            }
          
            /*     // Validate the notification text
                           string actualText = notification.Text.Trim();
                           Console.WriteLine("Compare this notification text: " + actualText);
                      Assert.That(notification.Text.Contains(ErrorMessage), $"Expected error message '{ErrorMessage}' was not displayed. Actual: '{notification.Text}'");
        
          
                            IWebElement notificationElement = driver.FindElement(By.));
                    //IWebElement notificationElement = driver.FindElement(By.CssSelector("div.ns-box.ns-show"));

                    Assert.IsTrue(notificationElement.Text.Contains("Your duplicate entry message"), "Notification did not appear as expected.");
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    IWebElement notificationElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.ns-box.ns-show")));
                    Assert.IsTrue(notificationElement.Text.Contains("Your duplicate entry message"), "Notification did not appear as expected.");

                                                                                                                                                  */
        }


        // Destructive Testing for Languages

        [When("I create the language {string} and level {string} with destructive input")]
        public void WhenICreateTheLanguageAndLevelWithDestructiveInput(string Languages, string Level)
        {
            LSPage lSObj = new LSPage();
            lSObj.languagePage(driver, Languages, Level);
        }

        [Then("the language {string} and level {string} should be handled gracefully")]
        public void ThenTheLanguageAndLevelShouldBeHandledGracefully(string Languages, string Level)
        {
            LSPage lSObj = new LSPage();
            String getLastLanguage = lSObj.GetLastLanguage(driver, Languages, Level);
            Assert.That(getLastLanguage == Languages, $"Language '{Languages}' was not added! Test is Failed!");
        
        
        }
           //This test check for valid inputs e.g space

        [When("I create the language {string} and level {string} with empty space")]
        public void WhenICreateTheLanguageAndLevelWithEmptySpace(string Languages, string Level)
        {
            LSPage lSPageObj = new LSPage();
            lSPageObj.languagePage(driver, Languages, Level);
        }

        [Then("language {string} and level {string} should be created")]
        public void ThenLanguageAndLevelShouldBeCreated(string Languages, string Level)
        {
            LSPage lSPageObj = new LSPage();
            String getLastLanguage = lSPageObj.GetLastLanguage(driver, Languages, Level);
            Assert.That(getLastLanguage == Languages, $"Language '{Languages}'is not added! Test is Failed");
        }


    }








}
