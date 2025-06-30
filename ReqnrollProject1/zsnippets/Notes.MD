// For more than 1 Features files and you want to disable 1, 
    use tag @ignore at top of feature file

// For more than 1 StepDefinition files and you want to disable 1,
    comment the [Binding] with //
    e.g  //[Binding]      
    now stepdefinition is disable, Good Practice you create more than 1 Feature file but keep only 1 StepDefinition file
    as it generates confilict of "Ambiguious statement"


    Scenario:@order:2   Delete all languages
    Given I login to skillShare portal successfully
    When I delete all languages
    Then no languages should be present in the list


    Scenario:@order:5   Delete all languages
    Given I login to skillShare portal successfully
    When I delete all languages
    Then no languages should be present in the list

    Scenario:@order:7  Delete all duplicate languages
    Given I login to skillShare portal successfully
    When I delete all languages
    Then no languages should be present in the list


    Scenario:@order:10  Delete all destructive and with space languages
    Given I login to skillShare portal successfully
    When I delete all languages
    Then no languages should be present in the list

        Scenario: order:12  Delete all Skills
    Given I login to skillShare portal successfully
    When  I delete all skills one by one
    Then no skills should be present in the list


    Scenario:@order:15    Delete all skills
    Given I login to skillShare portal successfully
    When I delete all skills one by one
	Then no skills should be present in the list 

    Scenario:@order:16 Delete all duplicate Skills
    Given I login to skillShare portal successfully
    When I delete all skills one by one
	Then no skills should be present in the list

    Scenario:@order:17 Delete all duplicate Skills
    Given I login to skillShare portal successfully
    When I delete all skills one by one
	Then no skills should be present in the list