using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pks5_core;

public partial class Pks5Context : DbContext
{
    public Pks5Context()
    {
    }

    public Pks5Context(DbContextOptions<Pks5Context> options) : base(options)
    {
    }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Prepod> Prepods { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Olimps> Olimp { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Marks_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mark1).HasColumnName("mark");
            entity.Property(e => e.Subject).HasColumnName("subject");
			entity.Property(e => e.Semester).HasColumnName("semester");
		});

        modelBuilder.Entity<Prepod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prepods_pkey");

            entity.ToTable("prepods");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cafedra).HasColumnName("cafedra");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.SecondName).HasColumnName("second_name");
            entity.Property(e => e.Subject).HasColumnName("subject");
            entity.Property(e => e.ThirdName).HasColumnName("third_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
        });
		modelBuilder.Entity<Olimps>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Users_pkey");
			entity.ToTable("olimps");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Vid).HasColumnName("vid");
			entity.Property(e => e.Opis).HasColumnName("opis");
			entity.Property(e => e.Date).HasColumnName("date");
		});

		OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
