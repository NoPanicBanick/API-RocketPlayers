using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using API.Player.v1.Services;
using API.Player.v1.Models;

namespace API.Player
{
    public class PlayerTriggers
    {
        private readonly IPlayerService _playerService;

        public PlayerTriggers(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [FunctionName("PostAsync")]
        public async Task<IActionResult> PostAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "player")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var addModel = JsonConvert.DeserializeObject<PlayerAddModel>(requestBody);
            var responseModel = await _playerService.AddAsync(addModel);
            return new OkObjectResult(responseModel);
        }

        [FunctionName("GetByIDAsync")]
        public async Task<IActionResult> GetByIDAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "player/{id:Guid}")] 
            HttpRequest req, Guid id, ILogger log)
        {
            var response = await _playerService.GetByIDAsync(id);
            return new OkObjectResult(response);
        }

        [FunctionName("GetByExternalIDAsync")]
        public async Task<IActionResult> GetByExternalIDAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "player/externalId/{externalId}")] 
            HttpRequest req, string externalId, ILogger log)
        {
            var response = await _playerService.GetByExternalIDAsync(externalId);
            return new OkObjectResult(response);
        }

        [FunctionName("PutAsync")]
        public async Task<IActionResult> PutAsync(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "player/{id:Guid}")] HttpRequest req, Guid id, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateModel = JsonConvert.DeserializeObject<PlayerUpdateModel>(requestBody);
            updateModel.ID = id;
            var responseModel = await _playerService.UpdateAsync(updateModel);
            return new OkObjectResult(responseModel);
        }

        [FunctionName("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "player/{id:Guid}")] HttpRequest req, Guid id, ILogger log)
        {
            await _playerService.DeleteAsync(id);
            return new NoContentResult();
        }
    }
}
