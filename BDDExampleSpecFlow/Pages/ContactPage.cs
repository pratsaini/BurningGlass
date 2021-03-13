using OpenQA.Selenium;

namespace Specflow_BDD_Example.Pages
{
    public class ContactPage : BasePage
    {
        By mapIframe = By.CssSelector("iframe[src*='google.com/maps']");
        By viewLargerMap = By.CssSelector(".google-maps-link a");

        public ContactPage(IWebDriver driver) : base(driver)
        {
            
        }

        public void ClickOnMap()
        {
            Wait(500);
            SwitchIframeIfPresent(mapIframe);
            Click(viewLargerMap);
            //Assertions
        }

        public void GetMapWindow()
        {
            SwitchWindows(false);
            //Assertions
        }

    }
}
