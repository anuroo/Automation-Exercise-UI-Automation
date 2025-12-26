using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class HomePage:BasePage
    {
        private  By menuTabLink(string menuName) => By.XPath("//a[text()=' "+menuName+"']");
        private  By IsMenuSelected(string menuName) => By.XPath("//a[text()=' "+menuName+"'][@style='color: orange;']");

        public HomePage(IWebDriver driver): base(driver){}
        
        public HomePage ClickMenuTabLink(string menuName)
        {
            WaitForElementToBeClickable(menuTabLink(menuName),30);
            Click(menuTabLink(menuName),30);
            return this;
        }
        public HomePage VerfiyMenuIsSelected(string menunName)
        {
            WaitForElementToBeVisible(IsMenuSelected(menunName),30);
            return this;
        }
    }
}