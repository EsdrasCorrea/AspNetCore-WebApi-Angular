using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Controllers.Models;
using SmartSchool.Data;

namespace SmartSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;

        public AlunoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.Alunos);
        } 

        [HttpGet("byId/{id}")]
        public IActionResult GetbyId(int id){
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        // api/aluno/nome
        [HttpGet("ByName")]
        public IActionResult GetbyId(string nome, string sobrenome){
        var aluno = _context.Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        // api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno){
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }  

        // api/aluno/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        
        // api/aluno/id
        [HttpDelete("{id}")]
        public IActionResult Delele(int id){
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }          
    }
}