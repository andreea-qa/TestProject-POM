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
    public class InvalidLoginTest : IWebTest
    {
        ExecutionResult IWebTest.Execute(WebTestHelper helper)
        {
            var driver = helper.Driver;
            TestReporter report = helper.Reporter;
            HomePage homePage = new HomePage(driver);

            driver.Navigate().GoToUrl("https://example.testproject.io/web/");

            homePage.Login("Invalid Login", "1234");
            helper.Reporter.Step("Incorrect password messsage", "The message is not displayed", "The message is displayed",
                homePage.IsPasswordIncorrectMessageDisplayed(), TakeScreenshotConditionType.Always);

            if (homePage.IsPasswordIncorrectMessageDisplayed())
            {
                return ExecutionResult.Passed;
            }
            return ExecutionResult.Failed;
        }
    }
}