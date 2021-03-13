using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace Specflow_BDD_Example.Utils
{
    [Binding]
    public class WebDriverSupport
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        public IWebDriver SetupWebDriver()
        {
            var browser = ConfigurationManager.AppSettings.Get("Browser");
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            if (browser.Equals("Chrome"))
                _driver = new ChromeDriver(path);
            else if (browser.Equals("Firefox"))
                _driver = new FirefoxDriver(path);
            
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return _driver;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var webDriver = SetupWebDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
        }
    }

}
