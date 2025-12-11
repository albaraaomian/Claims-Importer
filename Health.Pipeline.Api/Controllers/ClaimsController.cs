using Health.Pipeline.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Health.Pipeline.Api.Data;

namespace Health.Pipeline.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly ClaimImportService _importService;
        private readonly ClaimsDbContext _db;

        public ClaimsController(ClaimImportService importService, ClaimsDbContext db)
        {
            _importService = importService;
            _db = db;
        }

        [HttpPost("ingest/csv")]
        public async Task<IActionResult> IngestCsv([FromForm] IFormFile file)
        {
            if (file == null) return BadRequest("No file uploaded.");
            var claims = await _importService.ImportCsvAsync(file.OpenReadStream());
            return Ok(new { processed = claims.Count });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var claims = _db.Claims.OrderByDescending(c => c.CreatedAt).Take(200).ToList();
            return Ok(claims);
        }
    }
}
