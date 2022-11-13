using System.Collections.Generic;

namespace SmartSchool.Controllers.Models
{
    public class Professor
    {
        public Professor() { }

        public Professor(int id, string nome, string sobrenome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}