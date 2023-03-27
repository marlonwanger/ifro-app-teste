using IfroPratica_Testes.Data;
using IfroPratica_Testes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IfroPratica_Testes.Controllers
{
    [Route("rpgchar")]
    [ApiController]
    public class RpgCharacterController : ControllerBase
    {
        private readonly DataContext context;

        public RpgCharacterController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RpgCharacter rpgCharacter)
        {
            this.context.RpgCharacters.Add(rpgCharacter);
            await this.context.SaveChangesAsync();
            return new JsonResult(new { Result = "Created" });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RpgCharacter>>> GetAll()
        {
            var chars = await this.context.RpgCharacters.ToListAsync();
            return Ok(chars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RpgCharacter>> GetById(int id)
        {
            var character = await this.context.RpgCharacters.FirstOrDefaultAsync( x => x.Id == id);

            if(character == null)
            {
                return BadRequest("Character not found");
            }

            return Ok(character);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] RpgCharacter rpgCharacter, int id)
        {
            if (id != rpgCharacter.Id)
                return BadRequest("Character not found");

            if (rpgCharacter == null)
                return BadRequest("Data is null");

            this.context.RpgCharacters.Update(rpgCharacter);

            await this.context.SaveChangesAsync();

            return new JsonResult(new
            {
                Result = "Updated",
                Id = id
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var getChar = await this.context.RpgCharacters.FirstOrDefaultAsync(x => x.Id == id);

            if(getChar is null)
            {
                return BadRequest("Char not found");
            }

            this.context.RpgCharacters.Remove(getChar);
            await this.context.SaveChangesAsync();
            return new JsonResult(new
            {
                Result = "Deleted"
            });        
        }
    }
}
