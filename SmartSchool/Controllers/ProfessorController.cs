using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Controllers.Models;
using SmartSchool.Data;

namespace SmartSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Get(){
            return Ok(_context.Professores);
        }  

        [HttpGet("byId/{id}")]
        public IActionResult GetbyId(int id){
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);
        }  

        // api/professor/nome
        [HttpGet("ByName")]
        public IActionResult GetbyId(string nome, string sobrenome){
        var professor = _context.Professores.FirstOrDefault(p => 
            p.Nome.Contains(nome) && p.Sobrenome.Contains(sobrenome));
            if(professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);
        }   

        // api/professor
        [HttpPost]
        public IActionResult Post(Professor professor){
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        } 

        // api/professor/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor){
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        } 

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor){
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        
        // api/professor/id
        [HttpDelete("{id}")]
        public IActionResult Delele(int id){
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if(professor == null) return BadRequest("Professor não encontrado");
            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }   
    }
}