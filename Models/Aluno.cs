namespace GenerationApiTestFinal.Models
{
    public class Aluno : Entity
    {
        public string ?Nome { get; set; }
        public int Idade { get; set; }
        public ICollection<Materia> ?Materias { get; set; }
    }
}
