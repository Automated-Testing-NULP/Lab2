using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class AccountPage(IWebDriver driver)
    {
        private readonly IWebDriver _driver = driver;
        private readonly WebDriverWait _wait = new (driver, TimeSpan.FromSeconds(10));

        private IWebElement DepositMenuBtn => _wait.Until(d => d.FindElement(By.XPath("//button[contains(text(),'Deposit')]")));
        private IWebElement WithdrawMenuBtn => _wait.Until(d => d.FindElement(By.XPath("//button[contains(text(),'Withdrawl')]")));
        private IWebElement AmountInput => _wait.Until(d => d.FindElement(By.XPath("//input[@ng-model='amount']")));
        private IWebElement SubmitBtn => _wait.Until(d => d.FindElement(By.XPath("//button[@type='submit']")));
        private IWebElement MessageSpan => _wait.Until(d => d.FindElement(By.XPath("//span[@ng-show='message']")));

        public void Deposit(int amount)
        {
            DepositMenuBtn.Click();
            AmountInput.SendKeys(amount.ToString());
            SubmitBtn.Click();
            Thread.Sleep(10000);
        }

        public void Withdraw(int amount)
        {
            WithdrawMenuBtn.Click();
            Thread.Sleep(10000);
            AmountInput.SendKeys(amount.ToString());
            SubmitBtn.Click();
        }

        public string GetMessage()
        {
            Thread.Sleep(10000);
            return MessageSpan.Text;
        }
    }
}
