using Microsoft.Management.Deployment;
using WindowsInstaller.Models.PackageCommands;
using WindowsInstaller.Services.Contracts;

namespace WindowsInstaller.Services;

public class WinGetDataService:IWinGetDataService
{
    public InstallCommand GetInstallCommand(CatalogPackage package)
        => GetCommand<CatalogPackage,InstallCommand>(package);

    private Command GetCommand<Value, Command>(Value data)
        where Command : ITaskCommand<Value>
    {
        var command = Register.GetService<Command>();
        command.SetData(data);
        return command;
    }
}
