using AutoMapper;
using BCrypt.Net;
using Bosch.Events.Domain.Entities;
using Bosch.Events.Layered.Api.Jwt;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.EventDtos;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using Bosch.Events.UseCases.DTOs.UserDtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bosch.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class BoschUserController : ControllerBase
    {
        private readonly ICommonRepository<User> _UserRepository;
        private readonly IMapper _mapper;
        private readonly IBoschAuthenticator _authenticator;
        private readonly ICommonRepository<Role> _RoleRepository;
        private readonly ITokenManager _tokenManager;

        public BoschUserController(ICommonRepository<User> UserRepository, IMapper mapper, IBoschAuthenticator authenticator, ICommonRepository<Role> roleRepository, ITokenManager tokenManager)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
            _authenticator = authenticator;
            _RoleRepository = roleRepository;
            _tokenManager = tokenManager;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            try
            {
                var Users = _mapper.Map<List<UserDto>>(await _UserRepository.GetAllAsync());
                if (Users.Count > 0)
                {
                    return Ok(Users);
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
        public async Task<ActionResult<User>> Post(InsertUserDto User_dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(User_dto.Password);
                    User_dto.Password = hashedPassword;
                    var Users = _mapper.Map<User>(User_dto);
                    int result = await _UserRepository.InsertAsync(Users);
                    if (result > 0)
                    {
                        return Created("Get", User_dto);
                    }
                }
                return BadRequest(new { Message = "User Creation failed!!" });
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
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                User result = await _UserRepository.GetDetailsAsync(id);
                var Users = _mapper.Map<UserDto>(result);
                if (ModelState.IsValid)
                {
                    if (Users == null)
                    {
                        return BadRequest(new { Message = $"Could Not find ROle with id = {id}" });
                    }
                }
                return Ok(Users);
            }
            catch (Exception)
            {

                throw;
            }
        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Credentials")]
        public async Task<ActionResult<UserDto>> CheckCredentialsPost(UserDto User_dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Users = _mapper.Map<User>(User_dto);
                    var result = await _authenticator.Authenticate(Users);
                    if (result != null)
                    {
                        var passwordVerification = BCrypt.Net.BCrypt.Verify(User_dto.Password, result.Password);
                        if (!passwordVerification)
                        {
                            return BadRequest(new { Message = "Please check you password" });
                        }
                        var role = await _RoleRepository.GetDetailsAsync(result.RoleId);
                        return Ok(new AuthResponse() { Email=result.UserName,Role="Dummy",Success=true,token=_tokenManager.GenerateToken(result,role.RoleName)});
                    }
                    else
                    {
                        return BadRequest(new {Message ="User Does not exist"});
                    }
                }
                return BadRequest(new { Message = "Authentication Failed!!" });
            }
            catch (Exception)
            {

                throw;
            }
        }




        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("UserRoles")]
        public async Task<ActionResult<UserDto>> GetRole(UserDto User_dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Users = _mapper.Map<User>(User_dto);
                    var result = await _authenticator.Authenticate(Users);
                    if (result != null)
                    {
                        var passwordVerification = BCrypt.Net.BCrypt.Verify(User_dto.Password, result.Password);
                        if (!passwordVerification)
                        {
                            return BadRequest(new { Message = "Please check you password" });
                        }
                        var role = await _RoleRepository.GetDetailsAsync(result.RoleId);
                        var roleResult = _mapper.Map<RoleDto>(role);
                        if(roleResult == null)
                        {
                            return NotFound(new { Message = "Role not found" });
                        }
                        return Ok(new AuthResponse() { Email = result.UserName, Role = roleResult.RoleName, Success = true, token = "NoToken" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "User Does not exist" });
                    }
                }
                return BadRequest(new { Message = "Authentication Failed!!" });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
