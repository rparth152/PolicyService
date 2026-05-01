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
        private readonly IPolicyTypeService service;

        public PolicyTypeController(IPolicyTypeService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddType([FromBody] PolicyTypeDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            var result = await service.AddTypePolicy(dto);

            return Ok(new
            {
                success = result,
                message = "Policy Type Added Successfully"
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTypes()
        {
            var data = await service.GetAllPolicies();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var data = await service.GetTypeById(id);

            if (data == null)
                return NotFound("Policy Type not found");

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateType(int id, [FromBody] PolicyTypeDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            var result = await service.UpdateType(id, dto);

            return Ok(new
            {
                success = result,
                message = "Policy Type Updated Successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var result = await service.DeleteType(id);

            return Ok(new
            {
                success = result,
                message = "Policy Type Deleted (Soft Delete)"
            });
        }
    }
}
