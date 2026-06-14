

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SeleniumFirstTest
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            // driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
           
        }


        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
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
