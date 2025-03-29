using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;

namespace Core.Driver
{
    public static class DriverFactory
    {
        private static IWebDriver? driver;

        public static IWebDriver GetDriver(string browser, string downloadDirectory, bool headless = false)
        {
            if (driver == null)
            {
                switch (browser)
                {
                    case "chrome":
                        var optionsChrome = new ChromeOptions();
                        if (headless)
                        {
                            optionsChrome.AddArgument("--headless");
                            optionsChrome.AddArgument("--disable-gpu");
                        }
                        optionsChrome.AddUserProfilePreference("download.default_directory", downloadDirectory);
                        optionsChrome.AddUserProfilePreference("download.prompt_for_download", false);
                        optionsChrome.AddUserProfilePreference("download.directory_upgrade", true);
                        optionsChrome.AddUserProfilePreference("safebrowsing.enabled", true);
                        optionsChrome.AddArgument("--start-maximized");
                        optionsChrome.AddArgument("--disable-notifications");

                        driver = InitChromeDriver(downloadDirectory, headless);
                        break;
                    case "edge":
                        driver = InitEdgeDriver(downloadDirectory, headless);
                        break;
                    default:
                        throw new Exception("Browser not supported");
                }
            }
            return driver;
        }


        public static IWebDriver InitChromeDriver(string downloadDirectory, bool headless = false)
        {
            var optionsChrome = new ChromeOptions();
            if (headless)
            {
                optionsChrome.AddArgument("--headless");
                optionsChrome.AddArgument("--disable-gpu");
            }
            optionsChrome.AddUserProfilePreference("download.default_directory", downloadDirectory);
            optionsChrome.AddUserProfilePreference("download.prompt_for_download", false);
            optionsChrome.AddUserProfilePreference("download.directory_upgrade", true);
            optionsChrome.AddUserProfilePreference("safebrowsing.enabled", true);
            optionsChrome.AddArgument("--start-maximized");
            optionsChrome.AddArgument("--disable-notifications");

            return new ChromeDriver(optionsChrome);
        }

        public static IWebDriver InitEdgeDriver(string downloadDirectory, bool headless = false)
        {
            var optionsEdge = new EdgeOptions();
            if (headless)
            {
                optionsEdge.AddArgument("--headless");
                optionsEdge.AddArgument("--disable-gpu");
            }
            optionsEdge.AddUserProfilePreference("download.default_directory", downloadDirectory);
            optionsEdge.AddUserProfilePreference("download.prompt_for_download", false);
            optionsEdge.AddUserProfilePreference("download.directory_upgrade", true);
            optionsEdge.AddUserProfilePreference("safebrowsing.enabled", true);
            optionsEdge.AddArgument("--start-maximized");
            optionsEdge.AddArgument("--disable-notifications");

            return new EdgeDriver(optionsEdge);
        }

        public static void CloseDriver()
        {
            driver?.Quit();
            driver = null;
        }

    }
}
