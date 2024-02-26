using AListClient.Models.UserAuth;

namespace AListClient.Contracts;

public interface IAListClient
{

    public Task<LoginReponse> Login(string username, string password);

    public void SetIp(string Ip);
}
