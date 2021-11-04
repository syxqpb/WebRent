using WebTest2ebt.DataAccessLayer.Models;
using WebTest2ebt.DataAccessLayer.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Korzh.DbUtils;

namespace WebTest2ebt.DataAccessLayer.Context
{
    public class PhotoRentContext : IdentityDbContext<IdentityBuyer>
    {
        public PhotoRentContext(DbContextOptions<PhotoRentContext> options) : base(options)
        {
            Database.EnsureCreated();
            //Database.Migrate();
            //DbInitializer.Create(dbUtilsOptions =>
            //{
            //    dbUtilsOptions.UseSqlServer(Database.GetDbConnection().ConnectionString);
            //    dbUtilsOptions.UseFileFolderPacker(configuration.GetSection("SeedFolder").Value);
            //})
            //             .Seed();
        }

        public DbSet<BatteryDto> Batteries { get; set; }
        public DbSet<CameraDto> Cameras { get; set; }
        public DbSet<CartDto> Carts { get; set; }
        public DbSet<EquipmentDto> Equipments  { get; set; }
        public DbSet<EquipmentPhotoDto> EquipmentPhotos { get; set; }
        public DbSet<FeedbackDto> Feedbacks { get; set; }
        public DbSet<FlashBulbDto> FlashBulbs { get; set; }
        public DbSet<LensDto> Lens { get; set; }
        public DbSet<MasterDto> Masters { get; set; }
        public DbSet<MicrophoneDto> Microphones { get; set; }
        public DbSet<OrderMasterDto> OrderMasters { get; set; }
        public DbSet<PhotoAndVideoDto> PhotoAndVideos { get; set; }
        public DbSet<ServiceDto> Services { get; set; }
        public DbSet<StorageDto> Storages { get; set; }
        public DbSet<RentHistoryDto> RentHistories { get; set; }
        public DbSet<EquipmentLogDto> EquipmentLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<RentDto>().HasOne<IdentityBuyer>().WithMany().HasForeignKey(rent => rent.BuyerId).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<OrderMasterDto>().HasOne<MasterDto>().WithMany().HasForeignKey(order => order.MasterId).OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<PortfolioDto>().HasOne<MasterDto>().WithMany().HasForeignKey(portfolio => portfolio.MasterId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
