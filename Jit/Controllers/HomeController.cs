using AutoMapper;
using Jit.Dtos;
using Jit.Interfaces;
using Jit.Models;
using Jit.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Jit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVisitRepository _visitRepository;
        public HomeController(IMapper mapper, IVisitRepository visitRepository)
        {
            _mapper = mapper;
            _visitRepository = visitRepository;
        }

        [HttpDelete("DeleteVisit{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            try
            {
                await _visitRepository.DeleteAsync(id);
                return Ok(new { success = true, message = "Usuniêto wizytê!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateVisit")]
        public async Task<IActionResult> CreateVisit(VisitDto dto)
        {
            try
            {
                if (_visitRepository.VisitExists(dto.Date))
                    return BadRequest("Wizyta w tym terminie jest zajêta");
                else
                {
                    if (_visitRepository.DateOfVisitValidator(dto.Date))
                    {
                        await _visitRepository.AddAsync(_mapper.Map<Visit>(dto));

                        return Ok(new { success = true, message = "Wizyta zosta³a pomyœlnie dodana!" });
                    }
                    else
                    {
                        return BadRequest(" Data musi byæ w dniach od poniedzia³ku do pi¹tku oraz godzina musi byæ miêdzy 8:00 a 16:00.");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateVisit")]
        public async Task<IActionResult> UpdateVisit(VisitDto dto)
        {
            try
            {
                if (_visitRepository.VisitExists(dto.Date))
                    return BadRequest("Wizyta w tym terminie jest zajêta");
                else
                {
                    if (_visitRepository.DateOfVisitValidator(dto.Date))
                    {
                        await _visitRepository.UpdateAsync(_mapper.Map<Visit>(dto));

                        return Ok(new { success = true, message = "Wizyta zosta³a pomyœlnie edytowana!" });
                    }
                    else
                        return BadRequest(" Data musi byæ w dniach od poniedzia³ku do pi¹tku oraz godzina musi byæ miêdzy 8:00 a 16:00.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetVisits")]
        public async Task<ActionResult<IEnumerable<VisitDto>>> GetVisits()
        {
            try
            {
                var visits = await _visitRepository.GetAllAsync();
                if (!visits.Any())
                {
                    return BadRequest("Nie znaleziono zapisanych wizyt.");
                }
                var records = _mapper.Map<List<VisitDto>>(visits);

                return Ok(records.OrderByDescending(x => x.Date));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetVisit{id}")]
        public async Task<ActionResult<VisitDto>> GetVisit(int id)
        {
            try
            {
                var visit = await _visitRepository.GetAsync(id);
                var record = _mapper.Map<VisitDto>(visit);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
