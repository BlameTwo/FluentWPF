using System.Text.Json.Serialization;

namespace AListClient.Models;

public class ResultCode<T>
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("data")]
    public T Data { get; set; }
}
