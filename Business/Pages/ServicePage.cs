using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Core.Utils;

namespace Business.Pages
{
    public class ServicePage : BasePage
    {
        private readonly By relatedExpertiseSection = By.XPath("//span[contains(text(), 'Our Related Expertise')]"); 

        public ServicePage(IWebDriver driver, WebDriverWait wait, WebDriverWait? waitShort = null) : base(driver, wait, waitShort) 
        {
        
        }

        public bool VerifyRelatedExpertiseSection()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(relatedExpertiseSection));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool VerifyServiceTitleInPage(string service)
        {
            string dynamicLocator = $"//span[contains(text(),'{service}')]";

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