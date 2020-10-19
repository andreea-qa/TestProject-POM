using OpenQA.Selenium;
using TestProject.Common.Enums;
using TestProject.SDK;
using TestProject.SDK.Interfaces;
using TestProject.SDK.Reporters;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;
using TestProject_POM.Pages;

namespace TestProject_POM
{
    public class LogInTest : IWebTest
    {

        ExecutionResult IWebTest.Execute(WebTestHelper helper)
        {
            var driver = helper.Driver;
            TestReporter report = helper.Reporter;
            HomePage homePage = new HomePage(driver);

            driver.Navigate().GoToUrl("https://example.testproject.io/web/");

            homePage.Login();
            helper.Reporter.Step("Logged in the app", "The login is unsuccessful", "The login is successful",
                homePage.IsLoginSuccessful(), TakeScreenshotConditionType.Always);

            if (homePage.IsLoginSuccessful())
            {
                return ExecutionResult.Passed;
            }
            return ExecutionResult.Failed;


        }
    }
}