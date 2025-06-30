Feature: Skills

Skill Feature file lists my tech skills for audience to see plus the detail Testing of Skill Moudele in the Mars Project.
Scenario Outline:@order:11  Create My Skill list
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


  Scenario Outline:@order:13 Create and update a skill as previously skills are deleted
    Given I login to skillShare portal successfully
    When I create the Oldskill '<oldSkill>' and Oldlevel '<oldLevel>' list successfully
    And I update the Oldskill '<oldSkill>' to '<NewSkill>' and Oldlevel  to '<Level>'
    Then skills '<NewSkill>' and level '<NewLevel>' list should be created successfully

    Examples:
      | oldSkill    | oldLevel     | NewSkill |    Level     |
      | Dotnet      | Intermediate | Selenium | Expert       |
      | C-Sharp     | Intermediate | SQL      | Beginner     |     
      | Python      | Intermediate | API      | Expert       |
      | Java        | Beginner     | Postman  | Expert       |
      | Selenium    | Intermediate | Dotnet   | Expert       |
      | SQL         | Intermediate | C-Sharp  | Expert       |
      | API         | Beginner     | Python   | Expert       |
      | Postman     | Beginner     | Java     | Intermediate |

Scenario Outline:@order:14 Add skills with invalid values
   Given I login to skillShare portal successfully
   When I create the skills '<Skills>' and Level '<Level>' list successfully
	Then skills '<Skills>' and level '<Level>' should be created successfully as application accept invalid inputs gracefully
    Examples: 
    | Skills    | Level    |
    | do%$^%net | Beginner |
    | 12345     | Beginner |
    | P!thon!   | Expert   |

   

Scenario Outline:@order:15 Add duplicate Skills 
Given I login to skillShare portal successfully
When  I create duplicate Skills '<Skills>' and Level '<Level>'.
Then  error message '<ErrorMessage>' should be displayed.
Examples: 
| Skills   | Level        | ErrorMessage                                  |
| Selenium | Intermediate |                                                |
| Selenium | Intermediate | This Skill is already exist in your skill list |



Scenario Outline:@order:17  Add Destructive Data
Given I login to skillShare portal successfully
When I create the Skill '<Skills>' and level '<Level>' with destructive data
Then Skill '<Skills>' and level '<Level>' should be handled gracefully
Examples: 
| Skills                                                                                                                                                                                            | Level    |
| pythonnfsilsfkfslkfklsklfjksjfldsjkflsjflksjflkjslkjfklsjlkfjlksjlfjsdljflsjflsjlfjsljdljflsjfdlsjlfjslfjsljflsjdkslkfdjsljflksjdfkljslfjskldflsjflsdjlfjslfjsldjflsjflsjlfjlsjflsjfjsl           | Expert   |
| @#$$$$##########%%%%%%%%^$%$%%%%%%%%%%%%%&^&^&^&^&&^^&^^&^&^&^&^&^&&*^*&^*^&*^&^*(%&*($&%*^&&*^&^*&^%*^&*&%(#*($#(&%(*&%($&*%^$(^*^&^*&^*^^&^*&^*^&^*^&^*(&^(%*($)*%(^*%($&(*#&($&%(*^%(%*(%%(%*^ | Beginner |


Scenario Outline:@order:18  This test check for valid negative inputs e.g space
Given I login to skillShare portal successfully
When I create the Skills '<Skills>' and level '<Level>' with empty space
Then Skills'<Skills>' and level '<Level>' should be handled gracefully
Examples: 
| Skills   | Level  |
| Pyth on  | Expert |

