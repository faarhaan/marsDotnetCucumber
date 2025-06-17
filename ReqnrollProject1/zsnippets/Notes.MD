// For more than 1 Features files and you want to disable 1, 
    use tag @ignore at top of feature file

// For more than 1 StepDefinition files and you want to disable 1,
    comment the [Binding] with //
    e.g  //[Binding]      
    now stepdefinition is disable, Good Practice you create more than 1 Feature file but keep only 1 StepDefinition file
    as it generates confilict of "Ambiguious statement"