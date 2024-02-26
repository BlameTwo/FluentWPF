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

    public HttpRequestMessage GetRequestMessage<T>(string uri, HttpMethod method, T model,bool needToken,bool needCookie)
        where T: IRequestModel
    {
        HttpRequestMessage request = new(method,uri);
        if(method == HttpMethod.Post)
        {
            var modelstr = JsonSerializer.Serialize(model);
            var content = new StringContent(modelstr, System.Text.Encoding.UTF8, "application/json");
            request.Content = content;
        }
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

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage message)
    {
        return await this.httpClient.SendAsync(message);
    }

    public async Task<ResultCode<T>> Paser<T>(HttpResponseMessage reponse)
        where T : IResponseModel
    {
        var str = await reponse.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ResultCode<T>>(str)!;
    }
}
