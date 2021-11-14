using API.Player.v1.Models;
using AutoMapper;
using DataAccess.Player.v1;
using DataAccess.Player.v1.DataEntities;
using System;
using System.Threading.Tasks;

namespace API.Player.v1.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IMapper mapper, IPlayerRepository playerRepository)
        {
            _mapper = mapper;
            _playerRepository = playerRepository;
        }

        public async Task<PlayerModel> GetByIDAsync(Guid id)
        {
            var response = await _playerRepository.GetByIDAsync(id.ToString());
            return _mapper.Map<PlayerModel>(response);
        }

        public async Task<PlayerModel> GetByExternalIDAsync(string externalId)
        {
            var response = await _playerRepository.GetByIDAsync(externalId);
            return _mapper.Map<PlayerModel>(response);
        }

        public async Task<PlayerModel> AddAsync(PlayerAddModel model)
        {
            var entity = _mapper.Map<PlayerTableEntity>(model);
            var response = await _playerRepository.AddAsync(entity);
            return _mapper.Map<PlayerModel>(response);
        }

        public async Task<PlayerModel> UpdateAsync(PlayerUpdateModel model)
        {
            var entity = _mapper.Map<PlayerTableEntity>(model);
            var response = await _playerRepository.UpdateAsync(entity);
            return _mapper.Map<PlayerModel>(response);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _playerRepository.DeleteAsync(id.ToString());
        }
    }
}
