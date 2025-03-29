using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Business.Pages
{
    public class InsightsPage : BasePage
    {
        private readonly By rightArrow;
        private readonly By leftArrow;
        private readonly By readMoreButton;
        private readonly By articleTitle;


        public InsightsPage(IWebDriver driver, WebDriverWait wait, int carouselIndex = 1) : base(driver, wait) {
            rightArrow = By.XPath($"(//button[contains(@class, 'slider__right-arrow')])[{carouselIndex}]");
            leftArrow = By.XPath($"(//button[contains(@class, 'slider__left-arrow')])[{carouselIndex}]");
            readMoreButton = By.XPath($"(//div[contains(@class, 'slider')]//div[@class='owl-item active']//a[contains(@class, 'custom-link') and contains(text(), 'Read More')])[{carouselIndex}]");
            articleTitle = By.XPath($"(//div[@class='owl-item active']//div[@class='text'])[{carouselIndex}]");
        }


        public InsightsPage SwipeCarousel(int times, bool swipeRight = true)
        {
            for (int i = 0; i < times; i++)
            {
                if (swipeRight)
                {
                    driver.FindElement(rightArrow).Click();
                }
                else
                {
                    driver.FindElement(leftArrow).Click();
                }
            }
            return this;
        }

        public ArticlePage ClickReadMoreButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(readMoreButton));
            actions.Click(driver.FindElement(readMoreButton)).Perform();
            return new ArticlePage(driver, wait);
        }

        public string GetActiveArticleTitle()
        {
            var articleTitleElement = wait.Until(ExpectedConditions.ElementIsVisible(articleTitle));
            return articleTitleElement.Text.Trim();
        }

    }
}