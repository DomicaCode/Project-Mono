using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    class ProjectDbContext : DbContext
    {
        public DbSet<VehicleMakeEntity> VehicleMake { get; set; }
        public DbSet<VehicleModelEntity> VehicleModel { get; set; }

        public ProjectDbContext()
        {
             
        }

        //Virtualna metoda da ignoriramo specificne entitije iz contexta
        public virtual void IgnoreEntities(ModelBuilder modelBuilder)
        {
            //Ne ignoriramo nista po defaultu
        }

        //Virtualna metoda da handlamo excepcije
        public virtual void SaveException(Exception ex)
        {
            throw ex;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySQL("Server=localhost;Database=mono;Uid=root;Pwd=domica;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
