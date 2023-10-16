using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsSubject
{
    public class Subject
    {
        [Key]
        public int IdSubject { get; set; }
        public string name { get; set; }
        public int IdProfessor { get; set; }
    }
}