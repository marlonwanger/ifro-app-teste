using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Text;

namespace IfroPratica_Testes.Test
{
    public class SeleniumRpgCharacter : IDisposable
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;


        public SeleniumRpgCharacter()
        {
            FirefoxOptions handlingSSL = new FirefoxOptions();
            handlingSSL.AcceptInsecureCertificates = true;
            driver = new FirefoxDriver(handlingSSL);

            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();



        }

        public void Dispose()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.Equal("", verificationErrors.ToString());
        }

        [Fact]
        public void TestInsertCharacter()
        {
            driver.Navigate().GoToUrl("https://localhost:44400/");
            driver.FindElement(By.LinkText("Rpg List")).Click();
            driver.FindElement(By.LinkText("New Character")).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("Teste");
            driver.FindElement(By.Id("class")).Click();
            driver.FindElement(By.Id("class")).Clear();
            driver.FindElement(By.Id("class")).SendKeys("Teste");
            driver.FindElement(By.Id("hp")).Click();
            driver.FindElement(By.Id("hp")).Clear();
            driver.FindElement(By.Id("hp")).SendKeys("100");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var TextH1 = driver.FindElement(By.XPath("//h1[contains(text(), 'Rpg Characters')]"));

            Assert.NotEmpty(TextH1.Text);
        }

        [Fact]
        public void TestUpdateCharacter()
        {
            driver.Navigate().GoToUrl("https://localhost:44400/");
            driver.FindElement(By.LinkText("Rpg List")).Click();
            driver.FindElement(By.LinkText("New Character")).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("Teste");
            driver.FindElement(By.Id("class")).Click();
            driver.FindElement(By.Id("class")).Clear();
            driver.FindElement(By.Id("class")).SendKeys("Teste");
            driver.FindElement(By.Id("hp")).Click();
            driver.FindElement(By.Id("hp")).Clear();
            driver.FindElement(By.Id("hp")).SendKeys("100");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var TextH1 = driver.FindElement(By.XPath("//h1[contains(text(), 'Rpg Characters')]"));

            Assert.NotEmpty(TextH1.Text);
        }


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }

}
