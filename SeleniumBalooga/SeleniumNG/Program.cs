using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using static System.Console;

namespace SeleniumNG
{
    class Program
    {
        static void Main(string[] args)
        {
            //By Marcus Lazaro, 2023

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://seattle.craigslist.org");

            IWebElement ele;

            /* 
            //TEST 1: Testing Craigslist's Edit-Listing Functionality
            //Use search bar and input "balooga"
            ele = driver.FindElement(By.CssSelector("#leftbar > div.cl-home-search-query.wide > div > input[type=text]"));
            ele.SendKeys("balooga");
            ele.SendKeys(Keys.Enter);
            */

            ///////////////////////////////////////
            ///////////////////////////////////////
            ///////////////////////////////////////
            ///////////////////////////////////////

            /* <--Delete this to enable TEST 2
            //TEST 2: Testing Craigslist’s Search Functionality
            //Use search bar and input "balooga"
            ele = driver.FindElement(By.CssSelector("#leftbar > div.cl-home-search-query.wide > div > input[type=text]"));
            ele.SendKeys("balooga");
            ele.SendKeys(Keys.Enter);

            //Click on "balooga" listing
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2); //Necessary loading
            ele = driver.FindElement(By.CssSelector("#search-results-page-1 > ol > li:nth-child(2) > div > a"));
            ele.Click();
            */ //< --Delete this to enable TEST 2

            ///////////////////////////////////////
            ///////////////////////////////////////
            ///////////////////////////////////////
            ///////////////////////////////////////

            //TEST 3: Testing Craigslist's Search Functionality Within Categories
            //Navigate to Bikes (for sale) category
            ele = driver.FindElement(By.CssSelector("#sss0 > li:nth-child(11) > a"));
            ele.Click();

            //Search for "balooga" with no results expected.
            ele = driver.FindElement(By.CssSelector("body > div.cl-content > main > form > div.cl-query-bar > div > div > input"));
            ele.SendKeys("balooga");
            ele.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //Return back to homepage, navigate to wanted (for sale) category
            ele = driver.FindElement(By.CssSelector("body > div.cl-content > header > div.cl-left-group > a > span"));
            ele.Click();
            ele = driver.FindElement(By.CssSelector("#sss1 > li:nth-child(21) > a > span"));
            ele.Click();

            //Search for "balooga" this time with just one result expected.
            ele = driver.FindElement(By.CssSelector("body > div.cl-content > main > form > div.cl-query-bar > div > div > input"));
            ele.SendKeys("balooga");
            ele.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //Click on "balooga" listing
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2); //Necessary loading
            ele = driver.FindElement(By.CssSelector("#search-results-page-1 > ol > li:nth-child(2) > div > a"));
            ele.Click();

            ///////////////////////////////////////
            ///////////////////////////////////////
            ///////////////////////////////////////
            ///////////////////////////////////////

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
