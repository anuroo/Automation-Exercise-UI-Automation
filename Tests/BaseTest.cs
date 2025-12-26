using AutomationFramework.Drivers;
using AutomationFramework.Reports;
using AutomationFramework.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework.Interfaces;
namespace AutomationFramework.Tests
{
    public class BaseTest
    {
        protected ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void BeforeSetUp()
        {
            extent= ExtentReportManager.GetInstance();
        }
        [SetUp]
        public void Setup()
        {
            DriverFactory.InitDriver();
            test= extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void TearDown()
        {
            var status=TestContext.CurrentContext.Result.Outcome.Status;
            var testName=TestContext.CurrentContext.Test.Name;
            if(status==TestStatus.Passed)
            {
                test.Pass("Test Passed");
            }
            else if(status==TestStatus.Failed)
            {
                string screenshotPath=ScreenShotHelper.CaptureScreenshot(DriverFactory.Driver,testName);
                test.Fail("Test Failed").AddScreenCaptureFromPath(screenshotPath);
            }
            DriverFactory.QuitDriver();
        }
        [OneTimeTearDown]
        public void AfterTearDown()
        {
            extent.Flush();
        }
    }
}