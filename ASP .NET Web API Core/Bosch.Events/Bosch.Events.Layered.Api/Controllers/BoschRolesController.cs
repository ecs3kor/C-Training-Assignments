using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;

namespace Bosch.Events.Layered.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class BoschRolesController : ControllerBase
    {
        private readonly ICommonRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public BoschRolesController(ICommonRepository<Role> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> Get()
        {
            try
            {
                var roles = _mapper.Map<List<RoleDto>>(await _roleRepository.GetAllAsync());
                if (roles.Count > 0)
                {
                    return Ok(roles);
                }
                return NotFound(new { Message = "Unable to Fetch" });
            }
            catch (Exception)
            {

                throw;
            }
        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<Role>> Post(InsertRoleDto role_dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var roles = _mapper.Map<Role>(role_dto);
                    int result = await _roleRepository.InsertAsync(roles);
                    if (result > 0)
                    {
                        return Created("Get", role_dto);
                    }
                }
                return BadRequest(new { Message = "Role Creation failed!!" });
            }
            catch (Exception)
            {

                throw;
            }
        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            try
            {
                Role result = await _roleRepository.GetDetailsAsync(id);
                var roles = _mapper.Map<RoleDto>(result);
                if (ModelState.IsValid)
                {   
                    if (roles == null)
                    {
                        return BadRequest(new { Message = $"Could Not find ROle with id = {id}" });
                    }
                }
                return Ok(roles);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
