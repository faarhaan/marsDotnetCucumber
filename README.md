# marsDotnetCucumber Framework

A .NET-based test automation framework using Reqnroll (Cucumber for .NET) and Selenium WebDriver. This framework
is designed to test web applications "Mars Trading Skill Portal" with a clean, maintainable structure.

## Overview

This framework provides automated functional testing for web applications with the following features:

- **Reqnroll**: Implements Cucumber's Gherkin syntax for readable tests
- **Selenium WebDriver**: Handles browser interactions
- **NUnit**: Manages test execution and assertions
- **Page Object Model (POM)**: Separates test logic from page interactions

## Prerequisites

- **.NET SDK**: Version 8.0 or higher (install from [https://dotnet.microsoft.com/en-is/download]
- **IDE**: Visual Studio Code or Visual Studio (recommended)
             Make sure you install the '.NET Desktop Development' and 'ASP.NET and web development' workloads.
             https://www.visualstudio.com/vs/community/
- **Chrome Browser**: Required for Selenium WebDriver (ChromeDriver version must match your browser version via
  WebDriverManager)


## Project Structure

```
├── Features/           # Gherkin feature files
├── Steps/              # C# step implementations
├── Pages/              # Page Object Model classes
├── Hooks/              # Setup and teardown logic
├── Config/             # Configuration classes
└── settings.json       # Configuration file
```
## Getting Started

# Clone the repository:
git clone <repository-url>
cd marsDotnetCucumber     

Note: you have to come to folder where solution file is placed to restore dependencies

# Restore dependencies:
  Open bash editor and run the following command

  dotnet restore

# Additional Check
  If you found dependencies are not working for you so you have to do following, In visual Studio,
  Goto Project tab > Manage Nugets Pacakages > install tab
  Make sure dependencies are available here
  Note:  if you are using visual studio first time or fresh installation, you have to install one more plugin 
  Extension > Manage extensions > Browse tab > search for ReqnRoll for visual studio
  install this plugin you have to restart the application so that plugin continue remaining installation
