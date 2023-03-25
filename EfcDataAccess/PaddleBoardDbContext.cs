﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;


public class PaddleBoardDbContext : DbContext
{
    
#pragma warning disable CS8618 // Disable nullable warning as they will never be null
    
    public DbSet<PaddleboardType> PaddleBoardTypes { get; set; }
    public DbSet<ReservationItem> ReservationItems { get; set; } 
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Order> Orders { get; set; }
    
#pragma warning restore CS8618

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // probably we will move this outside to some config 
        // also change it to postgresql
        optionsBuilder.UseSqlite("Data Source = paddleboards.db");
    }
}