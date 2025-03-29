using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Interfaces;
using log4net;
using TechTalk.SpecFlow;
using Core.Driver;

namespace Tests.Steps
{
    [Binding]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected WebDriverWait waitShort;
        protected WebDriverWait waitLong;
        protected WebDriverWait fluentWait;
        protected Actions actions;
        protected string downloadDirectory;
        private static readonly ILog log = Logger.GetLogger<BaseTest>();
        private ScenarioContext scenarioContext;

        public BaseTest(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [BeforeScenario]
        public void SetUp()
        {
            downloadDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            string Browser = "chrome";
            bool Headless = false;
            
            driver = DriverFactory.GetDriver(Browser, downloadDirectory, Headless);

            waitShort = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitLong = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            actions = new Actions(driver);
            ValidateSetup();
        }

        private void ValidateSetup()
        {
            if (driver == null) throw new Exception("Error: WebDriver was not initialized.");
            if (wait == null) throw new Exception("Error: WebDriverWait was not initialized.");
            if (actions == null) throw new Exception("Error: Actions was not initialized.");
        }

        [AfterScenario]
        public void TearDown()
        {
            DriverFactory.CloseDriver();
        }
    }
}
