using OpenQA.Selenium;

namespace Specflow_BDD_Example.Pages
{
    public class LandingPage : BasePage
    {
        
        By chatButton = By.CssSelector(".moveFromRightLabel-enter-done");
        By chatIframe = By.Id("tidio-chat-iframe");
        By chatHeader = By.CssSelector(".chat-header");
        By chatTextField = By.Id("new-message-textarea");
        By chatMinimize = By.Id("ic-minimize");

        public LandingPage(IWebDriver driver) : base(driver)
        {
            
        }

        public void NavigateToPage(string page)
        {
            if (page.Equals("home"))
            {
                page = "";
            }

            NavigateTo(page);
        }

        public void ClickChatButton()
        {
            SwitchIframeIfPresent(chatIframe);
            Click(chatButton);
        }

        public void VerifyChatBoxOpens()
        {
            WaitForElement(chatHeader);
        }

        public void WriteMessage()
        {
            Type("Hello", chatTextField);
            SwitchToDefault();
        }

        public void MinimizeChatBox()
        {
            Click(chatMinimize);
            SwitchToDefault();
        }



    }
}
