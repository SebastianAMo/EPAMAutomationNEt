using Business.Pages;
using Core.Driver;
using NUnit.Framework;
using TechTalk.SpecFlow;
using log4net;


namespace Tests.Steps
{
    public class ArticleTitleValidationSteps : BaseTest
    {
        private HomePage homePage;
        private InsightsPage insightsPage;
        private ArticlePage articlePage;
        private string articleTitle;
        protected static readonly ILog log = Logger.GetLogger<ArticleTitleValidationSteps>();
        public ArticleTitleValidationSteps(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [When(@"I select the Insights menu option")]
        public void WhenISelectTheInsightsMenuOption()
        {
            homePage = new HomePage(driver, wait, waitShort);
            insightsPage = homePage.GoToPage<InsightsPage>("Insights");
        }

        [When(@"I swipe the carousel (.*) times and to the right")]
        public void WhenISwipeTheCarouselTimesAndToTheRight(int p0)
        {
            insightsPage.SwipeCarousel(p0);
        }

        [When(@"I click on the Read More button")]
        public void WhenIClickOnTheReadMoreButton()
        {
            articleTitle = insightsPage.GetActiveArticleTitle();
            articlePage = insightsPage.ClickReadMoreButton();
        }

        [Then(@"the title of the article should match the title I noted previously")]
        public void ThenTheTitleOfTheArticleShouldMatchTheTitleINotedPreviously()
        {
            
            string articlePageTitle = articlePage.GetArticleTitle();
            log.Info($"Article Title Carousel: {articleTitle}");
            log.Info($"Article Page Title: {articlePageTitle}");
            Assert.That(articlePageTitle, Is.EqualTo(articleTitle));
        }
    }
}
