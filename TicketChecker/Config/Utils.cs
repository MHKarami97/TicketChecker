using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace TicketChecker.Config
{
    public static class Utils
    {
        public static IWebElement WaitAndFindElementUntilFullLoad(this WebDriverWait webDriverWait, By locator)
        {
            var webElement = webDriverWait.Until(x => x.FindElement(locator));

            webDriverWait.Until(x => webElement.Enabled && webElement.Displayed);

            return webElement;
        }

        public static IWebElement WaitAndFindElementUntilFullLoadRelativeToElement(this WebDriverWait webDriverWait,
            IWebElement webElement, By locator, Func<IWebElement, bool>? predicate = null)
        {
            var element = webDriverWait.Until(x => webElement.FindElements(locator).First(predicate ?? (y => true)));

            webDriverWait.Until(x => element.Enabled && element.Displayed);

            return webElement;
        }

        public static IWebElement WaitAndFindElement(this WebDriverWait webDriverWait, By locator)
        {
            return webDriverWait.Until(x => x.FindElement(locator));
        }
        
        public static void GoToPage(this EdgeDriver driver, string url)
        {
            if (driver.WindowHandles.Count > 1)
            {
                for (var i = 1; i < driver.WindowHandles.Count; i++)
                {
                    driver.SwitchTo().Window(driver.WindowHandles[i]);

                    driver.Close();
                }

                driver.SwitchTo().Window(driver.WindowHandles[0]);
            }

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public static void GoToPage(this EdgeDriver driver, Cookie cookie, string url)
        {
            if (driver.WindowHandles.Count > 1)
            {
                for (var i = 1; i < driver.WindowHandles.Count; i++)
                {
                    driver.SwitchTo().Window(driver.WindowHandles[i]);

                    driver.Close();
                }

                driver.SwitchTo().Window(driver.WindowHandles[0]);
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.AddCookie(cookie);
            driver.Navigate().GoToUrl(url);
        }
    }
}