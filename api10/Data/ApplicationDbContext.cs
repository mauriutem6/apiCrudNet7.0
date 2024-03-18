using Microsoft.EntityFrameworkCore;
using api10.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.ResponseCompression;


namespace api10.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        //la relacion que va a tener la clase con el nombre de la tabla sql
        public DbSet<Marca> marcas { get; set; }
        
    }
}

