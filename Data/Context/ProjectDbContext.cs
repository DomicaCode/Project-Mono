using AutoMapper;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class ProjectDbContext : DbContext
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

            //Mapanje entitija i baze MAKE
            modelBuilder.Entity<VehicleMakeEntity>().ToTable("vehiclemake");
            modelBuilder.Entity<VehicleMakeEntity>().HasKey(p => p.Id).HasName("Id");
            modelBuilder.Entity<VehicleMakeEntity>().Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();
            modelBuilder.Entity<VehicleMakeEntity>().Property(p => p.Name).HasColumnName("Name").HasColumnType("varchar(255)").HasDefaultValueSql("''").IsRequired();
            modelBuilder.Entity<VehicleMakeEntity>().Property(p => p.Abrv).HasColumnName("Abrv").HasColumnType("varchar(255)").HasDefaultValueSql("''").IsRequired();

            //Mapanje entitija i baze MODEL
            modelBuilder.Entity<VehicleModelEntity>().ToTable("vehiclemodel");
            modelBuilder.Entity<VehicleModelEntity>().HasKey(p => p.Id).HasName("Id");
            modelBuilder.Entity<VehicleModelEntity>().Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();
            modelBuilder.Entity<VehicleModelEntity>().Property(p => p.Name).HasColumnName("Name").HasColumnType("varchar(255)").HasDefaultValueSql("''").IsRequired();
            modelBuilder.Entity<VehicleModelEntity>().Property(p => p.Abrv).HasColumnName("Abrv").HasColumnType("varchar(255)").HasDefaultValueSql("''").IsRequired();
            modelBuilder.Entity<VehicleModelEntity>().HasOne(m => m.Make).WithMany(n => n.Models).HasForeignKey(m => m.MakeId).HasConstraintName("fk_property");

        }
    }
}
