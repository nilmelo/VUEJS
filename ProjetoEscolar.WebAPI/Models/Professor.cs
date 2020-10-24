using System.Collections.Generic;

namespace ProjetoEscolar.WebAPI.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}