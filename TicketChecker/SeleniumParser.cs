using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using TicketChecker.Config;

namespace TicketChecker;

public class SeleniumParser
{
    private readonly EdgeDriver _driver;
    private readonly WebDriverWait _webDriverWait;

    public SeleniumParser()
    {
        var webDriverFixture = new WebDriverFixture();

        _driver = webDriverFixture.Driver;
        _webDriverWait = webDriverFixture.WebDriverWait;
    }

    public void BuyTicket(string url, string ticketBtnXPath, string passengerBtnXPath, string logInByPasswordXPath,
        string logInBtnXPath,
        string emailXPath, string passwordXPath, string selectPassengerBtnXPath, string buyBtnXPath, string email,
        string password)
    {
        var isTicketExist = IsTicketExist(url, ticketBtnXPath);

        if (isTicketExist)
        {
            try
            {
                Login(passengerBtnXPath, logInByPasswordXPath, emailXPath, passwordXPath, email, password,
                    logInBtnXPath);
                SelectPassenger(selectPassengerBtnXPath);
                Buy(buyBtnXPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    private bool IsTicketExist(string url, string ticketBtnXPath)
    {
        try
        {
            _driver.GoToPage(url);

            var ticketBtnInput = _webDriverWait.WaitAndFindElementUntilFullLoad(By.CssSelector(ticketBtnXPath));
            ticketBtnInput.Click();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private void Login(string passengerBtnXPath, string logInByPasswordXPath, string emailXPath, string passwordXPath,
        string email, string password,
        string loginBtn)
    {
        var passenger = _webDriverWait.WaitAndFindElementUntilFullLoad(By.XPath(passengerBtnXPath));
        passenger.Click();

        var logInByPassword = _webDriverWait.WaitAndFindElementUntilFullLoad(By.XPath(logInByPasswordXPath));
        logInByPassword.Click();

        var emailInput = _webDriverWait.WaitAndFindElementUntilFullLoad(By.XPath(emailXPath));
        emailInput.Click();
        emailInput.SendKeys(email);

        var passwordInput = _webDriverWait.WaitAndFindElementUntilFullLoad(By.XPath(passwordXPath));
        passwordInput.Click();
        passwordInput.SendKeys(password);

        var login = _webDriverWait.WaitAndFindElementUntilFullLoad(By.XPath(loginBtn));
        login.Click();
    }

    private void SelectPassenger(string selectPassengerBtnXPath)
    {
        var passenger = _webDriverWait.WaitAndFindElementUntilFullLoad(By.XPath(selectPassengerBtnXPath));
        passenger.Click();
    }

    private void Buy(string buyBtnXPath)
    {
        var passenger = _webDriverWait.WaitAndFindElementUntilFullLoad(By.XPath(buyBtnXPath));
        passenger.Click();
    }
}