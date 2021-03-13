using OpenQA.Selenium;
using Specflow_BDD_Example.Pages;
using TechTalk.SpecFlow;

namespace Specflow_BDD_Example.Steps
{
    [Binding]
    public sealed class Navigation
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        private LandingPage landingPage => new LandingPage(_driver);
        private ContactPage contactPage => new ContactPage(_driver);

        public Navigation(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
        }

        [Given(@"User navigates to ""(.*)"" page")]
        public void GivenUserNavigatesToPage(string page)
        {
            landingPage.NavigateToPage(page);        
        }

        [When(@"User clicks on Chat button")]
        public void WhenUserClicksOnChatButton()
        {
           landingPage.ClickChatButton();
        }

        [When(@"Clicks on view larger map button")]
        public void WhenClicksOnViewLargerMapButton()
        {
            contactPage.ClickOnMap();
        }




    }
}
