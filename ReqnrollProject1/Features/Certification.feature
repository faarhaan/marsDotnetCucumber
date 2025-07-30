Feature: Certification

These scenariois are build to detail testing for certification Module in Skill Trade application

@tag6
Scenario Outline: Create the Certification List
	Given I login to skillShare portal successfully
	And user is in the home page
	When  I create the certification '< Certificate >' ,certifiedFrom '<From>' and  year '< Year >'
	Then  certification '< Certificate >' ,certifiedFrom '<From>' and year '< Year >' should be created successfully
	Examples: 
	| Certificate | From     | Year |
	| ISTQB       | LinkedIn | 2024 |
	| SQL         | Coursera | 2025 |
	| Python      | LinkedIN | 2024 |
	| Java        | Udemy    | 2024 |

@tag7
Scenario Outline: Create and update a Certification as previously one I have deleted to obtain a clean state
    Given I login to skillShare portal successfully
    When I create the old certificate '<oldCertificate>', old certifiedfrom '<oldFrom>' and  '<oldYear >'  list successfully
	And I update the old certifiate  '<oldCertificate>' to '<newCertificate>',old certifiedFrom  to '<newFrom>' and old Year to '<newYear>'
    Then certification '<newCertificate>', certifiedFrom '<newFrom>' and Year '< newYear>' list should be created successfully
	Examples: 
	| oldCertificate | oldFrom  | oldYear | newCertificate | newFrom     | newYear |
	| ISTQB          | LinkedIn | 2024    | SQL            | Coursera    | 2025    |

@tag8
Scenario Outline: Create the Certificate List with invalid values
	Given I login to skillShare portal successfully
	And user is in the home page
	When  I create the certificate '< Certificate >' ,from '<From>' and Year'< Year >'
	Then  certificate '< Certificate >' ,from '<From>',  and Year'< Year >' should be created successfully as application accept invalid inputs gracefully
	Examples: 
	| Certificate| From      |Year    | 
	| Sq%^&LLLLL | Co%$^rsea | 2023   |
	| 12345      | Link^GGHHH| 2024   |

@tag9
Scenario Outline: Create the Certificate List with Destructive Data
Given I login to skillShare portal successfully
	And user is in the home page
	When  I create the certification '< Certificate >' ,certifiedFrom '<From>' and  year '< Year >'.
	Then certification '< Certificate >' ,certifiedFrom '<From>' and year '< Year >' should be created successfully as application handled destructive data gracefully
	Examples: 
	| Certificate                                                                                                                                                                                                                                                  | From     | Year |
	| ISTQB *****#$&#$@#@#%$#^$^%^%$%^$^$%&%^*&*^&*^&*^&*^&*&^*^(&)#%)#$*%$@)*%)@*%)@*)%*)$#^)$#*%)#^@^&)@*)#@*)*%)@#%@&%)@&$)@&%)@&%)@&%)@&%)@&%)$@&#&@)$#&)$%&)#@&%)@#&%)@&%)@&%)@&%)@&%)@$%&)T)$$&)$#)@&%)@&%)@%&@%&)@&%)#$@&%$)@%)$^&)^*)%$)^*)$)^*$)^^istqbb  | LinkedIn | 2024 |
	| SQ)()()())))))(((((((((((((((((((((((((((((((())))))))))))))))))))))))))()))))))))*)!))))))))))))))))))))))!*#)!#*!)*@)*!_!*#_!*#)!@#*!)$@)%*#)$#%^$*)#%@)%*@_#%@$#)%*#)$^$#*^#$^)#*$)#^#*$)#^*)#*)^$*)^*#$)^*#)^*#)$^*%)&^)#$*%$)#*$^)#*$#*)$%*#)%%$#)%#$)% | coursera | 2025 |

@tag10
Scenario Outline:@order:18  This test check for valid negative inputs e.g space
Given I login to skillShare portal successfully
And user is in the home page
When  I create the certification '< Certificate >' ,certifiedFrom '<From>' and  year '< Year >'. 
Then  certification '< Certificate >' ,certifiedFrom '<From>' and year '< Year >' should be created successfully.
Examples: 
| Certificate       | From          | Year |
| IST    QB         | LinkedIn      | 2024 |



