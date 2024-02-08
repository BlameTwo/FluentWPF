namespace ToolkitBox.Core.Contracts;

public interface IInstallAppService
{
    /// <summary>
    /// 增加过滤
    /// </summary>
    public void AddFolderFilter();

    /// <summary>
    /// 刷新
    /// </summary>
    public void Refresh();
}
