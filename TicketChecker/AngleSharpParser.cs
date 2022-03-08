using AngleSharp;

namespace TicketChecker;

public class AngleSharpParser
{
    private readonly string _baseAlibabaAddress;
    private readonly IConfiguration _configuration;

    public AngleSharpParser()
    {
        _baseAlibabaAddress = "https://www.alibaba.ir/";

        _configuration = Configuration.Default.WithDefaultLoader();
    }

    public async Task ParseAlibaba(string address, string cellSelector)
    {
        var url = FormatAddress(_baseAlibabaAddress, address);

        var context = BrowsingContext.New(_configuration);

        var document = await context.OpenAsync(url);

        var html = document.ToHtml();

        var cell = document.All.FirstOrDefault(a => a.GetAttribute("class") == cellSelector);

        var blueListItemsLinq = document.All.Where(m => m.LocalName == "button" && m.ClassList.Contains("leading-tight"));
        var tm = blueListItemsLinq.ToList();
        if (cell != null)
        {
            var tmp = cell;
            Console.WriteLine("!!!!!   Find it   !!!!!");
        }
    }

    private string FormatAddress(string baseAddress, string address)
    {
        var result = new Uri(new Uri(baseAddress), address).AbsoluteUri;

        return result;
    }
}