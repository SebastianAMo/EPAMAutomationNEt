using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Business.Pages
{
    public class ArticlePage : BasePage
    {
        private readonly By articleTitle = By.XPath("(//div[contains(@class,'section')]//div[contains(@class,'colctrl__holder')])[1]");

        public ArticlePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }


        public string GetArticleTitle()
        {
            var articleTitleElement = wait.Until(d => d.FindElement(articleTitle));
            return articleTitleElement.Text.Trim();
        }
    }
}