using AutoMapper;
using MaalSuchiAPI.Contracts;
using MaalSuchiAPI.DTO;
using MaalSuchiAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaalSuchiAPI.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public StoreController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Store.GetAllStoreItems(false));
        }

        [HttpPost]
        public async Task<IActionResult> Save(StoreItemDto storeItemDto)
        {
            await _repository.Store.SaveStoreItem(_mapper.Map<StoreItem>(storeItemDto));
            _repository.Save();
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update(Guid Id, StoreItemDto storeItemDto)
        {
            _repository.Store.UpdateStoreItem(Id, _mapper.Map<StoreItem>(storeItemDto));
            _repository.Save();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id, StoreItemDto storeItemDto)
        {
            _repository.Store.DeleteStoreItem(Id, _mapper.Map<StoreItem>(storeItemDto));
            _repository.Save();
            return Ok();
        }
    }
}
