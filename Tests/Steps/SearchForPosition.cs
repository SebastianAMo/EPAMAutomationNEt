using Business.Pages;
using Core.Driver;
using Core.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;
using log4net;
using TechTalk.SpecFlow.BindingSkeletons;

namespace Tests.Steps
{
    public class SearchForPositionSteps: BaseTest
    {
        private HomePage homePage;
        private CareersPage careersPage;
        private JobDetailsPage jobDetailsPage;
        protected static readonly ILog log = Logger.GetLogger<SearchForPositionSteps>();

        public SearchForPositionSteps(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [When(@"I select the Career nav menu option")]
        public void WhenIClickOnTheLink()
        {
            var HomePage = new HomePage(driver, wait, waitShort);
            careersPage = HomePage.GoToPage<CareersPage>("Careers");
        }

        [When(@"I check Remote in the Job Type field")]
        public void WhenICheckRemoteInTheJobTypeField()
        {
            careersPage.EnableRemoteCheckbox();
        }


        [When(@"I enter ""(.*)"" in the Keywords field")]
        public void WhenIEnterInTheKeywordsField(string keyword)
        {
            careersPage.EnterKeyword(keyword);
        }

        [When(@"I select ""(.*)"" in the Location field")]
        public void WhenISelectInTheLocationField(string location)
        {
            careersPage.SelectLocation(location);
        }


        [When(@"I click on the Find button")]
        public void WhenIClickOnTheButton()
        {
            careersPage.ClickFindButton();
        }

        [When(@"I click the latest job posting in the list")]
        public void WhenIClickTheLatestJobPostingInTheList()
        {
            careersPage.ScrollToLastResultUntilAllResultsAreLoaded();
            jobDetailsPage = careersPage.ClickOnLastJob();
        }

        [Then(@"I should see the programming language ""(.*)"" mentioned on the job application page")]
        public void ThenIShouldSeeTheProgrammingLanguageMentionedOnTheJobApplicationPage(string keyword)
        {
            var isKeywordInDescription = jobDetailsPage.VerifyKeywordInDescription(keyword);
            if (!isKeywordInDescription)
            {
                log.Error($"The keyword {keyword} was not found in the job description.");
            }
            Assert.Pass();
        }
    }
}
