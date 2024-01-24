using Microsoft.Management.Deployment;
using System.Text.Json.Serialization;

namespace WindowsInstaller.Models;

public class InstallerConfig
{
    [JsonPropertyName("AppTheme")]
    public string Theme { get; set; }

    [JsonPropertyName("Backdrop")]
    public string SystemBackdrop { get; set; }

    [JsonPropertyName("InstallPath")]
    public string InstallPath { get; set; }

    [JsonPropertyName("InstallMode")]
    public PackageInstallMode InstallMode { get; set; }

    [JsonPropertyName("UninstallMode")]
    public PackageUninstallMode UninstallMode { get; set; }

    public static InstallerConfig CreateDefault()
    {
        return new InstallerConfig()
        {
            Theme = "Dark",
            SystemBackdrop = "Acrylic",
            InstallMode = PackageInstallMode.Silent,
            UninstallMode = PackageUninstallMode.Silent,
            InstallPath = "Default"
        };
    }
}
