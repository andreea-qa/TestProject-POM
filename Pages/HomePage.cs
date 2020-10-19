using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.SDK.Tests.Helpers;

namespace TestProject_POM.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement Name => driver.FindElement(By.CssSelector("#name"));
        private IWebElement Password => driver.FindElement(By.CssSelector("#password"));
        private IWebElement LoginButton => driver.FindElement(By.CssSelector("#login"));
        private IWebElement LogoutButton => driver.FindElement(By.CssSelector("#logout"));
        public void Login()
        {
            Name.SendKeys("John Smith");
            Password.SendKeys("12345");
            LoginButton.Click();
        }

        public bool IsLoginSuccessful()
        {
            return LogoutButton.Displayed;
        }
    }
}
