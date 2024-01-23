using Microsoft.Management.Deployment.Projection;
using Microsoft.Management.Deployment;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace WindowsInstaller.Services.Contracts;

public interface IWinGetService
{
    public Task<ObservableCollection<CatalogPackage>> SearchAsync(
        string packageCatalogName,
        string query,
        CancellationToken cancellationToken = default
    );


    public Task<ObservableCollection<CatalogPackage>> GetLocalAppAsync(string packageName);


    public Task<InstallResultStatus> InstallPackageAsync(CatalogPackage package, PackageInstallScope scope, Action<InstallProgress> callback);
}
