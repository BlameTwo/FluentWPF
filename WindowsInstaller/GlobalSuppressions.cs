// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Interoperability", "CA1416:验证平台兼容性", Justification = "<挂起>", Scope = "member", Target = "~M:WindowsInstaller.Services.WinGetService.GetLocalAppAsync(System.String)~System.Threading.Tasks.Task{System.Collections.ObjectModel.ObservableCollection{Microsoft.Management.Deployment.CatalogPackage}}")]
[assembly: SuppressMessage("Interoperability", "CA1416:验证平台兼容性", Justification = "<挂起>", Scope = "member", Target = "~M:WindowsInstaller.Services.WinGetService.GetRemotePackageCatalog(System.String)~System.Threading.Tasks.Task{Microsoft.Management.Deployment.PackageCatalog}")]
[assembly: SuppressMessage("Interoperability", "CA1416:验证平台兼容性", Justification = "<挂起>", Scope = "member", Target = "~M:WindowsInstaller.Services.WinGetService.SearchAsync(System.String,System.String,System.Threading.CancellationToken)~System.Threading.Tasks.Task{System.Collections.ObjectModel.ObservableCollection{Microsoft.Management.Deployment.CatalogPackage}}")]
[assembly: SuppressMessage("Interoperability", "CA1416:验证平台兼容性", Justification = "<挂起>", Scope = "member", Target = "~P:WindowsInstaller.Services.WinGetService.PackageCatalogs")]
[assembly: SuppressMessage("Interoperability", "CA1416:验证平台兼容性", Justification = "<挂起>", Scope = "member", Target = "~M:WindowsInstaller.Services.WinGetService.InstallPackageAsync(Microsoft.Management.Deployment.CatalogPackage,Microsoft.Management.Deployment.PackageInstallScope,System.Action{Microsoft.Management.Deployment.InstallProgress})~System.Threading.Tasks.Task{Microsoft.Management.Deployment.InstallResultStatus}")]
[assembly: SuppressMessage("Interoperability", "CA1416:验证平台兼容性", Justification = "<挂起>", Scope = "member", Target = "~M:WindowsInstaller.Services.WinGetService.InstallPackageAsync(Microsoft.Management.Deployment.CatalogPackage,Microsoft.Management.Deployment.PackageInstallScope,System.Action{Windows.Foundation.IAsyncOperationWithProgress{Microsoft.Management.Deployment.InstallResult,Microsoft.Management.Deployment.InstallProgress},Microsoft.Management.Deployment.InstallProgress})~System.Threading.Tasks.Task{Microsoft.Management.Deployment.InstallResultStatus}")]
