using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Core.Utils
{
    public static class BrowserUtils
    {
        /// <summary>
        /// Method to scroll to the last result until all results are loaded, and click on the "View More" button if it exists.
        ///
        /// </summary>
        public static void ScrollToLastResultUntilAllResultsAreLoaded(IWebDriver driver, By preloader, By resultsList, By? viewMore, WebDriverWait wait)
        {
            var initialResults = wait.Until(d => d.FindElements(resultsList));
            var previousCount = initialResults.Count;
            var actions = new Actions(driver);


            while (true)
            {
                var lastResult = driver.FindElements(resultsList).Last();
                actions.ScrollToElement(lastResult).Perform();

                // Wait for the preloader to be displayed and then disappear
                try
                {
                    wait.Until(d => d.FindElement(preloader).Displayed);
                    wait.Until(d => !d.FindElement(preloader).Displayed);
                }
                catch (WebDriverTimeoutException) { }

                // Wait for the "View More" button to be displayed and click on it
                if (viewMore != null)
                {
                    try
                    {
                        wait.Until(d => d.FindElement(viewMore).Displayed);
                        driver.FindElement(viewMore).Click();
                    }
                    catch (WebDriverTimeoutException)
                    {
                        break;
                    }
                }
                // Obtain the current number of results and compare it with the previous one
                var currentResults = driver.FindElements(resultsList).Count;

                if (currentResults == previousCount) break;

                previousCount = currentResults;
            }
        }

        /// <summary>
        /// Close the cookie banner if it exists
        /// </summary>
        public static void CloseCookieBanner(By closeButton, WebDriverWait wait)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(closeButton));
                wait.Until(ExpectedConditions.ElementToBeClickable(closeButton)).Click();
            }
            catch (WebDriverTimeoutException) { }
            catch (NoSuchElementException) { }
            catch (ElementNotInteractableException) { }
        }


        public static bool WaitForFileDownload(string filePath, int timeoutInSeconds)
        {
            var wait = new DefaultWait<string>(filePath)
            {
                Timeout = TimeSpan.FromSeconds(timeoutInSeconds),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            try
            {
                return wait.Until(filePath => File.Exists(filePath));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

    }
}
