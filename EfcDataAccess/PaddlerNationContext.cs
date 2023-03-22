using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class PaddlerNationContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PaddleBoard> PaddleBoards { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Extra> Extras { get; set; }
    public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
    public DbSet<ExtrasOrder> ExtrasOrders  { get; set; }
    public DbSet<PaddleBoardReservation> PaddleBoardReservations { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = PaddlerNationDatabase.db");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Assigning Keys
        
        // ExtrasOrder foreign  keys
        modelBuilder.Entity<ExtrasOrder>()
            .HasKey(eo => new {eo.ExtrasID, eo.OrderID});
        
        // PaddleBoardReservation foreign  keys
        modelBuilder.Entity<PaddleBoardReservation>()
            .HasKey(pbr => new {pbr.ReservationID, pbr.PadleBoardID});

            // --- --- ---   --- --- ---   --- --- ---
        
        // RELATIONS v
        
        // Order --many--> Reservations
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.OrderedIn)
            .WithMany(o=> o.Reservations);

        // Order --one--> Customer
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Ordered)
            .WithOne(o => o.Customer)
            .HasForeignKey<Order>(o => o.CustomerID);

        // Order --one--> DeliveryAddress
        modelBuilder.Entity<DeliveryAddress>()
            .HasOne(da => da.Order)
            .WithOne(o => o.DeliveryAddress)
            .HasForeignKey<Order>(o => o.DeliveryAddressID);

        // Order <--many--> Extras
        modelBuilder.Entity<ExtrasOrder>()
            .HasOne(eo => eo.Extra)
            .WithMany(e => e.ExtrasOrders)
            .HasForeignKey(eo => eo.ExtrasID);
        modelBuilder.Entity<ExtrasOrder>()
            .HasOne(eo => eo.Order)
            .WithMany(o => o.ExtrasOrders)
            .HasForeignKey(eo => eo.OrderID);
        
        // Reservation <--many--> PaddleBoards
        modelBuilder.Entity<PaddleBoardReservation>()
            .HasOne(pbr => pbr.Reservation)
            .WithMany(r => r.PaddleBoardReservations)
            .HasForeignKey(pbr => pbr.ReservationID);
        modelBuilder.Entity<PaddleBoardReservation>()
            .HasOne(pbr => pbr.PaddleBoard)
            .WithMany(pb => pb.PaddleBoardReservations)
            .HasForeignKey(pbr => pbr.PadleBoardID);
        
        // --- --- ---   --- --- ---   --- --- ---
        
        // Enum Conversion v
        
        //PaddleBoardType enum conversion
        modelBuilder.Entity<PaddleBoard>()
            .Property(e => e.PaddleBoardType)
            .HasConversion(v => v.ToString(),
                v => (PaddleBoardType) Enum.Parse(typeof(PaddleBoardType), v));
        
        //PaymentMethod enum conversion
        modelBuilder.Entity<Order>()
            .Property(e => e.PaymentMethod)
            .HasConversion(v => v.ToString(),
                v => (PaymentMethod) Enum.Parse(typeof(PaymentMethod), v));
        
        //PaymentStage enum conversion
        modelBuilder.Entity<Order>()
            .Property(e => e.PaymentStage)
            .HasConversion(v => v.ToString(),
                v => (PaymentStage) Enum.Parse(typeof(PaymentStage), v));
    }
}