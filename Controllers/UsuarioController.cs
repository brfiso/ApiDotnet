using AulaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AulaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public UsuarioController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id < 1) return BadRequest("Usuário inválido.");

                var usuario = _context.Usuario.Find(id);
                return Ok(usuario);
            }
            catch (DbException de)
            {
                return BadRequest("Banco de dados indisponível.");
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro.");
            }
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var lista = await _context.Usuario.ToListAsync();
                return Ok(lista);
            }
            catch (DbException de)
            {
                return BadRequest("Banco de dados indisponível.");
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    return BadRequest("Usuário inválido");

                var existeCPF = _context.Usuario.Where(u => u.Cpf == usuario.Cpf).Any();

                if (existeCPF)
                    return BadRequest("CPF já cadastrado.");

                await _context.Usuario.AddAsync(usuario);
                _context.SaveChanges();

                return Ok(usuario);
            }
            catch (DbException de)
            {
                return BadRequest("Banco de dados indisponível.");
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    return BadRequest("Usuário inválido");

                var usuarioAntigo = _context.Usuario.Find(usuario.Id);

                if (usuarioAntigo == null)
                    return BadRequest("Usuário não encontrado.");

                if (usuario.Cpf != usuarioAntigo.Cpf)
                    return BadRequest("Não é possível alterar o CPF");

                _context.Entry<Usuario>(usuario).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(usuario);
            }
            catch (DbException de)
            {
                return BadRequest("Banco de dados indisponível.");
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 1) return BadRequest("Usuário inválido.");

                var usuario = _context.Usuario.Find(id);

                if (usuario == null) return BadRequest("Usuário não encontrado.");

                _context.Usuario.Remove(usuario);
                _context.SaveChanges();

                return Ok();
            }
            catch (DbException de)
            {
                return BadRequest("Banco de dados indisponível.");
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro.");
            }
        }
    }
}