using TestProject.Common.Enums;
using TestProject.SDK;
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
            string username = "John Smith";
            string password = "12345";
            var driver = helper.Driver;
            TestReporter report = helper.Reporter;
            HomePage homePage = new HomePage(driver);

            driver.Navigate().GoToUrl("https://example.testproject.io/web/");

            homePage.Login(username, password);
            helper.Reporter.Step("Logged in the app", "The login is unsuccessful", "The login is successful",
                homePage.IsUserLoggedIn(username), TakeScreenshotConditionType.Always);

            if (homePage.IsUserLoggedIn(username))
            {
                return ExecutionResult.Passed;
            }
            return ExecutionResult.Failed;
        }
    }
}