using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASM.Models
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MonAn> MonAns { get; set; }

        public DbSet<Nguoidung> Nguoidungs { get; set; }

        public DbSet<Donhang> Donhangs { get; set; }

        public DbSet<Khachhang> Khachhangs { get; set; }

        public DbSet<DonhangChitiet> DonhangChitiets { get; set; }
    }
}
