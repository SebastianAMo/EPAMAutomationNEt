using System.Configuration;
using Core.Driver;
using Core.Utils;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Microsoft.Extensions.Configuration;


[assembly: Parallelizable(ParallelScope.Fixtures)]

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
        private readonly ISpecFlowOutputHelper? specFlowOutputHelper;

        public BaseTest(ScenarioContext scenarioContext, ISpecFlowOutputHelper? specFlowOutputHelper = null)
        {
            this.scenarioContext = scenarioContext;
            this.specFlowOutputHelper = specFlowOutputHelper;
        }


        [BeforeScenario]
        public void SetUp()
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

            downloadDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            string Browser = config["BrowserType"] ?? "edge";
            log.Info($"Browser: {Browser}");
            bool Headless = config[config["Headless"] ?? "false"] == "true";
            log.Info($"Headless: {Headless}");

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

        [AfterStep()]
        public void TakeScreenshotAfterEachStep()
        {

            if (driver is ITakesScreenshot screenshotTaker)
            {
                var filename = Path.ChangeExtension(Path.GetRandomFileName(), "png");

                screenshotTaker.GetScreenshot().SaveAsFile(filename);

                specFlowOutputHelper?.AddAttachment(filename);
            }
        }
    }
}
