using ApiPersonajesAWS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Data
{
    public class PersonajesContext : DbContext

    {

        public PersonajesContext(DbContextOptions<PersonajesContext>

            options) : base(options) { }

        public DbSet<Personaje> Personajes { get; set; }

    }
}
