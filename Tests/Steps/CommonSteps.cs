using TechTalk.SpecFlow;


namespace Tests.Steps
{
    [Binding]
    public class BaseSteps : BaseTest
    {
        public BaseSteps(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I am on the EPAM homepage")]
        public void GivenIAmOnTheEPAMHomepage()
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");      
        }
    }
}

