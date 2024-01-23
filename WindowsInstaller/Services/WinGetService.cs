using Microsoft.Management.Deployment.Projection;
using Microsoft.Management.Deployment;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System;
using System.Linq;
using WindowsInstaller.Services.Contracts;
using Windows.Foundation;

namespace WindowsInstaller.Services;

public class WinGetService : IWinGetService
{
    private WinGetProjectionFactory WingetProjectionFactory => CreateFactory();
    private PackageManager PackageManager => WingetProjectionFactory.CreatePackageManager();
    private IReadOnlyList<PackageCatalogReference> PackageCatalogs =>
        PackageManager.GetPackageCatalogs();
    private Dictionary<string, PackageCatalog> _localCatalogues = new();
    private Dictionary<string, PackageCatalog> _remoteCatalogues = new();

    public async Task<ObservableCollection<CatalogPackage>> SearchAsync(
        string packageCatalogName,
        string query,
        CancellationToken cancellationToken = default
    )
    {
        return await Task.Run(
            async () =>
            {
                ObservableCollection<CatalogPackage> list = new();
                var catalog = await GetRemotePackageCatalog(packageCatalogName);
                var options = WingetProjectionFactory.CreateFindPackagesOptions();
                var filter = WingetProjectionFactory.CreatePackageMatchFilter();
                filter.Field = PackageMatchField.Id;
                filter.Option = PackageFieldMatchOption.ContainsCaseInsensitive;
                filter.Value = query;
                options.Filters.Add(filter);
                var packages = await catalog.FindPackagesAsync(options);
                if (packages.Status == FindPackagesResultStatus.Ok)
                {
                    foreach (var item in packages.Matches.ToArray())
                    {
                        list.Add(item.CatalogPackage);
                    }
                }
                return list;
            },
            cancellationToken
        );
    }

    private async Task<PackageCatalog> GetRemotePackageCatalog(string packageName)
    {
        var options = WingetProjectionFactory.CreateCreateCompositePackageCatalogOptions();
        options.Catalogs.Add(PackageManager.GetPackageCatalogByName(packageName));
        var catalogReference = PackageManager.CreateCompositePackageCatalog(options);
        var connectResult = await catalogReference.ConnectAsync();

        return connectResult.PackageCatalog;
    }

    private async Task<PackageCatalog> GetLocalPackageCatalog(string packageCatalogName)
    {
        var options = WingetProjectionFactory.CreateCreateCompositePackageCatalogOptions();
        options.Catalogs.Add(PackageManager.GetPackageCatalogByName(packageCatalogName));
        options.CompositeSearchBehavior = CompositeSearchBehavior.LocalCatalogs;
        var catalogReference = PackageManager.CreateCompositePackageCatalog(options);
        var connectResult = await catalogReference.ConnectAsync();

        var ret = connectResult.PackageCatalog;
        return ret;
    }

    private WinGetProjectionFactory CreateFactory()
    {
        var init = new LocalServerInstanceInitializer
        {
            AllowLowerTrustRegistration = true,
            UseDevClsids = false
        };
        //var init = new ActivationFactoryInstanceInitializer();
        return new WinGetProjectionFactory(init);
    }

    public async Task<ObservableCollection<CatalogPackage>> GetLocalAppAsync(string packageName)
    {
        return await Task.Run(async () =>
        {
            ObservableCollection<CatalogPackage> list = new();
            var catalog = await GetLocalPackageCatalog(packageName);
            var options = WingetProjectionFactory.CreateFindPackagesOptions();
            var packages = await catalog.FindPackagesAsync(options);
            var matches = packages.Matches
                .ToArray()
                .Where(
                    (x) =>
                        x.CatalogPackage.DefaultInstallVersion != null
                        && x.CatalogPackage.DefaultInstallVersion.PackageCatalog.Info.Name
                            == "winget"
                );
            if (packages.Status != FindPackagesResultStatus.Ok)
                return list;
            foreach (var item in matches)
            {
                list.Add(item.CatalogPackage);
            }
            return list;
        });
    }

    public async Task<InstallResultStatus> InstallPackageAsync(CatalogPackage package, PackageInstallScope scope, Action<IAsyncOperationWithProgress<InstallResult, InstallProgress>, InstallProgress> callback)
    {
        return await Task.Run(async () =>
        {
            IProgress<Tuple<IAsyncOperationWithProgress<InstallResult, InstallProgress>, InstallProgress>> progress;
            progress = new Progress<Tuple<IAsyncOperationWithProgress<InstallResult, InstallProgress>, InstallProgress>>();
            ((Progress<Tuple<IAsyncOperationWithProgress<InstallResult, InstallProgress>, InstallProgress>>)progress).ProgressChanged += ProgressChanged;
            void ProgressChanged(object _, Tuple<IAsyncOperationWithProgress<InstallResult, InstallProgress>, InstallProgress> e) => callback(e.Item1,e.Item2);
            var installOptions = WingetProjectionFactory.CreateInstallOptions();
            installOptions.PackageInstallMode = PackageInstallMode.Silent;
            installOptions.PackageInstallScope = scope;
            var installOperation = PackageManager.InstallPackageAsync(package, installOptions);
            installOperation.Progress = (sender, value) =>
            {
                progress.Report(new(sender,value));
            };
            try
            {
                return (await installOperation).Status;
            }
            catch (Exception)
            {
                return InstallResultStatus.CatalogError;
            }
        });
    }
}
