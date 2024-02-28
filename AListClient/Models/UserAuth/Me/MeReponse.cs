using System.Text.Json.Serialization;

namespace AListClient.Models.UserAuth.Me;

public class MeReponse: IResponseModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("base_path")]
    public string BasePath { get; set; }

    [JsonPropertyName("role")]
    public int Role { get; set; }

    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }

    [JsonPropertyName("permission")]
    public int Permission { get; set; }

    [JsonPropertyName("sso_id")]
    public string SsoId { get; set; }

    [JsonPropertyName("otp")]
    public bool Otp { get; set; }

    [JsonInclude]
    public string ResponseName => "账号基础信息";
}