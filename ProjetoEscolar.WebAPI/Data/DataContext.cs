using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetoEscolar.WebAPI.Models;

namespace ProjetoEscolar.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
                .HasData(
                    new List<Professor>(){
                        new Professor(){
                            Id = 1,
                            Name = "Nilson"        
                        },
                        new Professor(){
                            Id = 2,
                            Name = "Alexandre"        
                        },
                        new Professor(){
                            Id = 3,
                            Name = "Bianca"        
                        }
                    }
                );

            builder.Entity<Student>()
                .HasData(
                    new List<Student>(){
                        new Student(){
                            Id = 1,
                            Name = "Maria",
                            Lastname = "Lima",
                            DateBirth = "13/02/2000",
                            ProfessorId = 1        
                        },
                        new Student(){
                            Id = 2,
                            Name = "Diogo",
                            Lastname = "Pereira",
                            DateBirth = "13/02/2005",
                            ProfessorId = 1        
                        },
                        new Student(){
                            Id = 3,
                            Name = "Lucas",
                            Lastname = "Xavier",
                            DateBirth = "13/02/1998",
                            ProfessorId = 1        
                        }
                    }
                );
        }
    }
}