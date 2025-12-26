using System.Xml.Schema;
using AutomationFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;

namespace AutomationFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected IJavaScriptExecutor js;
        public BasePage(IWebDriver driver)
        {
            Driver= driver;
            js=(IJavaScriptExecutor)Driver;
        }

        public IWebElement WaitForElementToBeVisible(By locator,int timeOutInSeconds)
        {
            return WaitHelper.WaitForElementToBeVisible(Driver,timeOutInSeconds,locator);
        }
        public IWebElement WaitForElementToBeClickable(By locator,int timeOutInSeconds)
        {
            var wait= new WebDriverWait(Driver,TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public void Click(By locator,int timeOutInSeconds)
        {
            WaitForElementToBeClickable(locator,timeOutInSeconds).Click();
        }
        public void ClickJS(By locator,int timeOutInSeconds)
        {
            var element= WaitForElementToBeClickable(locator,timeOutInSeconds);
            js.ExecuteScript("arguments[0].click();",element);
        }
        public void EnterText(By locator,string text,int timeOutInSeconds)
        {
            var element=WaitForElementToBeVisible(locator,timeOutInSeconds);
            element.Clear();
            element.SendKeys(text);
        }
        public void ScrollToElement(By locator,int timeOutInSeconds)
        {
            var element=WaitForElementToBeVisible(locator,timeOutInSeconds);
            js.ExecuteScript("arguments[0].scrollIntoView(true);",element);
        }
        public string GetElementText(By locator,int timeOutInSeconds)
        {
            var element=WaitForElementToBeVisible(locator,timeOutInSeconds);
            return element.Text;
        }
        public void HoverOverElement(By locator,int timeOutInSeconds)
        {
            var element=WaitForElementToBeVisible(locator,timeOutInSeconds);
            Actions act=new Actions(Driver);
            act.MoveToElement(element).Build().Perform();
        }
        public void DragAndDrop(By locator,int timeOutInSeconds,IWebElement source,IWebElement target)
        {
            var element=WaitForElementToBeVisible(locator,timeOutInSeconds);
            Actions act=new Actions(Driver);
            act.DragAndDrop(source,target).Build().Perform();
        }
         public void DoubleClick(By locator,int timeOutInSeconds)
        {
            var element=WaitForElementToBeVisible(locator,timeOutInSeconds);
            Actions act=new Actions(Driver);
            act.DoubleClick(element).Build().Perform();
        }
        public void RightClick(By locator,int timeOutInSeconds)
        {
            var element=WaitForElementToBeVisible(locator,timeOutInSeconds);
            Actions act=new Actions(Driver);
            act.ContextClick(element).Build().Perform();
        }
        public void SwitchToNewTab()
        {
            var tabs=Driver.WindowHandles;
            Driver.SwitchTo().Window(tabs.Last());
        }
        public void SwitchToOriginalTab()
        {
            var tabs=Driver.WindowHandles;
            Driver.SwitchTo().Window(tabs.First());
        }
        public void SwitchTabByIndex(int index)
        {
            var tabs=Driver.WindowHandles;
            Driver.SwitchTo().Window(tabs[index]);
        }
        public static string GenerateRandomString(int length)
        {
            const string chars= "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random=new Random();
            var result=new string(Enumerable.Repeat(chars,length)
                .Select(s=>s[random.Next(s.Length)]).ToArray());
            return result;
        }
        public static string GenerateRandomNumber(int length)
        {
            const string chars= "0123456789";
            var random=new Random();
            var result=new string(Enumerable.Repeat(chars,length)
            .Select(s=>s[random.Next(s.Length)]).ToArray());
            return result;
        }
    }
}