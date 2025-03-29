using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Business.Pages
{
    public class AboutPage : BasePage
    {
        private readonly By glanceSection = By.XPath("//span[contains(text(),'EPAM at')]");
        private readonly By downloadButton = By.CssSelector("a.button-ui-23[download]");

        public AboutPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }


        public AboutPage ScrollToGlanceSection()
        {
            var glanceSectionElement = wait.Until(d => d.FindElement(glanceSection));
            actions.ScrollToElement(glanceSectionElement).Perform();
            return this;
        }

        public AboutPage DownloadGlanceFile()
        {
            var downloadButtonElement = wait.Until(d => d.FindElement(downloadButton));
            downloadButtonElement.Click();
            return this;
        }
    }
}