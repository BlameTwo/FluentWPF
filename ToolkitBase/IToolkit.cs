
using ToolkitBase.Enums;

namespace ToolkitBase;

public interface IToolkit<T>
{
    public string Name { get; }

    public string Description { get;  }

    public string Version { get; }

    public ToolkitsType ToolkitType { get; }

    public Task<T> ExecuteAsync();
}
