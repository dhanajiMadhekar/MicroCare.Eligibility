using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EligibilityController : ControllerBase
    {
        private readonly IEligibilityService _service;

        public EligibilityController(IEligibilityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] EligibilitySearchDto search)
        {
            return Ok(await _service.SearchAsync(search));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEligibilityDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }
    }
}
