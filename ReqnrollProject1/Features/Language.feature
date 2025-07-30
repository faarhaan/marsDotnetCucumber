Feature: Language Test cases
 This feature file lists my language skills to audience, in addition, detailed Testing is perfomed for Language features including positive, negative, and destructive scenarios.

 

Scenario Outline:@order:1  Create the lagnguage list for Employer
	Given I login to skillShare portal successfully
	And  user is in the home page
	When  I create the '<Languages>'and '<Level>' list successfully
	Then  '<Languages>' and '<Level>' list should be created successfully
	Examples: 
	| Languages | Level            |
	| English   | Fluent           |
	| Urdu      | Native/Bilingual |
	| Punjabi   | Native/Bilingual |
	| Hindi     | Native/Bilingual |

      


Scenario Outline:@order:3 Update the Language list
    Given I login to skillShare portal successfully
    When I create the language '<Languages>' and level '<Level>' list successfully
    And I update the language '<Languages>' to '<NewLanguage>' and level to '<NewLevel>'
    Then language '<NewLanguage>' and level '<NewLevel>' should be created successfully
    Examples:
      | Languages | Level            | NewLanguage | NewLevel         |
      | English   | Fluent           | Spanish     | Native/Bilingual |
      | Urdu      | Native/Bilingual | French      | Fluent           |
      | Punjabi   | Native/Bilingual | German      | Fluent           |
	  | Hindi     | Native/Bilingual | Italian     | Fluent           |




Scenario Outline:@order:4 Add language with invalid values
    Given  I login to skillShare portal successfully
	When  I create the '<Languages>'and '<Level>' list successfully
	Then language '<Languages>' and level '<Level>' should be created successfully as application accept invalid inputs gracefully
    Examples:
      | Languages | Level            |
      | 12345     | Fluent           | 
      | @#$%      | Native/Bilingual |
      | En!glish  | Fluent           | 
  
 

 Scenario Outline:@order:6 Add duplicate language entry
    Given I login to skillShare portal successfully
    When I try to create duplicate languages   '<Languages>' and level '<Level>'
    Then an error message '<ErrorMesssage>' should be displayed
    Examples:
      | Languages | Level  | ErrorMessage                                          |
      | 12345     | Fluent | This language is already exist in your language list. |
      | 12345     | Fluent | This language is already exist in your language list. |
  
 

 
Scenario Outline:@order:8   Add Destructive Data
    Given I login to skillShare portal successfully
	When I create the language '<Languages>' and level '<Level>' with destructive input
    Then the language '<Languages>' and level '<Level>' should be handled gracefully
    Examples:
      | Languages                                                                                                                                                                                                                                                              | Level            |
      | abssssbdmsadajkbdjanmsndlkajlkdsjflskjflkdjsklfdjskfjsakdjfkslfjskdfjlksjfkdsjlkdjfklsjflksdjlfsjfslkdfjlksdfjslkfjslfjdlksjfslkjdfklsjflsjflsjfldsjflsslsjfdslsljfsldjflslsdjflsjflsjfdlsjflslsdjlsjfdldsjfldsjflsjlfdsjlfjslfjlsdfjlsjflsdjfklsjkdfsjklfjlfsjdlfsjl  | Fluent           |
      | @##$$#$$%$%%$^%&%^&^&^&%^&^*&^*&*&(*(*(&*(&*&*^&^&%^%&%^$^%^&$%^$^$%#%#%$#%#$%#%#$%#%#%#%#$%#%#%$%#%$%#%#%$%#%$%#%#%#%#%#%$%^%^%&^&^&^&^&$^$%#%$#%%&&*&*(*()(_)_()*(&*&^&*^&^*^*^*%^&^&&%&%&^%$^%%^&%&*^&%&^%&%&&&%&^&*^&^&%&*^*&^**^*&(&(*(*(*(&*(*(^*^&%^&^&*^%&^&^% | Native/Bilingual |
      

 
Scenario Outline:@order:9   This test check for valid input e.g space for negative testing with valid inputs
   Given I login to skillShare portal successfully
	When I create the language '<Languages>' and level '<Level>' with empty space
    Then language '<Languages>' and level '<Level>' should be created
    Examples: 
    | Languages | Level | ExpectedMessage                 |
    | eng lish   |  Fluent    | Please enter language and level | 

















