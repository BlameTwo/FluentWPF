using AListClient.Models;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace AListClient.Contracts.Services;

public class HttpClientProvider : IHttpClientProvider
{
    private HttpClient httpClient;

    public HttpClientProvider()
    {
        httpClient = new HttpClient();
    }

    public string Token { get; set; }

    public string Cookie { get; set; }

    public HttpRequestMessage PostRequestMessage<T>(string uri, T model, bool needToken, bool needCookie)
        where T: IRequestModel
    {
        HttpRequestMessage request = new(HttpMethod.Post, uri);
        var modelstr = JsonSerializer.Serialize(model);
        var content = new StringContent(modelstr, System.Text.Encoding.UTF8, "application/json");
        request.Content = content;
        if (needToken)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Token);
        }
        if (needCookie)
        {
            request.Headers.Add("Cookie", Cookie);
        }
        return request;
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken token)
    {
        return await this.httpClient.SendAsync(message,token);
    }

    public async Task<ResultCode<T>> Paser<T>(HttpResponseMessage reponse, CancellationToken token)
        where T : IReponseModel
    {
        var str = await reponse.Content.ReadAsStringAsync(token);
        return JsonSerializer.Deserialize<ResultCode<T>>(str)!;
    }


    public async Task<ResultCode<T>> ParserModel<T>(HttpResponseMessage reponse, CancellationToken token)
    {
        var str = await reponse.Content.ReadAsStringAsync(token);
        return JsonSerializer.Deserialize<ResultCode<T>>(str)!;
    }

    public HttpRequestMessage GetRequestMessage(string uri, Dictionary<string, object> values, bool needToken, bool needCookie)
    {
        var Url = uri;
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        if(values != null && values.Count > 0)
        {
            var query = values.Select(x => $"{x.Key}={x.Value}");
            Url += $"?{string.Join("&",query)}";
        }
        request.RequestUri = new Uri(Url);
        if (needToken)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Token);
        }
        if (needCookie)
        {
            request.Headers.Add("Cookie", Cookie);
        }
        return request;
    }

}
