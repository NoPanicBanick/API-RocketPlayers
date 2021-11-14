using API.Player.v1.Models;
using System;
using System.Threading.Tasks;

namespace API.Player.v1.Services
{
    public interface IPlayerService
    {
        Task<PlayerModel> GetByIDAsync(Guid id);
        Task<PlayerModel> GetByExternalIDAsync(string externalId);
        Task<PlayerModel> AddAsync(PlayerAddModel model);
        Task<PlayerModel> UpdateAsync(PlayerUpdateModel model);
        Task DeleteAsync(Guid id);
    }
}
