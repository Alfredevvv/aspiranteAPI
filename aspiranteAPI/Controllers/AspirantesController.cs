

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspiranteAPI.Models;
using aspiranteAPI.DTOs;
using FluentValidation;

namespace aspiranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspirantesController : ControllerBase
    {
        private readonly AspiranteContext _context;
        private IValidator<AspiranteModifiedDto> _validator;
        public AspirantesController(AspiranteContext context, 
            IValidator<AspiranteModifiedDto> validator)
        {
            _context = context;
            _validator = validator;
        }

        private bool AspiranteExists(int id)
        {
            return (_context.Aspirantes?.Any(e => e.IDAspirante == id)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<IEnumerable<Aspirante>> GetAllAspirantes()
        {
            return await _context.Aspirantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aspirante>> GetAspiranteById(int id)
        {
            var aspirante = await _context.Aspirantes.FindAsync(id);
            if (aspirante == null)
            {
                return NotFound();
            }
            return aspirante;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Aspirante>> UpdateAspirante(int id, AspiranteModifiedDto aspiranteDto)
        {
            var validationResult = await _validator.ValidateAsync(aspiranteDto);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var aspirante = await _context.Aspirantes.FindAsync(id);
            if (aspirante == null)
            {
                return NotFound();
            }
            //Aqui usualmente se utilizarian automappers en lugar de esto.
              aspirante.Nombre = aspiranteDto.Nombre;
              aspirante.Apellidos = aspiranteDto.Apellidos;
              aspirante.Edad = aspiranteDto.Edad;
              aspirante.Estatura = aspiranteDto.Estatura;
              aspirante.Correo = aspiranteDto.Correo;
              aspirante.Telefono = aspiranteDto.Telefono;
            _context.Entry(aspirante).State = EntityState.Modified;
            try 
            {
                await _context.SaveChangesAsync();
                return Ok(aspirante);
            } catch (DbUpdateConcurrencyException) {
                if (!AspiranteExists(id))
                {   return NotFound();  }
                else
                {
                    return Problem("Ha sucedido un error al actualizar el aspirante");
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult<Aspirante>> PostAspirante(AspiranteModifiedDto aspiranteDto)
        {
            var validationResult = await _validator.ValidateAsync(aspiranteDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            //Aqui usualmente se utilizarian automappers en lugar de esto.
            var _aspirante = new Aspirante
            {
                Nombre = aspiranteDto.Nombre,
                Apellidos = aspiranteDto.Apellidos,
                Edad = aspiranteDto.Edad,
                Estatura = aspiranteDto.Estatura,
                Correo = aspiranteDto.Correo,
                Telefono = aspiranteDto.Telefono
            };
            _context.Aspirantes.Add(_aspirante);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAspiranteById", new { id = _aspirante.IDAspirante }, _aspirante);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspirante(int id)
        {
            var aspirante = await _context.Aspirantes.FindAsync(id);
            if (aspirante == null)
            {
                return NotFound();
            }
            _context.Aspirantes.Remove(aspirante);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
