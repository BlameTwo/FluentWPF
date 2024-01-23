using System.Collections.Generic;
using System.Threading.Tasks;

namespace WindowsInstaller.Services.Contracts;

public interface ILocalSettingsService
{
    public Task<T> ReadValueAsync<T>(string key)
        where T:struct;
    public Task WriteValueAsync<T>(string key, T value);

    public Task<T> ReadObjectValueAsync<T>(string key)
        where T:class;


    public Task InitSettingsAsync(Dictionary<string, object> values);
}