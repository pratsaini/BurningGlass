using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Specflow_BDD_Example.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public IWebDriver _driver;
        public Hooks(IWebDriver driver)
        {
            _driver = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Output any screenshots or log dumps etc
            _driver.Quit();
        }



    }
}
