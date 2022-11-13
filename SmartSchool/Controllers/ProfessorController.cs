using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController() { }
        public IActionResult Get(){
            return Ok("Professores: Marta, Andre");
        }        
    }
}