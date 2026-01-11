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
        public RoleController( RoleService service) { 
            roleService = service;
        }
        [HttpPost("createrole")]
        public IActionResult createRole(CreateRoleDto role)
        {
            if (ModelState.IsValid)
            {
                var data = roleService.CreateRole(role);
                return Ok(data);
            }
            return BadRequest(ModelState);

        }
        [HttpGet("getallroles")]
        public IActionResult getallroles()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var roles = roleService.GetAllRoles();
                return Ok(roles);
            }
        }

    }
}
