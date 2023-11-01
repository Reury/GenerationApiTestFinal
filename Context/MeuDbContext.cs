using GenerationApiTestFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace GenerationApiTestFinal.Context
{
    public class MeuDbContext:DbContext
    {
        public MeuDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Professor> Professores {  get; set; }
        public DbSet <Sala> Salas { get; set; }

    }
}
