Feature: Education

These scenariois are build to detail testing for education Module in Skill Trade application

@tag1
Scenario Outline: Create the Education List
	Given I login to skillShare portal successfully
	And user is in the home page
	When  I create the university '< University >' ,country '<Country>',  title '< Title >', degree '<Degree >' and graduationYear'< GraduationYear >'
	Then  university '< University >' ,country '<Country>',  title '< Title >', degree '<Degree >' and graduationYear'< Graduation Year >' should be created successfully
	Examples: 
	| University    | Country   | Title  | Degree      | GraduationYear |
	| Gordon        | Australia | B.Sc   | Science     | 2010           |
	| Uni-of-Germ   | Germany   | M.Tech | Computer Sc | 2013           |
	| Quaid-i-Azam  | Pakistan  | B.A    | Science     | 2007           |
	| GordonCollege | Pakistan  | B.A    | Computer Sc | 2003           |
@tag2
Scenario Outline: Create and update a education as previously one I have deleted to obtain a clean state
    Given I login to skillShare portal successfully
    When I create the old university '<oldUniversity>', old country '<oldCountry>' ,  '<oldTitle >' ,'<oldDegree >' and '<oldGraduationYear >' list successfully
	And I update the old university  '<oldUniversity>' to '<University>',old country  to '<Country>' , old title to '<Title>', old degree to '<Degree>' and old graduation year to '<GraduationYear>'
    Then University '<University>', country '<Country>' , title '<Title >',degree '<Degree >' and graduationYear '< GraduationYear>' list should be created successfully
	Examples: 
	| oldUniversity | oldCountry | oldTitle | oldDegree | oldGraduationYear | University    | Country    | Title    | Degree      | GraduationYear  |
	| Gordon        | Germany    | B.Sc     | Science   | 2010              | Uni-of-Melb   |  Australia | B.A      | Computer-Sc | 2013            |
	| Uni-of-Germ   | Germany    | M.Tech | Computer Sc | 2013              |  Gordon      | Australia   | B.Sc     | Science     | 2010            |

@tag3
Scenario Outline: Create the Education List with invalid values
	Given I login to skillShare portal successfully
	And user is in the home page
	When  I create the university '< University >' ,country '<Country>',  title '< Title >', degree '<Degree >' and graduationYear'< GraduationYear >'
	Then  university '< University >' ,country '<Country>',  title '< Title >', degree '<Degree >' and graduationYear'< Graduation Year >' should be created successfully as application accept invalid inputs gracefully
	Examples: 
	| University | Country   | Title  | Degree  | GraduationYear |
	| go%$^%don  | Australia | B.Sc   | Scien** | 2010           |
	| 12345      | Germany   | M.Tech | ar***TS | 2013           |

@tag4
Scenario Outline: Create the Education List with Destructive Data
	Given I login to skillShare portal successfully
	And user is in the home page
	When  I create the destructive data university '< University >' ,country '<Country>',  title '< Title >', degree '<Degree >' and graduationYear'< GraduationYear >'
	Then  university '< University >' ,country '<Country>',  title '< Title >', degree '<Degree >' and graduationYear'< Graduation Year >' should be created successfully as application handled destructive data graacefully
	Examples: 
	| University                                                                                                                                                                                         | Country   | Title | Degree  | GraduationYear |
	| Gordonlllllllllllllllllllllllllljigiusgaiugduiagduiahudhusahudgaidhaiusudiuagsfiaugsfuaifugaiugfsaiugfiaugfiuasgfiagfuisaufgiaufgaiugiufsgaiufaiufguaisgfaifaifgaiuaiufgiaufgaifuagfaifgauaigf     | Australia | B.Sc  | Science | 2010           |
	| @#$SFSF#$@%#@@(&%(@&(%#)@)%#&@)&#%)&@&%)@#%&)@&%)@&%)@&#%)@&%&)@&%)@%*_@)%#_@)&%)@#&%)@#(%*(@&%*@)%#*@#&%@*#&%@*)&%*@)%#&@#)(&%(@)#%(@)#%&*^)*$*&$(@_#%&@#%&@_%&(@_%&@_(%&@(_&@(%&@#_(%&@#_(#&%@(_ | Australia | B.Sc  | Arts    | 2010           |

@tag5
Scenario Outline:@order:18  This test check for valid negative inputs e.g space
Given I login to skillShare portal successfully
And user is in the home page
	When  I create the destructive data university '< University >' ,country '<Country>',  title '< Title >', degree '<Degree >' and graduationYear'< GraduationYear >'
	Then space in university '< University >' ,country '<Country>',  title '< Title >', degree '<Degree >' and graduationYear'< Graduation Year >' should be created successfully as application handled destructive data graacefully
Examples: 
| University         | Country   | Title  | Degree  | GraduationYear |
| Uni of  Melbourne  | Australia | B.Sc   | Scien** | 2010           |

    