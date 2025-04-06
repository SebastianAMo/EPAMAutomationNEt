using Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Business.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected WebDriverWait? waitShort;
        protected WebDriverWait? waitLong;
        protected Actions actions;

        private readonly By acceptCookiesButton = By.Id("onetrust-accept-btn-handler");
        protected By preloader = By.ClassName("preloader");

        public BasePage(IWebDriver driver, WebDriverWait wait, WebDriverWait? waitShort = null, WebDriverWait? waitLong = null)
        {
            this.driver = driver;
            this.wait = wait;
            this.waitShort = waitShort;
            this.waitLong = waitLong;
            this.actions = new Actions(driver);
        }


        public void CloseCookieBanner()
        {
            BrowserUtils.CloseCookieBanner(acceptCookiesButton, wait);
        }
    }

}