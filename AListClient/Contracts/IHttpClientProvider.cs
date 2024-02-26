using AListClient.Models;
using System.Net.Http;

namespace AListClient.Contracts;

public interface IHttpClientProvider
{
    public HttpRequestMessage GetRequestMessage<T>(string uri, HttpMethod method, T model, bool needToken, bool needCookie)
        where T : IRequestModel;


    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage message);


    public Task<ResultCode<T>> Paser<T>(HttpResponseMessage reponse)
        where T : IResponseModel;

    public string Token { get; set; }

    public string Cookie { get; set; }
}