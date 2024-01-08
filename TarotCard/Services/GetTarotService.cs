using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using TarotCard.Models;
using TarotCard.Services.Contracts;

namespace TarotCard.Services;

public class GetTarotService : IGetTarotService
{
    public async Task<OrginTarotCard> GetAllCard(CancellationToken token = default)
    {
        try
        {
            var api = $"https://tarotapi.dev/api/v1/cards";
            HttpClient client = new HttpClient();
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, api);
            req.Headers.Add("Accept", "application/json");
            var resultreponse = await client.SendAsync(req,token);
            resultreponse.EnsureSuccessStatusCode();
            var str = await resultreponse.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<OrginTarotCard>(str);
        }
        catch (System.Exception)
        {
            return default;
        }
    }

    /// <summary>
    /// 获得一个随机排序的塔罗牌排序
    /// </summary>
    /// <returns></returns>
    public async Task<OrginTarotCard> GetRandom(int count = 78, CancellationToken token = default)
    {
        try
        {
            var api = $"https://tarotapi.dev/api/v1/cards/random?n={count}";
            HttpClient client = new HttpClient();
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, api);
            req.Headers.Add("Accept", "application/json");
            var resultreponse = await client.SendAsync(req,token);
            resultreponse.EnsureSuccessStatusCode();
            var str = await resultreponse.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<OrginTarotCard>(str);
        }
        catch (System.Exception)
        {
            return default;
        }
    }
}
