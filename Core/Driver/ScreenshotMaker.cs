using OpenQA.Selenium;

namespace Core.Driver
{
    public class ScreenshotMaker
    {
        private static string NewScreenshotName
        {
            get { return "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff") + "." + "png"; }
        }

        // Create the Screenshots folder in the project root
        private static string GetScreenshotsFolder()
        {
            var projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
            var screenshotDir = Path.Combine(projectRoot, "Screenshots");

            if (!Directory.Exists(screenshotDir))
                Directory.CreateDirectory(screenshotDir);

            return screenshotDir;
        }

        public static string TakeBrowserScreenshot(ITakesScreenshot driver)
        {
            var screenshotPath = Path.Combine(GetScreenshotsFolder(), "Display" + NewScreenshotName);
            driver.GetScreenshot().SaveAsFile(screenshotPath);
            return screenshotPath;

        }
    }
}
