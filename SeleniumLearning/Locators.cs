using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    public class Locators
    {

        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), "149.0.7827.201");
            
            driver = new ChromeDriver();
            //impilcit waits - globally
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }


        [Test]
        public void Test1()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("Learning@830$3mK2");
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            //ewentualnie css(.text-info span:nth-child(1)  input)

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d =>
            {
                var btn = d.FindElement(By.CssSelector("#signInBtn"));
                return btn.GetAttribute("value").Contains("Signing");
            });

            

            String errorMessage = driver.FindElement(By.XPath("//div[@class='alert alert-danger col-md-12']")).Text;
            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttr = link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/documents-request";

            

            Assert.AreEqual(expectedUrl, hrefAttr);
            //Assert.AreEqual("Incorrect username/password.", errorMessage);



        }


        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();//1 window
            driver.Quit();//2 windows
            //driver.Dispose();

        }

    }
}
