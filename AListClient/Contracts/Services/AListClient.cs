using AListClient.Models.UserAuth;
using System.Net.Http;

namespace AListClient.Contracts.Services;

public class AListClient : IAListClient
{
    private string _ip;

    public AListClient(IHttpClientProvider httpClientProvider)
    {
        HttpClientProvider = httpClientProvider;
    }

    public IHttpClientProvider HttpClientProvider { get; }

    public async Task<LoginReponse> Login(string username, string password)
    {
        var request =  HttpClientProvider.GetRequestMessage(
            "http://127.0.0.1:5244/api/auth/login",
            HttpMethod.Post,
            new LoginRequest(username, password),
            false,
            false
        );
        var result = await HttpClientProvider.SendAsync( request );
        var reponse =  await HttpClientProvider.Paser<LoginReponse>(result);
        if (reponse.Code == 200)
            return reponse.Data;
        return default;
    }

    public void SetIp(string Ip)
    {
        this._ip = Ip;
    }
}
