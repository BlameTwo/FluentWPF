using AListClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AListClient.Models.Driver.DriverTemplate;

public class DriverTemplateReponse : IReponseModel
{
    public List<DriverTemplate> Items { get; set; } = new();

    public string ResponseName => "云盘模板列表";
}

public class DriverTemplate
{
    [JsonIgnore]
    public string Name { get; set; }

    /// <summary>
    /// Common是提交json主体，需要反射生成一个json结构
    /// </summary>
    [JsonPropertyName("common")]
    public List<Common> Common { get; set; }

    /// <summary>
    /// 此属性是云盘账号信息内容
    /// </summary>
    [JsonPropertyName("additional")]
    public List<Additional> Additional { get; set; }

    [JsonPropertyName("config")]
    public Config Config { get; set; }
}

public class Config
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("local_sort")]
    public bool LocalSort { get; set; }

    [JsonPropertyName("only_local")]
    public bool OnlyLocal { get; set; }

    [JsonPropertyName("only_proxy")]
    public bool OnlyProxy { get; set; }

    [JsonPropertyName("no_cache")]
    public bool NoCache { get; set; }

    [JsonPropertyName("no_upload")]
    public bool NoUpload { get; set; }

    [JsonPropertyName("need_ms")]
    public bool NeedMs { get; set; }

    [JsonPropertyName("default_root")]
    public string DefaultRoot { get; set; }

    [JsonPropertyName("alert")]
    public string Alert { get; set; }
}

public class Additional
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("default")]
    public string Default { get; set; }

    [JsonPropertyName("options")]
    public string Options { get; set; }

    [JsonPropertyName("required")]
    public bool Required { get; set; }

    [JsonPropertyName("help")]
    public string Help { get; set; }
}

public class Common
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("default")]
    public string Default { get; set; }

    [JsonPropertyName("options")]
    public string Options { get; set; }

    [JsonPropertyName("required")]
    public bool Required { get; set; }

    [JsonPropertyName("help")]
    public string Help { get; set; }
}
