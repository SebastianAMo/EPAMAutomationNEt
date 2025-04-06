using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Business.Pages
{
    public class JobDetailsPage : BasePage
    {
        public JobDetailsPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public bool VerifyKeywordInDescription(string keyword)
        {
            string dynamicLocator = $"//li[contains(text(),'{keyword}')]";

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(dynamicLocator)));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}