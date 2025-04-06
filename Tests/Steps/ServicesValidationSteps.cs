using Business.Pages;
using Core.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;
using log4net;
using TechTalk.SpecFlow.Assist;

namespace Tests.Steps
{
    [Binding]
    public class ServicesValidationSteps : BaseTest
    {
        private HomePage homePage;
        private ServicePage servicePage;
        protected static readonly ILog log = Logger.GetLogger<ServicesValidationSteps>();

        public ServicesValidationSteps(ScenarioContext scenarioContext) : base(scenarioContext) { }


        [When(@"I hover over the ""(.*)"" menu")]
        public void WhenIHoverOverTheMenu(string services0)
        {
            homePage = new HomePage(driver, wait);
            homePage.HoverOverServicesLink();
        }

        [When(@"I select the ""(.*)"" option")]
        public void WhenISelectTheOption(string p0)
        {
            servicePage = homePage.SelectServiceByName(p0);  
        }

        [Then(@"I should see the page with the title the ""(.*)""")]
        public void ThenIShouldSeeThePageWithTheTitleThe(string service)
        {
            var titleExists = servicePage.VerifyServiceTitleInPage(service);
            Assert.That(titleExists, Is.True, $"The title {service} was not found on the page.");
        }

        [Then(@"the Our Related Expertise section should be displayed on the page")]
        public void ThenTheSectionShouldBeDisplayedOnThePage()
        {
            var sectionExists = servicePage.VerifyRelatedExpertiseSection();
            log.Info($"Related Expertise section exists: {sectionExists}");
            Assert.That(sectionExists, Is.True, $"The section our Related Expertise was not found on the page.");
        }
    }

}
