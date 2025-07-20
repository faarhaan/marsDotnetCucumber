using mars.Utilities;
using Reqnroll;
using System;

namespace ReqnrollProject1.StepDefinitions
{
    //[Binding]
    public class EducationStepDefinitions : CommonDriver
    {
        [When("I create the country {string}, university {string} , title {string}, degree {string} and graduationYear{string}")]
        public void WhenICreateTheCountryUniversityTitleDegreeAndGraduationYear(string Country, string University, string Title, string Degree, string GraduationYear)
        {
            throw new PendingStepException();
        }

        [Then("country {string}, university {string} , title {string}, degree {string} and graduationYear{string} should be created successfully")]
        public void ThenCountryUniversityTitleDegreeAndGraduationYearShouldBeCreatedSuccessfully(string Country, string University, string Title, string Degree, string GraduationYear)
        {
            throw new PendingStepException();
        }

    }
}
