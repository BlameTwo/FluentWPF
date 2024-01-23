using System;
using System.Collections.ObjectModel;
using WindowsInstaller.Models;

namespace WindowsInstaller.Services.Contracts;

public interface IPackageTaskMananger
{
    public ObservableCollection<PackageCommandBase> Packages { get; }

    public ObservableCollection<PackageCommandBase> GetPackages();

    public Tuple<bool, string> Add(PackageCommandBase packageCommand);

    public void Remove(PackageCommandBase packageCommand);
}
