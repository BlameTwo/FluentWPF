using System.Threading.Tasks;

namespace WindowsInstaller.Models.PackageCommands;

/// <summary>
/// 卸载命令
/// </summary>
public class UnInstallCommand : PackageCommandBase
{
    public override string CommandId => this.PackageBase.Id;

    public override Task ExecuteAsync()
    {
        return Task.CompletedTask;
    }
}
