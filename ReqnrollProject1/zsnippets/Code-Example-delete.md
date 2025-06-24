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