using Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Business.Pages
{
    public class CareersPage : BasePage
    {
        private readonly By keywordInput = By.Id("new_form_job_search-keyword");
        private readonly By locationDropdown = By.ClassName("recruiting-search__location");
        private readonly By remoteCheckbox = By.ClassName("job-search__filter-items--remote");
        private readonly By findButton = By.CssSelector("button[type='submit']");
        private readonly By showResult = By.ClassName("search-result__list");
        private readonly By resultsList = By.ClassName("search-result__item");
        private readonly By viewAndApplyButton = By.ClassName("search-result__item-apply-23");
        private readonly By viewMore = By.XPath("//a[contains(text(),'View More')]");


        private const string locationOption = "//li[contains(text(), '{0}')]";

        public CareersPage(IWebDriver driver, WebDriverWait wait, WebDriverWait waitShort) : base(driver, wait, waitShort) { }

        public CareersPage EnableRemoteCheckbox()
        {
            actions.MoveToElement(driver.FindElement(remoteCheckbox)).Click().Perform();
            return this;
        }

        public CareersPage EnterKeyword(string keyword)
        {
            var keywordInputElement = wait.Until(d => d.FindElement(keywordInput));
            keywordInputElement.SendKeys(keyword);
            return this;
        }


        public CareersPage SelectLocation(string location)
        {
            driver.FindElement(locationDropdown).Click();
            var locationSelect = By.XPath(string.Format(locationOption, location));
            wait.Until(ExpectedConditions.ElementToBeClickable(locationSelect)).Click();
            return this;
        }

        public CareersPage ClickFindButton()
        {
            var findButtonElement = wait.Until(d => d.FindElement(findButton));
            findButtonElement.Click();
            return this;
        }

        public CareersPage ScrollToLastResultUntilAllResultsAreLoaded()
        {
            ArgumentNullException.ThrowIfNull(waitShort, nameof(waitShort));
            wait.Until(ExpectedConditions.ElementIsVisible(showResult));
            BrowserUtils.ScrollToLastResultUntilAllResultsAreLoaded(driver, preloader, resultsList, null, waitShort);
            return this;
        }

        public JobDetailsPage ClickOnLastJob()
        {
            var lastResult = wait.Until(d => d.FindElements(resultsList).Last());
            actions.ScrollToElement(lastResult).Perform();
            lastResult.FindElement(viewAndApplyButton).Click();
            return new JobDetailsPage(driver, wait);
        }
    }
}