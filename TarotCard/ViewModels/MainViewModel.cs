using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentWPF.Contracts.Navigations;
using Microsoft.Management.Deployment.Projection;
using Microsoft.Management.Deployment;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using WindowsInstaller.Extentions;
using WindowsInstaller.Services.Contracts;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace WindowsInstaller.ViewModels;

public partial class MainViewModel:ObservableObject
{
    private WinGetProjectionFactory WingetProjectionFactory => CreateFactory();
    private PackageManager PackageManager => WingetProjectionFactory.CreatePackageManager();
    private IReadOnlyList<PackageCatalogReference> PackageCatalogs => PackageManager.GetPackageCatalogs();
    private Dictionary<string, PackageCatalog> _localCatalogues = new();
    private Dictionary<string, PackageCatalog> _remoteCatalogues = new();

    public MainViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        var persons = new ObservableCollection<Person>();
        persons.Add(new Person { Name = "张三", Age = 20 });
        persons.Add(new Person { Name = "李四", Age = 25 });
        persons.Add(new Person { Name = "王五", Age = 30 });
        this.Persons = persons;
        //init();
    }

    private async void init()
    {
        await Search("winget", "QQ");
    }

    public async Task Search(string packageCatalogName, string query, CancellationToken cancellationToken = default)
    {
        try
        {
            var catalog = await GetRemotePackageCatalog(packageCatalogName);
            var options = WingetProjectionFactory.CreateFindPackagesOptions();
            var filter = WingetProjectionFactory.CreatePackageMatchFilter();
            filter.Field = PackageMatchField.Id;
            filter.Option = PackageFieldMatchOption.ContainsCaseInsensitive;
            filter.Value = query;
            options.Filters.Add(filter);
            var packages = await catalog.FindPackagesAsync(options);
            var matches = packages.Matches.ToArray();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private async Task<PackageCatalog> GetRemotePackageCatalog(string packageCatalogName)
    {
        var options = WingetProjectionFactory.CreateCreateCompositePackageCatalogOptions();
        options.Catalogs.Add(PackageManager.GetPackageCatalogByName(packageCatalogName));
        var catalogReference = PackageManager.CreateCompositePackageCatalog(options);
        var connectResult = await catalogReference.ConnectAsync();

        return connectResult.PackageCatalog;
    }

    private WinGetProjectionFactory CreateFactory()
    {
        var init = new LocalServerInstanceInitializer { AllowLowerTrustRegistration = true, UseDevClsids = false };
        //var init = new ActivationFactoryInstanceInitializer();
        return new WinGetProjectionFactory(init);
    }

    public INavigationService NavigationService { get; }

    [ObservableProperty]
    ObservableCollection<Person> _Persons;

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsSelect { get; set; }
    }
}
