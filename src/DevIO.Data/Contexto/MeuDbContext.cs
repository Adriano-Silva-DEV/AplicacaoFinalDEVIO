using DevIO.Bussines.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Contexto
{
   public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options)
             : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

           
        }

        public DbSet<Produto> Produtos {get; set;}

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }


     
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        

            //Permite setar 100 espaços varchar por padrao
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");
                

            //aplicando os mapings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
