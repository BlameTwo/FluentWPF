using ToolkitBase;
using ToolkitBase.Enums;

namespace JsonToolkit;

public partial class JsonToTextToolkit : IToolkit<JsonToolkitNode>
{
    public string Name => "Json生成器";

    public string Description => "这是一个对于DotNet 两大Json框架的生成配置";

    public string Version => "1.0.0";

    public ToolkitsType ToolkitType => ToolkitsType.UI;



}