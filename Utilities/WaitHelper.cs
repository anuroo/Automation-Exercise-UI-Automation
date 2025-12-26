using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework.Utilities
{
    public class WaitHelper
    {
        public static IWebElement WaitForElementToBeVisible(IWebDriver driver,int TimeOutInSeconds,By Locator)
        {
            var wait= new WebDriverWait(driver,TimeSpan.FromSeconds(TimeOutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Locator));
        }     
    }
}