using Business.Pages;
using Core.Driver;
using Core.Utils;
using log4net;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static System.Collections.Specialized.BitVector32;

namespace Tests.Steps
{
    [Binding]
    public class DownloadFileSteps : BaseTest
    {
        private HomePage homePage;
        private AboutPage aboutPage;
        protected static readonly ILog log = Logger.GetLogger<DownloadFileSteps>();

        public DownloadFileSteps(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I navigate to the EPAM homepage")]
        public void GivenINavigateToTheEPAMHomepage()
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");
            homePage = new HomePage(driver, wait);
        }

        [Given(@"I select the ""(.*)"" menu option")]
        public void GivenISelectTheMenuOption(string menuOption)
        {
            aboutPage = homePage.GoToPage<AboutPage>(menuOption);
        }

        [Given(@"I scroll down to the EPAM at a Glance section")]
        public void GivenIScrollDownToTheSection()
        {
            aboutPage.ScrollToGlanceSection();
        }

        [Given(@"I click on the Download button")]
        public void GivenIClickOnTheButton()
        {
            aboutPage.DownloadGlanceFile();
        }

        [Then(@"I should wait until the file ""(.*)"" is downloaded")]
        public void ThenIShouldWaitUntilTheFileIsDownloaded(String fileName)
        {
            string glanceFile = Path.Combine(downloadDirectory, fileName);
            bool fileExists = BrowserUtils.WaitForFileDownload(glanceFile, 5);
            
            if (!fileExists) Assert.Fail($"File {fileName} was not downloaded.");
            log.Info($"File {fileName} exists: {fileExists}");
        }
        }

    }
