using Business.Pages;
using Core.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;
using log4net;

namespace Tests.Steps
{
    [Binding]
    public class DownloadFileSteps : BaseTest
    {
        private HomePage homePage;
        private AboutPage aboutPage;
        protected static readonly ILog log = Logger.GetLogger<DownloadFileSteps>();

        public DownloadFileSteps(ScenarioContext scenarioContext) : base(scenarioContext) { }


        [When(@"I select the About nav menu option")]
        public void GivenISelectTheMenuOption()
        {
            homePage = new HomePage(driver, wait);
            aboutPage = homePage.GoToPage<AboutPage>("About");
        }

        [When(@"I scroll down to the EPAM at a Glance section")]
        public void GivenIScrollDownToTheSection()
        {
            aboutPage.ScrollToGlanceSection();
        }

        [When(@"I click on the Download button")]
        public void GivenIClickOnTheButton()
        {
            aboutPage.DownloadGlanceFile();
        }

        [Then(@"I should wait until the file ""(.*)"" is downloaded")]
        public void ThenIShouldWaitUntilTheFileIsDownloaded(String fileName)
        {
            string glanceFile = Path.Combine(downloadDirectory, fileName);
            bool fileExists = BrowserUtils.WaitForFileDownload(glanceFile, 5);


            if (fileExists)
            {
                log.Info($"File {fileName} was downloaded successfully.");
                File.Delete(glanceFile);
                Assert.Pass("File was downloaded successfully.");
            }

            log.Error($"File {fileName} was not downloaded.");
            Assert.Fail("File was not downloaded.");
        }
    }

    }
