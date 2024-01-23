using System;
using System.Collections.ObjectModel;
using WindowsInstaller.Models;
using WindowsInstaller.Services.Contracts;

namespace WindowsInstaller.Services;

public class PackageTaskManager : IPackageTaskMananger
{
    
    public ObservableCollection<PackageCommandBase> Packages { get; private set; }

    public PackageTaskManager()
    {
        Packages = new();
    }

    public Tuple<bool,string> Add(PackageCommandBase packageCommand)
    {
        foreach (var item in this.Packages)
        {
            if (item.CommandId == packageCommand.CommandId)
            {
                return Tuple.Create(true,"存在相同的任务");
            }
        }
        Packages.Add(packageCommand);
        return Tuple.Create(true, "创建任务成功");
    }

    public ObservableCollection<PackageCommandBase> GetPackages()
    {
        return Packages;
    }

    public void Remove(PackageCommandBase packageCommand)
    {
        Packages.Remove(packageCommand);
    }
}