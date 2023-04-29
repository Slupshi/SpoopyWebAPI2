﻿using Microsoft.EntityFrameworkCore;
using SpoopyWebAPI.Models;

namespace SpoopyWebAPI.Data;
public class SpoopyDbContext : DbContext
{

    public DbSet<SpoopyLogs> SpoopyLogs { get; set; }

    public SpoopyDbContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

}

