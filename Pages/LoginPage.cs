using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver):base(driver){}
        private By nameInputField=> By.XPath("//input[@data-qa='signup-name']");
        private By emailInputField=> By.XPath("//input[@data-qa='signup-email']");
        private By signUpButton=> By.XPath("//button[text()='Signup']");

        public LoginPage EnterName(string name)
        {
            EnterText(nameInputField,name,30);
            return this;
        }
        public LoginPage EnterEmail(string email)
        {
            EnterText(emailInputField,email,30);
            return this;
        }
        public SignupPage ClickSignupButton()
        {
            Click(signUpButton,30);
            return new SignupPage(Driver);
        }
    }
}