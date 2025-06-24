Feature: Language and Skills 1st Positvie Scenarios
 This proram will alllow users to see my  Skills, Langauages, Certification details.

@order:1  @Languages @happypath @and-with-additional-parameters
Scenario Outline: Create the lagnguage list for Employer
	Given I login to skillShare portal successfully
	When  I create the '<Languages>'and '<Level>' list successfully
	Then  '<Languages>' and '<Level>' list should be created successfully
	Examples: 
	| Languages | Level            |
	| English   | Fluent           |
	| Urdu      | Native/Bilingual |
	| Punjabi   | Native/Bilingual |
	| Hindi     | Native/Bilingual |

@order:2  @Languages @happypath
Scenario: Delete all languages
    Given I login to skillShare portal successfully
    When I delete all languages
    Then no languages should be present in the list

@order:3   @skills @happypath
Scenario Outline: Create My Skill list
    Given I login to skillShare portal successfully
	When I create the skill '<Skills>'and level'<Level>' list successfully
	Then skills '<Skills>' and level'<Level>' list should be created successfully
	Examples: 
	| Skills   | Level        |
	| Dotnet   | Intermediate |
	| C-Sharp  | Intermediate |
	| Python   | Intermediate |
	| Java     | Beginner     |
	| Selenium | Intermediate |
	| SQL      | Intermediate |
	| API      | Beginner     |
	| Postman  | Beginner     |

@order:4 @negativeTesting @delete
Scenario: Delete all Skills one by one
    Given I login to skillShare portal successfully
    When I delete all skills one by one
    Then no skills should be present in the list
















