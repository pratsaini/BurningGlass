using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Specflow_BDD_Example.Pages
{
    public class BasePage
    {
        public static IWebDriver _driver;
        private static string baseUrl = "https://www.burning-glass.com/";

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Type(string inputText, By locator)
        {
            Find(locator).SendKeys(inputText);
        }

        public IWebElement Find(By locator)
        {
            return WaitForElement(locator);         
        }

        public IWebElement WaitForElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(VisibilityOfElementLocated(locator));
            return _driver.FindElement(locator);
        }

        public void Wait(int milliSeconds)
        {
            Thread.Sleep(milliSeconds);
        }      

        private Func<IWebDriver, IWebElement> VisibilityOfElementLocated(By by)
        {
          
            return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by);
            
        }

        public void NavigateTo(string page)
        {
            _driver.Navigate().GoToUrl(baseUrl + page);
        }

        public void Click(By locator)
        {
            Find(locator).Click();
        }

        public void Clear(By locator)
        {
            Find(locator).Clear();
        }

        public string GetText(By locator)
        {
            return Find(locator).Text;
        }

        public bool SwitchIframeIfPresent(By iframeSelector)
        {
            IWebElement iFrame = WaitForElement(iframeSelector);

            if (iFrame != null)
            {
                _driver.SwitchTo().Frame(iFrame);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SwitchIframeByIndex(int index)
        {          
            _driver.SwitchTo().Frame(index);
        }

        public void SwitchToDefault()
        {
            _driver.SwitchTo().DefaultContent();
        }

        public void SwitchWindows(bool closeWindows)
        {
            string currentWindow = _driver.CurrentWindowHandle;
            IList<string> windowHandleList = new List<string>(_driver.WindowHandles);

            foreach (var handle in windowHandleList)
            {
                if (!handle.Equals(currentWindow))
                {
                    try
                    {
                        _driver.SwitchTo().Window(handle);
                        if (closeWindows)
                        {
                            _driver.Close();
                        }
                    }
                    catch (NoSuchWindowException e)
                    {
                        Console.WriteLine("switchWindows", e);
                    }
                }
            }

            if (closeWindows)
            {
                _driver.SwitchTo().Window(currentWindow);
            }

        }
    }
}
