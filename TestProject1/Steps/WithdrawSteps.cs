using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TestProject1.Pages;

namespace TestProject1.Steps
{
    [Binding]
    public class WithdrawSteps
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private AccountPage _accountPage;

        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _loginPage = new LoginPage(_driver);
            _accountPage = new AccountPage(_driver);
        }

        [Given(@"I navigate to the Banking application")]
        public void GivenINavigateToTheBankingApplication()
        {
            _driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject");
        }

        [Given(@"I login as customer ""(.*)""")]
        public void GivenILoginAsCustomer(string customerName)
        {
            _loginPage.LoginAs(customerName);
        }

        [Given(@"I deposit (.*) to my account")]
        public void GivenIDepositToMyAccount(int amount)
        {
            _accountPage.Deposit(amount);
        }

        [When(@"I withdraw (.*) from my account")]
        public void WhenIWithdrawFromMyAccount(int amount)
        {
            _accountPage.Withdraw(amount);
        }

        [Then(@"I should see a ""(.*)"" message")]
        public void ThenIShouldSeeAMessage(string expectedMessage)
        {
            string actualMessage = _accountPage.GetMessage();
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
