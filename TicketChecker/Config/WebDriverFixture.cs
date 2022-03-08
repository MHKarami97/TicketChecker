using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace TicketChecker.Config
{
    public class WebDriverFixture : IDisposable
    {
        public EdgeDriver Driver { get; }
        public Cookie Cookie;
        public WebDriverWait WebDriverWait;

        public WebDriverFixture()
        {
            //var driver = new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new EdgeDriver(@"D:\Files\Program");
            Cookie = new Cookie(name: "test", value: "", domain: "google.com", path: "/", expiry: null);
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}