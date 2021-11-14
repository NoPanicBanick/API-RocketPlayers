using DataAccess.Player.v1.DataEntities;
using Microsoft.Azure.Cosmos.Table;
using PoorMan;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Player.v1
{
    public class PlayerRepository : IPlayerRepository
    {
        private const string _defaultPartionKey = "1";
        private readonly ITable<PlayerTableEntity> _tableService;

        public PlayerRepository(ITable<PlayerTableEntity> tableService)
        {
            _tableService = tableService;
        }

        public async Task<PlayerTableEntity> AddAsync(PlayerTableEntity entity)
        {
            entity.RowKey = Guid.NewGuid().ToString();
            entity.PartitionKey = _defaultPartionKey;
            return await _tableService.AddAsync(entity);
        }

        public async Task<PlayerTableEntity> GetByIDAsync(string rowKey)
        {
            return await _tableService.GetAsync(_defaultPartionKey, rowKey);
        }

        public async Task<PlayerTableEntity> GetByExternalIDAsync(string externalID)
        {
            var query = TableQuery.GenerateFilterCondition(nameof(PlayerTableEntity.ExternalID), QueryComparisons.Equal, externalID);
            return (await _tableService.QueryAsync(query)).FirstOrDefault();
        }

        public async Task<PlayerTableEntity> UpdateAsync(PlayerTableEntity entity)
        {
            entity.PartitionKey= _defaultPartionKey;
            return await _tableService.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string rowKey)
        {
            await _tableService.DeleteAsync(_defaultPartionKey, rowKey);
        }
    }
}
