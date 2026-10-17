using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject1.Pages
{
    public class LoginPage(IWebDriver driver)
    {
        private readonly IWebDriver _driver = driver;
        private readonly WebDriverWait _wait = new(driver, TimeSpan.FromSeconds(10));

        private IWebElement CustomerLoginBtn => _wait.Until(d => d.FindElement(By.XPath("//button[text()='Customer Login']")));
        private IWebElement UserSelect => _wait.Until(d => d.FindElement(By.Id("userSelect")));
        private IWebElement LoginBtn => _wait.Until(d => d.FindElement(By.XPath("//button[text()='Login']")));

        public void LoginAs(string customerName)
        {
            CustomerLoginBtn.Click();
            var selectElement = new SelectElement(UserSelect);
            selectElement.SelectByText(customerName);
            LoginBtn.Click();
        }
    }
}