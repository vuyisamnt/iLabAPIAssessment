using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace iLabAPIAssessment.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        //private static LaunchWebApp WebApp;
        private RemoteWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        static ExtentReports extent;
        //static ExtentKlovReporter klov;

        public ExtentTest test;
        private static ExtentTest featureName;
        private static ExtentTest scenario;

       // private CaptureScreenShot _parallelConfig = new CaptureScreenShot();

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [BeforeTestRun]
        public static void InitialiseReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\VuyisaMntabeko\source\repos\iLabAPIAssessment\iLabAPIAssessment\ExtentReporting\index.html");
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Username", System.Security.Principal.WindowsIdentity.GetCurrent().Name);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

            System.Collections.Specialized.IOrderedDictionary args = _scenarioContext.ScenarioInfo.Arguments;

            string Env = (string)args["Environment"];


            extent.Flush();

        }

        [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //var mediaEntity = _parallelConfig.CaptureScreenshotAndReturnModel(driver);

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString().Equals("Skipped"))
            {
                return;
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
    }
}
