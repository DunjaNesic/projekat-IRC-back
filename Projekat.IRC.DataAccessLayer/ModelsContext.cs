using Microsoft.EntityFrameworkCore;
using Projekat.IRC.Models;
using System.Threading.Channels;

namespace Projekat.IRC.DataAccessLayer
{
    public class ModelsContext : DbContext
    {
        public ModelsContext(DbContextOptions<ModelsContext> options) : base(options) { }
        public DbSet<Zaposleni> Zaposleni { get; set; }
        public DbSet<Prostorija> Prostorija { get; set; }
        public DbSet<TipOpreme> TipOpreme { get; set; }
        public DbSet<Oprema> Oprema { get; set; }
        public DbSet<Zaduzenje> Zaduzenje { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {          
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zaposleni>(x => x.HasIndex(y => y.Email).IsUnique());

            modelBuilder.Entity<Zaduzenje>()
            .HasKey(zaduzenje => new { zaduzenje.DatumZaduzivanja, zaduzenje.ZaposleniID, zaduzenje.SerijskiBrojOpreme });

            modelBuilder.Entity<Zaduzenje>()
                .HasOne(zaduzenje => zaduzenje.Oprema)
                .WithMany(oprema => oprema.Zaduzenja)
                .HasForeignKey(zaduzenje => zaduzenje.SerijskiBrojOpreme)
                .IsRequired();

            modelBuilder.Entity<Oprema>(
               x => {
                   x.Property(
                       y => y.Status)
                   .HasConversion(
                       y => y.ToString(),
                       y => Enum.Parse<Status>(y)
                       );
               }
               );

            modelBuilder.Entity<Oprema>(
               x => {
                   x.Property(
                       y => y.RowVersion
                       ).IsRowVersion();
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}