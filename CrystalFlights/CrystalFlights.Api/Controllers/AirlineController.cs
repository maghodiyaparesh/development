using AutoMapper;
using CrystalFlights.BO.BaseRepository;
using CrystalFlights.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CrystalFlights.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    [Authorize]
    public class AirlineController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<AirlineController> _logger;

        public AirlineController(IRepositoryWrapper repoWrapper, IMapper mapper, ILogger<AirlineController> logger)
        {
            _repo = repoWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAirlines()
        {
            try
            {
                var airlines = await _repo.Airline.GetAllAirlinesAsync();

                var result = _mapper.Map<List<AirlineView>>(airlines);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetSearchAirlines([FromBody] AirlineSearch airlineSearch)
        {
            try
            {
                var airlines = await _repo.Airline.GetAirlinesBySearchAsync(airlineSearch);

                var result = _mapper.Map<List<AirlineView>>(airlines);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveAirline(Airline airlineSave)
        {
            try
            {
                var airline = await _repo.Airline.SaveAirline(_mapper.Map<Airline>(airlineSave));

                var result = _mapper.Map<AirlineView>(airline);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAirline(Airline airlineSave)
        {
            try
            {
                if (airlineSave.AirlineId <= 0)
                    throw new Exception("Record not found.");

                var airline = await _repo.Airline.UpdateAirline(_mapper.Map<Airline>(airlineSave));

                var result = _mapper.Map<AirlineView>(airline);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAirline(Airline airlineSave)
        {
            try
            {
                if (airlineSave.AirlineId <= 0)
                    throw new Exception("Record not found.");

                var airline = await _repo.Airline.DeleteAirline(_mapper.Map<Airline>(airlineSave));

                var result = _mapper.Map<AirlineView>(airline);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
