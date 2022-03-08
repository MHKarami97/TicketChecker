using TicketChecker;

Console.WriteLine("Start");

var parser = new SeleniumParser();

const int delayOnSecond = 5;
const string email = "";
const string password = "";

const string url =
    "https://www.alibaba.ir/train/THR-QUM?adult=1&child=0&infant=0&departing=1400-12-26&ticketType=Family&isExclusive=false";
const string ticketBtnXPath = "/html/body/div/div[1]/main/div/div/section/div[2]/div[1]/div[2]/button";
const string passengerBtnXPath = "/html/body/div[1]/div[1]/main/form/div[2]/div/div[1]/div[1]/div/button";
const string selectPassengerBtnXPath = "/html/body/div[1]/div[2]/div/div/div/div[3]/table/tbody/tr[1]/td[4]/button";
const string buyBtnXPath = "/html/body/div[1]/div[1]/main/div/div/div/div/div[3]/button";
const string logInBtnXPath = "/html/body/div/div[2]/div/div/form/div[3]/button";
const string logInByPassword = "/html/body/div/div[2]/div/div/form/div[2]/button[2]";
const string emailXPath = "/html/body/div/div[2]/div/div/form/div[1]";
const string passwordXPath = "/html/body/div/div[2]/div/div/form/div[2]/span/input";


while (true)
{
    parser.BuyTicket(url, ticketBtnXPath, passengerBtnXPath, logInByPassword, logInBtnXPath, emailXPath, passwordXPath,
        selectPassengerBtnXPath, buyBtnXPath, email, password);

    await Task.Delay(TimeSpan.FromSeconds(delayOnSecond));
}