using AListClient.Models;
using System.Net.Http;

namespace AListClient.Contracts;

public interface IHttpClientProvider
{
    public HttpRequestMessage PostRequestMessage<T>(string uri,T model, bool needToken, bool needCookie)
        where T : IRequestModel;

    public HttpRequestMessage GetRequestMessage(string uri, Dictionary<string, object> values, bool needToken, bool needCookie);

    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage message,CancellationToken token);


    public Task<ResultCode<T>> Paser<T>(HttpResponseMessage reponse,CancellationToken token)
        where T : IResponseModel;

    public string Token { get; set; }

    public string Cookie { get; set; }
}