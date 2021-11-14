using DataAccess.Player.v1.DataEntities;
using System.Threading.Tasks;

namespace DataAccess.Player.v1
{
    public interface IPlayerRepository
    {
        Task<PlayerTableEntity> AddAsync(PlayerTableEntity entity);
        Task<PlayerTableEntity> GetByIDAsync(string rowKey);
        Task<PlayerTableEntity> UpdateAsync(PlayerTableEntity entity);
        Task DeleteAsync(string rowKey);
        Task<PlayerTableEntity> GetByExternalIDAsync(string externalID);
    }
}
