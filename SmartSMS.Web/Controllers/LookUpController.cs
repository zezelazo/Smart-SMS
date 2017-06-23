using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSMS.Web.Data;

namespace SmartSMS.Web.Controllers
{

    [Route("api/[controller]")]
    public class LookUpController : Controller
    {
        internal readonly LookUpsData _repo;
        internal readonly ILogger<LookUpController> _logger;
        public LookUpController(LookUpsData repo, ILogger<LookUpController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet("levels")]
        public async Task<IActionResult> GetLevels()
        {
            try
            {
                _logger.LogInformation($"Trying to get items levels");
                var result = await _repo.GetLevels();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Cant get levels");
            }
            return BadRequest();
        }

        [HttpGet("levels/{levelId}/grades")]
        public async Task<IActionResult> GetGradesByLevel(int levelId)
        {
            try
            {
                _logger.LogInformation($"Trying to get items grades for the level {levelId}");
                var result = await _repo.GetGradesByLevel(levelId);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Cant get grades for the level {levelId}");
            }
            return BadRequest();
        }

        [HttpGet("levels/{levelId}/grades/{gradeId}/classes")]
        public async Task<IActionResult> GetClassesByGrade(int levelId,int gradeId)
        {
            try
            {
                _logger.LogInformation($"Trying to get items classes for the grade {gradeId}");
                var result = await _repo.GetClassesByGrade(gradeId);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Cant get grades for the level {gradeId}");
            }
            return BadRequest();
        }
    }
}
