using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Policy.Application.DTO;
using Policy.Application.Interface;

namespace Policy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyTypeController : ControllerBase
    {
        private readonly IPolicyTypeService _service;

        public PolicyTypeController(IPolicyTypeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddType([FromBody] PolicyTypeDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            var result = await _service.AddTypePolicy(dto);

            return Ok(new
            {
                success = result,
                message = "Policy Type Added Successfully"
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var data = await _service.GetTypeById(id);

            if (data == null)
                return NotFound("Policy Type not found");

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateType(int id, [FromBody] PolicyTypeDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            var result = await _service.UpdateType(id, dto);

            return Ok(new
            {
                success = result,
                message = "Policy Type Updated Successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var result = await _service.DeleteType(id);

            return Ok(new
            {
                success = result,
                message = "Policy Type Deleted (Soft Delete)"
            });
        }
    }
}
