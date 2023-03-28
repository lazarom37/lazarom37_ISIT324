using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using static System.Console;

namespace SeleniumNG
{
    class Program
    {
        static void Main(string[] args)
        {
            //By Marcus Lazaro, 2023
            //NOTE: I would suggest turning down your system volume while doing this, site defaults to 100% volume on all flash videos

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.newgrounds.com");

            IWebElement ele;

            //GOAL: Find and play "The Ultimate Showdown" flash video on Newgrounds by navigating through the Movies page and using sort-by views filter
            //YOU ARE AT: Homepage
            ele = driver.FindElement(By.CssSelector("#notification-bar > div > div.logo.padded-left > a"));
            WriteLine($"Current Page: \"{ele.Text}\"");

            //@Homepage: Navigate to Movies Page
            ele = driver.FindElement(By.CssSelector("#topnav > a.header-nav-button-movies"));
            ele.Click();

            //YOU ARE AT: Movies
            ele = driver.FindElement(By.CssSelector("#hub > div > div > h2"));
            WriteLine($"Current Page: \"{ele.Text}\"");

            //@Movies: Set sort-by value to "Views"
            ele = driver.FindElement(By.CssSelector("#hub > div > form > div:nth-child(1) > div:nth-child(2) > div:nth-child(3) > div > select"));
            SelectElement s = new SelectElement(ele);
            s.SelectByValue("views");

            //@Movies: Select "The Ultimate Showdown"
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2); //Necessary loading
            //Had to use href because the search item Id's change for every filter/search request
            ele = driver.FindElement(By.CssSelector("[href*='https://www.newgrounds.com/portal/view/285267']"));
            ele.Click();

            //YOU ARE AT: The Ultimate Showdown (by altffour and Trapezoid AKA Lemon Demon)
            ele = driver.FindElement(By.CssSelector("#embed_header > h2"));
            WriteLine($"Current Page: \"{ele.Text}\"");

            //@Ultimate Showdown: Play video
            ele = driver.FindElement(By.CssSelector("#ng-global-video-player > div.ng-video-player > div.ng-video-ui > div > div.flexbox.align-center > div.ng-video-controls > button:nth-child(3)"));
            ele.Click();

            //driver.Quit();
        }

        private static ChromeDriver InitDriverNoLogging()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.EnableVerboseLogging = false;
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();

            options.PageLoadStrategy = PageLoadStrategy.Normal;

            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-crash-reporter");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-in-process-stack-traces");
            options.AddArgument("--disable-logging");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--log-level=3");
            options.AddArgument("--output=/dev/null");

            //var driver = new ChromeDriver(service);
            return new ChromeDriver(service);
        }

    }
}
