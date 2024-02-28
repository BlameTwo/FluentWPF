using System.Text.Json.Serialization;

namespace AListClient.Models.FileServer.FileLists;

public class FSContent
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("is_dir")]
    public bool IsDir { get; set; }

    [JsonPropertyName("modified")]
    public DateTime Modified { get; set; }

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("sign")]
    public string Sign { get; set; }

    [JsonPropertyName("thumb")]
    public string Thumb { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("hashinfo")]
    public string Hashinfo { get; set; }

    [JsonPropertyName("hash_info")]
    public object HashInfo { get; set; }
}

public class FsReponse:IReponseModel
{
    [JsonPropertyName("content")]
    public List<FSContent> Content { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("readme")]
    public string Readme { get; set; }

    [JsonPropertyName("header")]
    public string Header { get; set; }

    [JsonPropertyName("write")]
    public bool Write { get; set; }

    [JsonPropertyName("provider")]
    public string Provider { get; set; }

    public string ResponseName => "文件顶部";
}
