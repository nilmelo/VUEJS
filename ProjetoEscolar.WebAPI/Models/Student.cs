namespace ProjetoEscolar.WebAPI.Models
{
    public class Student
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Lastname { get; set; }
       public string DateBirth { get; set; }
       public int ProfessorId { get; set; }
       public Professor Professor { get; set; } 
    }
}