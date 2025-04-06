using Business.Pages;
using Core.Utils;
using log4net;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Tests.Steps
{
    internal class GlobalSearchSteps : BaseTest
    {
        private HomePage homePage;
        private static readonly ILog log = Logger.GetLogger<GlobalSearchSteps>();
        public GlobalSearchSteps(ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper) : base(scenarioContext, specFlowOutputHelper) { }

        [When(@"I click on the magnifier icon")]
        public void WhenIClickOnTheMagnifierIcon()
        {
            homePage = new HomePage(driver, wait, waitShort);
            homePage.ClickSearchIcon();
        }

        [When(@"I enter ""(.*)"" in the search input field")]
        public void WhenIEnterSearchTermInTheSearchInputField(string searchTerm)
        {
            homePage.PerformSearch(searchTerm);
        }

        [When(@"I click the ""Find"" button")]
        public void WhenIClickTheFindButton()
        {

            homePage.ClickSearchButton();
        }

        [Then(@"I should see a list of search results")]
        public void ThenIShouldSeeAListOfSearchResults()
        {
            homePage.ScrollToLastResultUntilAllResultsAreLoaded();
            var searchResults = homePage.GetResultElements();
            if (searchResults.Count == 0)
            {
                Assert.Fail("No search results were found.");
            }
        }

        [Then(@"all the links in the search results should contain ""(.*)"" in the text")]
        public void ThenAllTheLinksInTheSearchResultsShouldContainSearchTerm(string searchTerm)
        {
            var results = homePage.GetResultElements();

            var isSearchResultsValid = results.All(e => e.Text.ToLower().Contains(searchTerm.ToLower()));


            if (!isSearchResultsValid)
            {
                log.Warn("Search results that do not contain the search term:");
                foreach (var element in results)
                {
                    if (!element.Text.ToLower().Contains(searchTerm.ToLower()))
                    {
                        log.Warn(element.Text);
                    }
                }

                Assert.Fail("Not all search results contain the search term.");
            }

            Assert.Pass("All search results contain the search term.");
        }
    }

}
