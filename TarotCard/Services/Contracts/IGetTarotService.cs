using System.Threading.Tasks;
using System.Threading;
using TarotCard.Models;

namespace TarotCard.Services.Contracts;

public interface IGetTarotService
{
    public Task<OrginTarotCard> GetRandom(int count = 78, CancellationToken token = default);

    public Task<OrginTarotCard> GetAllCard(CancellationToken token = default);
}