using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceVisual.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
    }
}
