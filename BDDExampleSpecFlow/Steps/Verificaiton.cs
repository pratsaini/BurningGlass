using OpenQA.Selenium;
using Specflow_BDD_Example.Pages;
using TechTalk.SpecFlow;

namespace Specflow_BDD_Example.Steps
{
    [Binding]
    public sealed class Verificaiton
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        private LandingPage landingPage => new LandingPage(_driver);
        private ContactPage contactPage => new ContactPage(_driver);

        public Verificaiton(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
        }

        [Then(@"the chat box should open")]
        public void ThenTheChatBoxShouldOpen()
        {
            landingPage.VerifyChatBoxOpens();
        }

        [Then(@"User can (.*) the chat box")]
        public void ThenUserCanTheChatBox(string action)
        {
            if (action.Equals("Write Text"))
                landingPage.WriteMessage();
            else
                landingPage.MinimizeChatBox();          
        }

        [Then(@"A new window with map is open")]
        public void ThenANewWindowWithMapIsOpen()
        {
            contactPage.GetMapWindow();
        }
    }
}
