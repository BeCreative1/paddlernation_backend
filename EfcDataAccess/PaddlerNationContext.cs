using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class PaddlerNationContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PaddleBoard> PaddleBoards { get; set; }
    public DbSet<PaddleBoardType> PaddleBoardTypes { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Extra> Extras { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ExtrasOrder> ExtrasOrders  { get; set; }
    public DbSet<PaddleBoardReservation> PaddleBoardReservations { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/PaddlerNationDatabase.db");
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
        
        //Events --one--> Address
        //Address --many--> Events
        modelBuilder.Entity<Event>()
            .HasOne(e => e.HeldAt)
            .WithMany(a => a.Events)
            .HasForeignKey(e => e.HeldAtID);
        
        //Delivery --one--> Address
        //Address --many--> Delivery
        modelBuilder.Entity<Delivery>()
            .HasOne(d => d.At)
            .WithMany(a => a.Deliveries)
            .HasForeignKey(d => d.AtID);
        
        //Order --one--> Delivery
        //Delivery --many--> Order
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Delivery)
            .WithMany(d => d.Orders)
            .HasForeignKey(o => o.DeliveryID);
        
        //Order --one--> Customer
        //Customer --many--> Order
        modelBuilder.Entity<Order>()
            .HasOne(o => o.OrderedBy)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.OrderedByID);
        
        // Order <--many--> Extras
        modelBuilder.Entity<ExtrasOrder>()
            .HasOne(eo => eo.Extra)
            .WithMany(e => e.ExtrasOrders)
            .HasForeignKey(eo => eo.ExtrasID);
        modelBuilder.Entity<ExtrasOrder>()
            .HasOne(eo => eo.Order)
            .WithMany(o => o.ExtrasOrders)
            .HasForeignKey(eo => eo.OrderID);
        
        // Reservation --one--> Order
        // Order --many--> Reservations
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.OrderedIn)
            .WithMany(o=> o.Reservations);
        
        // Reservation <--many--> PaddleBoards
        modelBuilder.Entity<PaddleBoardReservation>()
            .HasOne(pbr => pbr.Reservation)
            .WithMany(r => r.PaddleBoardReservations)
            .HasForeignKey(pbr => pbr.ReservationID);
        modelBuilder.Entity<PaddleBoardReservation>()
            .HasOne(pbr => pbr.PaddleBoard)
            .WithMany(pb => pb.PaddleBoardReservations)
            .HasForeignKey(pbr => pbr.PadleBoardID);
        
        //PaddleBoard --one--> PaddleBoardType
        //PaddleBoardTyp --many--> PaddleBoard
        modelBuilder.Entity<PaddleBoard>()
            .HasOne(pb => pb.PaddleBoardType)
            .WithMany(pbt => pbt.PaddleBoards)
            .HasForeignKey(pb => pb.PaddleBoardTypeID);
        
        // --- --- ---   --- --- ---   --- --- ---
        
        // Enum Conversion v

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

        // DeliveryType enum conversion
        modelBuilder.Entity<Delivery>()
            .Property(d => d.DeliveryType)
            .HasConversion(v => v.ToString(),
                v => (DeliveryType) Enum.Parse(typeof(DeliveryType), v));
    }
}