Feature: Language and Skills 2nd Negative Destructive Scenarios
  Validate that the system handles invalid, duplicate, and destructive language inputs correctly.
@order:5 @negative @invalid
 Scenario Outline: Add language with invalid values
    Given  I login to skillShare portal successfully
	When  I create the '<Languages>'and '<Level>' list successfully
	Then language '<Languages>' and level '<Level>' should be created successfully as application accept invalid inputs gracefully
    Examples:
      | Languages | Level            |
      | 12345     | Fluent           | 
      | @#$%      | Native/Bilingual |
      | En!glish  | Fluent           | 
@order:6 @negativeTesting  
 Scenario Outline: Prevent duplicate language entry
    Given I login to skillShare portal successfully
    When I try to create duplicate languages   '<Languages>' and level '<Level>'
    Then an error message '<ErrorMesssage>' should be displayed
    Examples:
      | Languages | Level  | ErrorMessage                                          |
      | 12345     | Fluent | This language is already exist in your language list. |
           
@order:7 @negativeTesting 
 Scenario: Delete all languages
    Given I login to skillShare portal successfully
    When I delete all languages
    Then no languages should be present in the list
@order:8 @DestructiveTesting 
Scenario Outline: This test handles Destructive actions
    Given I login to skillShare portal successfully
	When I create the language '<Languages>' and level '<Level>' with destructive input
    Then the language '<Languages>' and level '<Level>' should be handled gracefully
    Examples:
      | Languages                                                                                                                                                                                                                                                              | Level            |
      | abssssbdmsadajkbdjanmsndlkajlkdsjflskjflkdjsklfdjskfjsakdjfkslfjskdfjlksjfkdsjlkdjfklsjflksdjlfsjfslkdfjlksdfjslkfjslfjdlksjfslkjdfklsjflsjflsjfldsjflsslsjfdslsljfsldjflslsdjflsjflsjfdlsjflslsdjlsjfdldsjfldsjflsjlfdsjlfjslfjlsdfjlsjflsdjfklsjkdfsjklfjlfsjdlfsjl  | Fluent           |
      | @##$$#$$%$%%$^%&%^&^&^&%^&^*&^*&*&(*(*(&*(&*&*^&^&%^%&%^$^%^&$%^$^$%#%#%$#%#$%#%#$%#%#%#%#$%#%#%$%#%$%#%#%$%#%$%#%#%#%#%#%$%^%^%&^&^&^&^&$^$%#%$#%%&&*&*(*()(_)_()*(&*&^&*^&^*^*^*%^&^&&%&%&^%$^%%^&%&*^&%&^%&%&&&%&^&*^&^&%&*^*&^**^*&(&(*(*(*(&*(*(^*^&%^&^&*^%&^&^% | Native/Bilingual |
      

@order:9 @negative  @validinputs
Scenario Outline: This test check for valid inputs e.g space
   Given I login to skillShare portal successfully
	When I create the language '<Languages>' and level '<Level>' with empty space
    Then language '<Languages>' and level '<Level>' should be created
    Examples: 
    | Languages | Level | ExpectedMessage                 |
    | eng lish   |  Fluent    | Please enter language and level | 




 
