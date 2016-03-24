using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.ObjectModel;

namespace IntegrationTesting
{
    /// <summary>
    /// Container for all test methods to be used accross multiple tests.
    /// Place all test methods here
    /// </summary>
    [TestFixture]
    public class TestMethodsContainer : BaseTest
    {
        //protected string page_with_contract = "http://localhost/DocusignIntegration/";
        protected string page_with_contract = "http://docusignintegration.azurewebsites.net/";

        private void SwitchToSigningWindow()
        {
            Thread.Sleep(10000);
            string mainWindow = driver.CurrentWindowHandle;
            
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            foreach (string handle in windowHandles)
            {
                if (handle != mainWindow)
                {
                    if (driver.SwitchTo().Window(handle).Title.Contains("DocuSign")) 
                        break;
                }
            }
        }

        private void SwitchToSigningFrame()
        {
            driver.SwitchTo().DefaultContent();
            IWebElement _sginingFrame = driver.FindElement(By.CssSelector("#signingIframe"));
            driver.SwitchTo().Frame(_sginingFrame);
        }

        public void NavigateToSigningPage()
        {
            driver.Navigate().GoToUrl(page_with_contract);
        }
        public void InitiateSigning()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement el = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#createEnvelope")));
            el.Click();            
        }

        public void SigningConsole_Continue()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement el = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#action-bar-btn-continue")));
            el.Click();
            Thread.Sleep(2000);
        }

        public void SigningConsole_Finish()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement el = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#action-bar-bottom-btn-finish")));
            el.Click();
            Thread.Sleep(7000);
        }

        public void PerformSigning()
        {
            SwitchToSigningFrame();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement el = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[tabtype='SignHere']")));            
            el.Click();            
            driver.SwitchTo().DefaultContent();
        }


    }
}
