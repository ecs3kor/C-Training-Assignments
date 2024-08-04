using Bosch.Events.UseCases.DTOs.RoleDtos;
using Bosch.Events.UseCases.Features.Roles.Commands.CreateRole;
using Bosch.Events.UseCases.Features.Roles.Queries.GetAllRoles;
using Bosch.Events.UseCases.Features.Roles.Queries.GetRoleDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Bosch.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoschRolesController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public BoschRolesController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> Get()
        {
            var roles = await _mediatR.Send(new GetAllRolesQuery());
            if (roles == null || roles.Count <= 0)
            {
                return NotFound(new { message = "No roles found!" });
            }
            return Ok(roles);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoleDto>> GetDetails(int id)
        {
            var role = await _mediatR.Send(new GetRoleDetailsQuery() {RoleId = id });
            if (role == null)
            {
                return NotFound(new { message = $"No role found! with {id}" });
            }
            return Ok(role);

        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<RoleDto>> Post(InsertRoleDto roleDto)
        {
            if(ModelState.IsValid)
            {
                int result = await _mediatR.Send(new CreateRoleCommand() { Role_Dto = roleDto});
                if(result > 0)
                {
                    return Created("GetDetails", roleDto);
                }
            }
            return BadRequest(new {Message="Role Creation failed!!"});
        }
    }
}
