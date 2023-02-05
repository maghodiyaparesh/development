using AutoMapper;
using log4net;
using CrystalFlights.BO.BaseRepository;
using CrystalFlights.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrystalFlights.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private IRepositoryWrapper _repo;
        private readonly IMapper _mapper;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AirportController));

        public AirportController(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repo = repoWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAirports()
        {
            try
            {
                var airports = await _repo.Airport.GetAllAirportsAsync();

                var result = _mapper.Map<List<AirportView>>(airports);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetSearchAirports([FromBody] AirportSearch airportSearch)
        {
            try
            {
                var airports = await _repo.Airport.GetAirportsBySearchAsync(airportSearch);

                var result = _mapper.Map<List<AirportView>>(airports);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveAirport(Airport airportSave)
        {
            try
            {
                var airport = await _repo.Airport.SaveAirport(_mapper.Map<Airport>(airportSave));

                var result = _mapper.Map<AirportView>(airport);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAirport(Airport airportSave)
        {
            try
            {
                if (airportSave.AirportId <= 0)
                    throw new Exception("Record not found.");

                var airport = await _repo.Airport.UpdateAirport(_mapper.Map<Airport>(airportSave));

                var result = _mapper.Map<AirportView>(airport);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAirport(Airport airportSave)
        {
            try
            {
                if (airportSave.AirportId <= 0)
                    throw new Exception("Record not found.");

                var airport = await _repo.Airport.DeleteAirport(_mapper.Map<Airport>(airportSave));

                var result = _mapper.Map<AirportView>(airport);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
