﻿using OpenQA.Selenium;

namespace TestProject_POM.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement Name => driver.FindElement(By.CssSelector("#name"));
        private IWebElement Password => driver.FindElement(By.CssSelector("#password"));
        private IWebElement LoginButton => driver.FindElement(By.CssSelector("#login"));
        private IWebElement DisplayName => driver.FindElement(By.CssSelector("#greetings > b"));
        public void Login()
        {
            Name.SendKeys("John Smith");
            Password.SendKeys("12345");
            LoginButton.Click();
        }

        public bool IsLoginSuccessful()
        {
            return DisplayName.Text.Equals("John Smith");
        }
    }
}
