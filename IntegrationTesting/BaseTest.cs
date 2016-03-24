using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace IntegrationTesting
{
    [TestFixture]
    public class BaseTest
    {
        public IWebDriver driver;
        public string driver_engine;                   

        [SetUp]
        public void SetupTest()
        {
            Uri hubUrl = new Uri("http://127.0.0.1:4444/wd/hub");

            Console.WriteLine("");
            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

            if ((TestContext.CurrentContext.Test.Properties["Driver"]) == null)
                throw new Exception("[Driver] PROPERTY NOT SPECIFIED");
            else
                driver_engine = TestContext.CurrentContext.Test.Properties["Driver"].ToString().ToUpper();

            PreDriverInitialize();

            try
            {

                switch (driver_engine)
                {
                    case "FIREFOX":
                        driver = new RemoteWebDriver(hubUrl, DesiredCapabilities.Firefox());
                        break;
                    case "IE":
                        driver = new RemoteWebDriver(hubUrl, DesiredCapabilities.InternetExplorer());
                        break;
                    default:
                        driver = new RemoteWebDriver(hubUrl, DesiredCapabilities.Chrome());
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("IS SELENIUM NODE RUNNING AND CONNECTED TO A HUB? " + ex.InnerException);
            }

            this.driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // TODO: Make browser size configurable.
            this.driver.Manage().Window.Position = new System.Drawing.Point(0, 0);
            driver.Manage().Cookies.DeleteAllCookies();

            PostDriverInitialize(); //to be called by children right after driver initialization

        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Close();
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception)
            {
                Thread.Sleep(15000);

                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
            }
        }

        public virtual void PostDriverInitialize()
        {         

        }

        public virtual void PreDriverInitialize()
        {
          
        }

    }
}
