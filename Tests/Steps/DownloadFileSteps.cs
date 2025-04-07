using Business.Pages;
using Core.Utils;
using log4net;
using NUnit.Framework;
using TechTalk.SpecFlow;

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

            if (!fileExists) Assert.Fail($"File {fileName} was not downloaded.");
            log.Info($"File {fileName} exists: {fileExists}");
            File.Delete(glanceFile);
        }
    }

}
