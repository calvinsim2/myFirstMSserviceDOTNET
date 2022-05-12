using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSTest2.Data;
using MSTest2.Models;

namespace MSTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly DeveloperContext _context;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _env;

        public DeveloperController(DeveloperContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        // GET: api/Developer
        [HttpGet]

        public async Task<ActionResult<DeveloperModel>> GetAllGame()
        {
            var developerList = await _context.DeveloperModels.ToListAsync();

            if (developerList.Count < 1)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Success - No Developer Recorded to date.",

                });
            }

            return Ok(new
            {
                StatusCode = 200,
                Message = "Success",
                Result = developerList,
            });
        }

        // GET: api/Developer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeveloperModel>> GetIndividualDeveloper(int id)
        {
            var developer = await _context.DeveloperModels.AsNoTracking()
                .FirstOrDefaultAsync(a => a.DeveloperID == id);

            if (developer == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "No Developer with given ID Found.",

                });
            }

            return Ok(new
            {
                StatusCode = 200,
                Message = "Success",
                Result = developer,

            });
        }

        // POST: api/Blog
        [HttpPost("add")]

        public async Task<ActionResult<DeveloperModel>> AddGame([FromBody] DeveloperModel developerObj)
        {

            if (developerObj == null)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Please input data",

                });
            }

            await _context.DeveloperModels.AddAsync(developerObj);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Success - Developer added.",
                Result = developerObj,
            });
        }
    }
}
