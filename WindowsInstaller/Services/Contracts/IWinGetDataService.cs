using Microsoft.Management.Deployment;
using WindowsInstaller.Models.PackageCommands;

namespace WindowsInstaller.Services.Contracts;

public interface IWinGetDataService
{
    public InstallCommand GetInstallCommand(CatalogPackage package);
}