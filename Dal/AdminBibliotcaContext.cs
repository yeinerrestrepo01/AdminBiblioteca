using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class AdminBibliotecaContext : DbContext
    {
        public AdminBibliotecaContext() { }

        public AdminBibliotecaContext(DbContextOptions opciones) : base (opciones){ }

        public virtual DbSet<Autores> Autores { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
