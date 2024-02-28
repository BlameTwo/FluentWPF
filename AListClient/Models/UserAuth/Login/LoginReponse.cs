using System.Text.Json.Serialization;

namespace AListClient.Models.UserAuth.Login;

public class LoginReponse : IReponseModel
{
    [JsonPropertyName("token")]
    public string Token { get; set; }

    public string ResponseName => "登录结果";

}
