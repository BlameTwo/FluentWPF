using System.Text.Json.Serialization;

namespace AListClient.Models.UserAuth;

public class LoginReponse: IResponseModel
{
    [JsonPropertyName("token")]
    public string Token { get; set; }

    public string ResponseName => "登录结果";

}
