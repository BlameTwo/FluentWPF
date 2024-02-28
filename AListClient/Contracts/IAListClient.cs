using AListClient.Models.Driver.DriverTemplate;
using AListClient.Models.UserAuth.Login;
using AListClient.Models.UserAuth.Me;

namespace AListClient.Contracts;

public interface IAListClient
{
    public IHttpClientProvider HttpClientProvider { get; }

    public Task<LoginReponse> Login(string username, string password, CancellationToken cancellationToken = default);

    public Task<LoginReponse> LoginHash(string username, string password,CancellationToken cancellationToken=default);

    public Task<MeReponse> GetMe(CancellationToken cancellationToken = default);

    public void SetIp(string Ip);

    public Task<DriverTemplateReponse> GetDriverTemplate(CancellationToken token = default);
}
