using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.EventDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bosch.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors]
    public class BoschEventsController : ControllerBase
    {
        private readonly ICommonRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public BoschEventsController(ICommonRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> Get()
        {
            try
            {
                var events = _mapper.Map<List<EventDto>>(await _eventRepository.GetAllAsync());
                if (events.Count > 0)
                {
                    return Ok(events);
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
        public async Task<ActionResult<Event>> Post(InsertEventDto event_dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var events = _mapper.Map<Event>(event_dto);
                    int result = await _eventRepository.InsertAsync(events);
                    if (result > 0)
                    {
                        return Created("Get", event_dto);
                    }
                }
                return BadRequest(new { Message = "Event Creation failed!!" });
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
        public async Task<ActionResult<Event>> Get(int id)
        {
            try
            {
                Event result = await _eventRepository.GetDetailsAsync(id);
                var events = _mapper.Map<EventDto>(result);
                if (ModelState.IsValid)
                {
                    if (events == null)
                    {
                        return BadRequest(new { Message = $"Could Not find ROle with id = {id}" });
                    }
                }
                return Ok(events);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
