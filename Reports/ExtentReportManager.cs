using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace AutomationFramework.Reports
{
    public class ExtentReportManager
    {
        public static ExtentReports _extent;
        public static ExtentSparkReporter _htmlReporter;

        public static ExtentReports GetInstance()
        {
            if(_extent==null)
            {
                string reportPath=$"{AppDomain.CurrentDomain.BaseDirectory}/Reports/Report_{DateTime.Now:yyyyMMdd_HHmmss}.html";
                _htmlReporter=new ExtentSparkReporter(reportPath);
                _htmlReporter.Config.DocumentTitle="UI Automation Test Report";
                _htmlReporter.Config.ReportName="Automation Test Results";
                _htmlReporter.Config.Theme=AventStack.ExtentReports.Reporter.Config.Theme.Dark;

                _extent=new ExtentReports();
                _extent.AttachReporter(_htmlReporter);
            } 
            return _extent;
    }
    }
}