namespace GenerationApiTestFinal.Models
{
    public class Materia : Entity
    {
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set;}
        public Professor ?Professor { get; set; }
        public Sala ?Sala { get; set; } 
        
    }
}
