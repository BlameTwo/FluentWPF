using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WindowsInstaller.Core.Helpers;
using WindowsInstaller.Properties;

namespace WindowsInstaller.Services.Contracts;

public class LocalSettingsService : ILocalSettingsService
{
    private Dictionary<string, object> _settings;

    public async Task InitSettingsAsync(Dictionary<string, object> values)
    {
        FileHelper.CheckTextFile(GlobalUsings.SettingJsonPath);
        var stringjsonstr = await File.ReadAllTextAsync(GlobalUsings.SettingJsonPath);
        if (!string.IsNullOrWhiteSpace(stringjsonstr))
        {
            this._settings = JsonSerializer.Deserialize<Dictionary<string, object>>(
                stringjsonstr
            );
        }
        else
        {
            this._settings = new();
        }
        foreach (var item in values)
        {
            if (_settings.ContainsKey(item.Key))
            {
                continue;
            }
            else
            {
                _settings.TryAdd(item.Key, item.Value);
            }
        }
        await SaveFile();
    }

    public async Task<T> ReadObjectValueAsync<T>(string key)
        where T : class
    {
        await RefreshSetting();
        var result = _settings.TryGetValue(key, out var value);
        if (result)
        {
            if (
                value is JsonElement json
                && (json.ValueKind == JsonValueKind.Object || json.ValueKind == JsonValueKind.Array)
            )
            {
                return json.Deserialize<T>();
            }
            else
            {
                throw new ArgumentException("值类型请勿使用Object读取");
            }
        }
        return default;
    }

    public async Task<T> ReadValueAsync<T>(string key)
        where T : struct
    {
        await RefreshSetting();
        var result = _settings.TryGetValue(key, out var value);
        if (result)
            return (T)value;
        else
            return default(T);
    }

    public async Task WriteValueAsync<T>(string key, T value)
    {
        await RefreshSetting();
        if (_settings.ContainsKey(key))
        {
            _settings[key] = value;
        }
        else
        {
            _settings.TryAdd(key, value);
        }
        await SaveFile();
    }

    public async Task RefreshSetting()
    {
        this._settings = JsonSerializer.Deserialize<Dictionary<string, object>>(
            await File.ReadAllTextAsync(GlobalUsings.SettingJsonPath)
        );
    }

    private async Task SaveFile()
    {
        var resultjson = JsonSerializer.Serialize(this._settings);
        await File.WriteAllTextAsync(GlobalUsings.SettingJsonPath, resultjson);
    }
}
