using NUnit.Framework;
using TestProject.Common.Enums;
using TestProject.SDK;
using System;

namespace TestProject_POM
{
    public class LogInTests
    {
        Runner runner;
        private string DevToken = Environment.GetEnvironmentVariable("TP_DEV_TOKEN");

        [OneTimeSetUp]
        public void SetUp()
        {
            runner = new RunnerBuilder(DevToken).AsWeb(AutomatedBrowserType.Chrome).Build();
        }

        [Test]
        public void Login()
        {
            runner.Run(new LogInTest());
        }

        //[Test]
        public void TestInvalidLogin()
        {
            runner.Run(new LogInTest());
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            runner.Dispose();
        }
    }
}