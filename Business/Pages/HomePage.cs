using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Core.Utils;

namespace Business.Pages
{
    public class HomePage : BasePage
    {
        private readonly By careersLink = By.LinkText("Careers");
        private readonly By aboutLink = By.LinkText("About");
        private readonly By insightsLink = By.LinkText("Insights");
        private readonly By searchIcon = By.ClassName("header-search__button");
        private readonly By searchInput = By.TagName("input");
        private readonly By searchButton = By.CssSelector("button.custom-button");
        private readonly By searchResults = By.ClassName("search-results__title-link");

        public HomePage(IWebDriver driver, WebDriverWait wait, WebDriverWait? waitShort = null) : base(driver, wait, waitShort) {
            this.CloseCookieBanner();
        }

        public CareersPage GoToCareers()
        {
            if (waitShort is null) throw new System.ArgumentNullException(nameof(waitShort));
            driver.FindElement(careersLink).Click();
            return new CareersPage(driver, wait, waitShort);
        }

        public AboutPage GoToAbout()
        {
            driver.FindElement(aboutLink).Click();
            return new AboutPage(driver, wait);
        }

        public InsightsPage GoToInsights(int carouselIndex = 1)
        {
            driver.FindElement(insightsLink).Click();
            return new InsightsPage(driver, wait, carouselIndex);
        }

        public T GoToPage<T>(string pageName, int carouselIndex = 1)
    where T : class
        {
            switch (pageName.ToLower())
            {
                case "careers":
                    if (waitShort is null) throw new ArgumentNullException(nameof(waitShort));
                    driver.FindElement(careersLink).Click();
                    return new CareersPage(driver, wait, waitShort) as T;

                case "about":
                    driver.FindElement(aboutLink).Click();
                    return new AboutPage(driver, wait) as T;

                case "insights":
                    driver.FindElement(insightsLink).Click();
                    return new InsightsPage(driver, wait, carouselIndex) as T;

                default:
                    throw new ArgumentException($"Unknown page: {pageName}", nameof(pageName));
            }
        }


        public HomePage ClickSearchIcon()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(searchIcon)).Click();
            return this;
        }

        public HomePage PerformSearch(string searchTerm)
        {
            var searchInputElement = wait.Until(d => d.FindElement(searchInput));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchInput)).SendKeys(searchTerm);
            driver.FindElement(searchButton).Click();
            return this;
        }

        public HomePage ScrollToLastResultUntilAllResultsAreLoaded()
        {
            ArgumentNullException.ThrowIfNull(waitShort, nameof(waitShort));
            wait.Until(ExpectedConditions.ElementIsVisible(searchResults));
            BrowserUtils.ScrollToLastResultUntilAllResultsAreLoaded(driver, preloader, searchResults, null, waitShort);
            return this;
        }

        public List<IWebElement> GetResultElements()
        {
            try
            {
                return driver.FindElements(searchResults).ToList();
            } catch (NoSuchElementException)
            {
                return new List<IWebElement>();
            }
        }
    }
}