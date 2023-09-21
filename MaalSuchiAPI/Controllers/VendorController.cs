using AutoMapper;
using MaalSuchiAPI.Contracts;
using MaalSuchiAPI.DTO;
using MaalSuchiAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaalSuchiAPI.Controllers
{
    [Route("api/vendor")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public VendorController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Vendor.GetAllVendors(false));
        }

        [HttpPost]
        public async Task<IActionResult> Save(VendorDto storeItemDto)
        {
            await _repository.Vendor.SaveVendor(_mapper.Map<Vendor>(storeItemDto));
            _repository.Save();
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update(Guid Id, VendorDto storeItemDto)
        {
            _repository.Vendor.UpdateVendor(Id, _mapper.Map<Vendor>(storeItemDto));
            _repository.Save();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id, VendorDto storeItemDto)
        {
            _repository.Vendor.DeleteVendor(Id, _mapper.Map<Vendor>(storeItemDto));
            _repository.Save();
            return Ok();
        }
    }
}
