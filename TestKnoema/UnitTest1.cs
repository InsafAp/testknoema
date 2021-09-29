using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace TestKnoema
{
    public class Tests
    {
        
        private IWebDriver driver;
        private readonly By _AccesButton = By.XPath("//*[@class='menu__link ']");
        private readonly By _PersonalAccount = By.LinkText("Personal Account");
        private readonly By _Email = By.XPath("//input[@id='EMail']");
        private readonly By _Password = By.XPath("//input[@id='Password']");
        private readonly By _SignUpButton = By.XPath("//input[@value='Sign In']");
        private readonly By _SkipLink = By.LinkText("skip");
        private readonly By _userLogin = By.XPath("//*[@id='user-menu-block']");
        private readonly object expResult = "IA";
        
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://knoema.com");
        }

        [Test]
        public void Test1()
        {
            var AccesButton = driver.FindElement(_AccesButton);
            AccesButton.Click();

            var PersonalAccount = driver.FindElement(_PersonalAccount);
            PersonalAccount.Click();

            var Email = driver.FindElement(_Email);
            Email.SendKeys("insaf.ap@yandex.ru");

            var Password = driver.FindElement(_Password );
            Password.SendKeys("insaf1997");

            var SignUpButton = driver.FindElement(_SignUpButton);
            SignUpButton.Click();
            Thread.Sleep(2000);

            var Skip = driver.FindElement(_SkipLink);
            Skip.Click();
            Thread.Sleep(2000);


            var actualLogin = driver.FindElement(_userLogin).Text  ;
           

            Assert.AreEqual(expResult, actualLogin, "error");
        }
        
        [TearDown]
        public void TewrDown()
        {
            driver.Quit();
        }

    }
}
