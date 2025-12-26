using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace AutomationFramework.Utilities
{
    public class ScreenShotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver,string fileName)
        {
            string screenshotDir=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Utilities","Screenshots");
            if(!Directory.Exists(screenshotDir))
            {
                Directory.CreateDirectory(screenshotDir);
            }
            var screenshotPath=Path.Combine(screenshotDir,fileName+".png");
            Screenshot sc=((ITakesScreenshot)driver).GetScreenshot();
            sc.SaveAsFile(screenshotPath);
            return screenshotPath;
        }       
    }
}