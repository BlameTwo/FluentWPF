using System.Text.Json.Serialization;

namespace AListClient.Models.FileServer.FileLists;

public class FsRequest:IRequestModel
{
    [JsonPropertyName("path")]
    public string Path { get; set; }

    public FsRequest(string path, int page, int pageSize, bool isRefresh = false)
    {
        Path = path;
        Page = page;
        PageSize = pageSize;
        IsRefresh = isRefresh;
    }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("refresh")]
    public bool IsRefresh { get; set; }

    [JsonPropertyName("per_page")]
    public int PageSize { get; set; }

    public string RequestName => "层级文件夹路径";
}
