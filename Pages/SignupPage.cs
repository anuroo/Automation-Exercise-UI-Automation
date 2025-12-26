using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class SignupPage : BasePage
    {
        public SignupPage(IWebDriver driver):base(driver){}
        private By signupTitle(string title)=>By.XPath("//input[@value='"+title+"']");
        private By passwordInputField=> By.XPath("//input[@id='password']");
        private By dateField=> By.XPath("//select[@id='days']");
        private By monthField=> By.XPath("//select[@id='months']");
        private By yearField=> By.XPath("//select[@id='years']");
        private By firstNameInputField=> By.XPath("//input[@id='first_name']");
        private By lastNameInputField=> By.XPath("//input[@id='last_name']");
        private By addressinputField=> By.XPath("//input[@id='address1']");
        private By countryInputField=>By.XPath("//select[@id='Country']");
        private By stateInputField=>By.XPath("//input[@id='state']");
        private By cityInputField=>By.XPath("//input[@id='city']");
        private By mobileNumberInputField=>By.XPath("//input[@id='mobile_number']");
        private By zipCodeInputField=>By.XPath("//input[@id='zipcode']");
        private By createAccountButton=>By.XPath("//button[text()='Create Account']");
    }
}