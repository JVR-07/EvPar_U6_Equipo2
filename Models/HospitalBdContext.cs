using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using EvPar_U6_Equipo2.Models;

namespace EvPar_U6_Equipo2.Models;

public partial class HospitalBdContext : DbContext
{
    public HospitalBdContext()
    {
    }

    public HospitalBdContext(DbContextOptions<HospitalBdContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<EvPar_U6_Equipo2.Models.EmergencyContactPerson> EmergencyContactPerson { get; set; } = default!;
}
