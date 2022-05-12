using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MStest.Data;
using MStest.Models;

namespace MStest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameContext _context;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _env;

        public GameController(GameContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        // GET: api/Game
        [HttpGet]

        public async Task<ActionResult<GameModel>> GetAllGame()
        {
            var gameList = await _context.GameModels.ToListAsync();

            if (gameList.Count < 1)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Success - No Game Recorded to date.",

                });
            }

            return Ok(new
            {
                StatusCode = 200,
                Message = "Success",
                Result = gameList,
            });
        }

        // GET: api/Game/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameModel>> GetIndividualGame(int id)
        {
            var game = await _context.GameModels.AsNoTracking()
                .FirstOrDefaultAsync(a => a.GameID == id);

            if (game == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "No Game with given ID Found.",

                });
            }

            return Ok(new
            {
                StatusCode = 200,
                Message = "Success",
                Result = game,

            });
        }

        // POST: api/Blog
        [HttpPost("add")]

        public async Task<ActionResult<GameModel>> AddGame([FromBody] GameModel gameObj)
        {
          
            if (gameObj == null)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Please input data",

                });
            }
         
            await _context.GameModels.AddAsync(gameObj);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Success - Game added.",
                Result = gameObj,
            });
        }
    }
}
