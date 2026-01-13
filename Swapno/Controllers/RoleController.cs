using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Swapno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService roleService;
        public RoleController(RoleService service)
        {
            roleService = service;
        }
        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var data = await roleService.CreateRole(role);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
        [HttpGet("getallroles")]
        public async Task<IActionResult> Getallroles()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var roles = await roleService.GetAllRoles();
                return Ok(roles);
            }
        }
        [HttpGet("getrole/{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            try
            {
                var role = await roleService.GetRolebyID(id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
        [HttpPatch("updaterole/{id}")]
        public async Task<IActionResult> UpdateRole(int id,UpdateRoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedRole = await roleService.UpdateRole(id, dto);
                return Ok(updatedRole);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


        [HttpDelete("deleterole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await roleService.DeleteRole(id);

            if (!result)
                return NotFound(new { message = "Role not found" });

            return Ok(new { message = "Role deleted successfully" });
        }


    }
}
