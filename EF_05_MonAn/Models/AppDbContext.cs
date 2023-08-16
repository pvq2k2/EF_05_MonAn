using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05_MonAn.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<CongThuc> CongThuc { get; set; }
        public DbSet<LoaiMonAn> LoaiMonAn { get; set; }
        public DbSet<MonAn> MonAn { get; set; }
        public DbSet<NguyenLieu> NguyenLieu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-O1GKQUN; Database = EF_05_MonAn; Trusted_Connection = True; TrustServerCertificate = True");
        }
    }
}
