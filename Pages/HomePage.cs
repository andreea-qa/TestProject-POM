using OpenQA.Selenium;

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

        private IWebElement IncorrectPasswordMessage => driver.FindElement(By.CssSelector("#password ~div"));
        public void Login(string name, string password)
        {
            Name.SendKeys(name);
            Password.SendKeys(password);
            LoginButton.Click();
        }

        public bool IsLoginSuccessful()
        {
            return DisplayName.Text.Equals("John Smith");
        }

        public bool IsPasswordIncorrectMessageDisplayed()
        {
            return IncorrectPasswordMessage.Text.Equals("Password is invalid");
        }
    }
}
