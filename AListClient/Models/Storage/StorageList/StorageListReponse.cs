using System.Text.Json.Serialization;

namespace AListClient.Models.Storage.StorageList;

public class StorageListReponse : IReponseModel
{
    public string ResponseName => "存储列表";

    [JsonPropertyName("content")]
    public List<StorageContent> Content { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }
}

public class StorageContent
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("mount_path")]
    public string MountPath { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("driver")]
    public string Driver { get; set; }

    [JsonPropertyName("cache_expiration")]
    public int CacheExpiration { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("addition")]
    public string Addition { get; set; }

    [JsonPropertyName("remark")]
    public string Remark { get; set; }

    [JsonPropertyName("modified")]
    public DateTime Modified { get; set; }

    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }

    [JsonPropertyName("enable_sign")]
    public bool EnableSign { get; set; }

    [JsonPropertyName("order_by")]
    public string OrderBy { get; set; }

    [JsonPropertyName("order_direction")]
    public string OrderDirection { get; set; }

    [JsonPropertyName("extract_folder")]
    public string ExtractFolder { get; set; }

    [JsonPropertyName("web_proxy")]
    public bool WebProxy { get; set; }

    [JsonPropertyName("webdav_policy")]
    public string WebdavPolicy { get; set; }

    [JsonPropertyName("down_proxy_url")]
    public string DownProxyUrl { get; set; }
}
