using System.Diagnostics.CodeAnalysis;
using AutomationFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomationFramework.Drivers
{
 public static class DriverFactory
    {
        public static ThreadLocal<IWebDriver> _driver= new ThreadLocal<IWebDriver>(()=>null);
        public static IWebDriver Driver=>_driver.Value;
        public static void InitDriver()
        {
            string Browser=Configreader.GetBrowser().ToLower();
            bool headless=Configreader.IsHeadless();
            switch(Browser)
            {
                case "chrome":
                    {
                        var options =new ChromeOptions();
                        if(headless)
                        {
                            options.AddArgument("--headless");
                            options.AddArgument("--window-maximize");
                        }
                        _driver.Value=new ChromeDriver(options);
                        break;
                    }
                case "firefox":
                    {
                        var options =new FirefoxOptions();
                        if(headless)
                        {
                            options.AddArgument("--headless");
                        }
                        _driver.Value=new FirefoxDriver(options);
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException($"{Browser} is not supported");
                    }
            }
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Configreader.GetBaseUrl());
        }
        public static void QuitDriver()
        {
            if(_driver!=null && _driver.IsValueCreated && _driver.Value!=null)
            {
                _driver.Value.Quit();
                _driver.Dispose();
            }
        }
    }    
}