// 
/*if (MarsLogo.Text == "Mars Logo")
            {
                Assert.Pass("User Login Successfully! Test is Passed");
            }
            else
            {
                Assert.Fail("User didn't Login! Test Failed");
            }
*/

 public class HomePage
    {
        // verify user is login successfully
        public string UserIsInHomePage(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement MarsLogo = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/a"));
            assert.that(MarsLogo.Text == "Mars Logo", "User is not logged in successfully! Test Failed");

            //Assert.That(lastLanguage.Text == "Hindi", "Languages are not added! Test is Failed!");

            ----------------------------------------------------------------------------------------------------

            public String GetLastSkill( String Skills, String Level)
        {
            Thread.Sleep(2000);
            // Verify languages are successfully added
            return driver.FindElement(lastSkill).Text; 
            
            // or driver.FindElement(lastSkill)); return lastSkill.Text
            //Assert.That(lastSkill.Text == "Selenium", "Skills are not added in database! Test is Failed");

           
        }
    }
     ------------------------------------------------------------------------------------------------------------------------------
Normall hooks for opening and closing the browser with out clening
  /*    [Binding]
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
        }*/
        -----------------------------------------------------OR-----------------
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
        -------------------------------------------------------
Scenario: Add multiple languages using a table
    Given I login to skillShare portal successfully
    When I add the following languages:
      | Languages | Level            |
      | English   | Fluent           |
      | Urdu      | Native/Bilingual |
      | Punjabi   | Native/Bilingual |
      | Hindi     | Native/Bilingual |
    Then all these languages should be present in the list

    # Step Definition 
    [When(@"I add the following languages:")]
public void WhenIAddTheFollowingLanguages(Reqnroll.Table table)
{
    LSPage lSObj = new LSPage();
    foreach (var row in table.Rows)
    {
        string language = row["Languages"];
        string level = row["Level"];
        lSObj.languagePage(driver, language, level);
    }
}

[Then(@"all these languages should be present in the list")]
public void ThenAllTheseLanguagesShouldBePresentInTheList(Reqnroll.Table table)
{
    LSPage lSObj = new LSPage();
    var actualLanguages = lSObj.GetAllLanguages(driver); // Implement this to return a list of language names
    foreach (var row in table.Rows)
    {
        string language = row["Languages"];
        Assert.That(actualLanguages.Contains(language), $"Language '{language}' was not found in the list!");
    }
}

#### only for reference
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

                }
   
            //  Now Add my 3rd Skill so Click on Add New Button

            IWebElement clickOnAddNewButton3 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            clickOnAddNewButton3.Click();
            //Enter 3rd skill and choose level
            IWebElement enterThirdSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            enterThirdSkill.Clear();
            enterThirdSkill.SendKeys("Selenium");
            // click on dropdown and select level "Intermediate"
            
           
            if (lastSkill.Text == "Selenium")
            {
                Console.WriteLine(" Skills are successfully updated in database! Test is Passed ");
            }
            else
            {
                Console.WriteLine("Skills are not added in database! Test is Failed");
            }


            ************************************************************
            ************************************************************
   @order:2   @Languages @happypath

    @order:4 @negative @invalid 
 Scenario: Delete all languages
    Given I login to skillShare portal successfully
    When I delete all languages
    Then no languages should be present in the list

    @order:5 @negativeTesting 

    @order:6 @negativeTesting 
 Scenario: Delete all duplicate languages
    Given I login to skillShare portal successfully
    When I delete all languages
    Then no languages should be present in the list
    @order:7 @DestructiveTesting 

    @order:8 @negative  @validinputs

    @order:9 @negativeTesting 
 Scenario: Delete destructive languages
    Given I login to skillShare portal successfully
    When I delete all languages
    Then no languages should be present in the list

    @order:10   @skills @happypath
    @order:11 @negativeTesting @delete
Scenario: Delete all Skills one by one
    Given I login to skillShare portal successfully
    When I delete all skills one by one
    Then no skills should be present in the list



    [When(@"I create the skill '(.*)' and level '(.*)' list successfully")]
public void WhenICreateTheSkillAndLevelListSuccessfully(string skill, string level)
{
    SkilPage skilPageObj = new SkilPage();
    skilPageObj.SkillPage(driver, skill, level);
}

[When(@"I update the skill '(.*)' to '(.*)' and level to '(.*)'")]
public void WhenIUpdateTheSkillToAndLevelTo(string oldSkill, string newSkill, string newLevel)
{
    SkilPage skilPageObj = new SkilPage();
    skilPageObj.UpdateSkill(driver, oldSkill, newSkill, newLevel);
}

[Then(@"skills '(.*)' and level '(.*)' list should be created successfully")]
public void ThenSkillsAndLevelListShouldBeCreatedSuccessfully(string skill, string level)
{
    SkilPage skilPageObj = new SkilPage();
    string getLastSkill = skilPageObj.GetLastSkill(driver, skill, level);
    Assert.That(getLastSkill == skill, $"Skill '{skill}' was not added or updated! Test is Failed!");
}