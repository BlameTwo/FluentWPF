using AListClient.Models.Driver.DriverTemplate;
using AListClient.Models.UserAuth;
using AListClient.Models.UserAuth.Login;
using AListClient.Models.UserAuth.Me;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace AListClient.Contracts.Services;

public class AListClient : IAListClient
{
    private string _ip;

    private const string AlistSuffix = "-https://github.com/alist-org/alist";

    public AListClient(IHttpClientProvider httpClientProvider)
    {
        HttpClientProvider = httpClientProvider;
    }

    public IHttpClientProvider HttpClientProvider { get; }

    public async Task<LoginReponse> Login(
        string username,
        string password,
        CancellationToken cancellationToken = default
    )
    {
        var request = HttpClientProvider.PostRequestMessage(
            $"http://{_ip}/api/auth/login",
            new LoginRequest(username, password),
            false,
            false
        );
        var result = await HttpClientProvider.SendAsync(request,cancellationToken);
        var reponse = await HttpClientProvider.Paser<LoginReponse>(result, cancellationToken);
        if (reponse.Code == 200)
            return reponse.Data;
        return default;
    }



    public async Task<LoginReponse> LoginHash(
        string username,
        string password,
        CancellationToken cancellationToken = default
    )
    {
        var request = HttpClientProvider.PostRequestMessage(
            $"http://{_ip}/api/auth/login/hash",
            new LoginRequest(username, CoputeSha256Hash(password)),
            false,
            false
        );
        var result = await HttpClientProvider.SendAsync(request, cancellationToken);
        var reponse = await HttpClientProvider.Paser<LoginReponse>(result, cancellationToken);
        if (reponse.Code == 200)
            return reponse.Data;
        return default;
    }

    private string CoputeSha256Hash(string password)
    {

        var SHA = SHA256.Create();
        var bytes = SHA.ComputeHash(Encoding.UTF8.GetBytes(password+AlistSuffix));
        var builder = new StringBuilder();
        foreach (var item in bytes)
        {
            builder.Append(item.ToString("x2"));
        }
        return builder.ToString();
    }

    public void SetIp(string Ip)
    {
        this._ip = Ip;
    }

    public async Task<MeReponse> GetMe(CancellationToken cancellationToken = default)
    {
        var request = HttpClientProvider.GetRequestMessage(
            $"http://{_ip}/api/me",
            null,
            true,
            false
        );
        var result = await HttpClientProvider.SendAsync(request,cancellationToken);
        var reponse = await HttpClientProvider.Paser<MeReponse>(result, cancellationToken);
        if(reponse.Code == 200)
            return reponse.Data;
        return default;
    }

    public async Task<DriverTemplateReponse> GetDriverTemplate(CancellationToken token = default)
    {
        var request = HttpClientProvider.GetRequestMessage(
            $"http://{_ip}/api/admin/driver/list",
            null,
            true,
            false
        );
        DriverTemplateReponse reponse = new DriverTemplateReponse();
        var result = await HttpClientProvider.SendAsync(request, token);
        var json = JsonObject.Parse(await result.Content.ReadAsStringAsync());
        var list = json["data"].AsObject();
        foreach (var item in list)
        {
            var template =  item.Value.Deserialize<DriverTemplate>();
            template.Name = item.Key;
            reponse.Items.Add(template);
        }
        return reponse;
    }
}
