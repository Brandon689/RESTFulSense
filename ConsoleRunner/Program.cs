using dotenv.net;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RESTFulSense.Clients;
using RESTFulSense.Models.Attributes;
using System.Net.Http.Headers;
using System.Text;




    

DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "../../../.env" }));



var wordPressConfigurations = new WordPressConfigurations
{
    UserName = Environment.GetEnvironmentVariable("WP_USER"),
    AppPassword = Environment.GetEnvironmentVariable("WP_APP_PASSWORD"),
    ApiUrl = Environment.GetEnvironmentVariable("WC_STORE_URL")
};

var w = new WordPressBroker(wordPressConfigurations);
string src = @"C:\Users\Brandon\Pictures\2184720.jpeg";
ExternalMediaItemRequest mi = new ExternalMediaItemRequest()
{
    File = new FileStream(src, FileMode.Open),
    FileName = src.Split("\\").Last(),
    AltText = "porpoise"
};

var a = await w.PostFormAsync<ExternalMediaItemRequest, ExternalMediaItemResponse>(
    relativeUrl: $"{wordPressConfigurations.ApiUrl}/wp-json/wp/v2/media",
    content: mi);


;



internal class ExternalMediaItemRequest
{
    [RESTFulStreamContent("file")]
    public Stream File { get; set; }

    [RESTFulFileName("file")]
    public string FileName { get; set; }

    //[RESTFulStringContent("Alt-Text")]
    //public string AltText { get; set; }

    [RESTFulContentHeader("Alt-Text")]
    public string AltText { get; set; }
}


public class WordPressConfigurations
{
    public string ApiUrl { get; set; }
    public string UserName { get; set; }
    public string AppPassword { get; set; }
}

internal partial class WordPressBroker
{
    private readonly WordPressConfigurations wordPressConfigurations;
    private readonly IRESTFulApiFactoryClient apiClient;
    private readonly HttpClient httpClient;

    public WordPressBroker(WordPressConfigurations wordPressConfigurations)
    {
        this.wordPressConfigurations = wordPressConfigurations;
        this.httpClient = SetupHttpClient();
        this.apiClient = SetupApiClient();
    }

    public async ValueTask<TResult> PostFormAsync<TRequest, TResult>(string relativeUrl, TRequest content)
        where TRequest : class
    {
        return await this.apiClient.PostFormAsync<TRequest, TResult>(
            relativeUrl,
            content);
    }

    private HttpClient SetupHttpClient()
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(uriString: this.wordPressConfigurations.ApiUrl),
        };
        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Basic",
                parameter: Convert.ToBase64String(Encoding.UTF8.GetBytes($"{this.wordPressConfigurations.UserName}:{this.wordPressConfigurations.AppPassword}")));

        return httpClient;
    }

    private IRESTFulApiFactoryClient SetupApiClient() =>
        new RESTFulApiFactoryClient(this.httpClient);
}








public class ExternalMediaItemResponse
{
    [JsonProperty("id")]
    public int Id { get; set; } = 0;

    [JsonProperty("src")]
    public string Src { get; set; } = string.Empty;

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("alt")]
    public string Alt { get; set; } = string.Empty;
}