using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Calculator.Genericos;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Calculator.Test
{
    public class BaseTest
    {
        CargarJson json = new CargarJson();
        public IWebDriver driver;
        public string baseURL;
        public static ExtentTest test;
        public static ExtentReports extent;

        [SetUp]
        public void configBrowser()
        {
            baseURL = json.config_data().url;
            bool esHeadless = json.config_data().headless;
            EdgeOptions options = new EdgeOptions();

            if (esHeadless)
            {
                options.AddArguments("headless");
            }

            driver = new EdgeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
        }
        [OneTimeSetUp]
        public void generateReporter() {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName;

            string reportFolder = Path.Combine(projectRootDirectory, "Reportes");
            string reportPath = Path.Combine(reportFolder, "index.html");

            extent = new ExtentReports();
            ExtentSparkReporter htmlreporter = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(htmlreporter);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
        }

        [OneTimeTearDown]
        public void closeReporter()
        {
            extent.Flush();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
