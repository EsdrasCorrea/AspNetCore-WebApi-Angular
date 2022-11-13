using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.Controllers.Models;

namespace SmartSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "esdras",
                Sobrenome = "Corrêa",
                Telefone = "1234567"
            },
            new Aluno(){
                Id = 2,
                Nome = "Pedro",
                Sobrenome = "Henrique",
                Telefone = "4546767"
            },
            new Aluno(){
                Id = 3,
                Nome = "Arthur",
                Sobrenome = "Gonçalves",
                Telefone = "35745345"
            },
            new Aluno(){
                Id = 4,
                Nome = "Joyce",
                Sobrenome = "Pereira",
                Telefone = "y8689675"
            },
        };

        public AlunoController() { }

        [HttpGet]
        public IActionResult Get(){
            return Ok(Alunos);
        } 

        [HttpGet("byId/{id}")]
        public IActionResult GetbyId(int id){
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        // api/aluno/nome
        [HttpGet("ByName")]
        public IActionResult GetbyId(string nome, string sobrenome){
        var aluno = Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        // api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno){
            return Ok(aluno);
        }  

        // api/aluno/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){
            return Ok(aluno);
        }
        
        // api/aluno/id
        [HttpDelete("{id}")]
        public IActionResult Delele(int id){
            return Ok();
        }          
    }
}