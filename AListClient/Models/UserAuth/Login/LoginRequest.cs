using System.Text.Json.Serialization;

namespace AListClient.Models.UserAuth.Login;

public class LoginRequest : IRequestModel
{
    [JsonIgnore]
    public string RequestName => "登录";

    [JsonPropertyName("username")]
    public string Username { get; set; }

    public LoginRequest(string username, string password)
    {
        Username = username;
        Password = password;
    }

    [JsonPropertyName("password")]
    public string Password { get; set; }
}
