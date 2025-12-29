using AutomationFramework.Config;
using AutomationFramework.Drivers;
using AutomationFramework.Pages;

namespace AutomationFramework.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
    
        [Test,Category("Signup")]
        public void Signup_WithValidCredentials()
        {
            var driver=DriverFactory.Driver;
            string email=BasePage.GenerateRandomString(10)+"@getnada.com";
            string name=BasePage.GenerateRandomString(10);
            driver.Navigate().GoToUrl(Configreader.GetBaseUrl());

            HomePage homePage=new HomePage(driver);
            LoginPage loginPage=new LoginPage(driver);
            homePage.ClickMenuTabLink("Home")       
                    .VerfiyMenuIsSelected("Home")
                    .ClickMenuTabLink("Signup / Login");
            loginPage.EnterEmail(email)
                     .EnterName(name)
                     .ClickSignupButton();
        }
    }
}