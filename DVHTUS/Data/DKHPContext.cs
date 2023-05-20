using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DVHTUS.Models;

namespace DVHTUS.Data
{
    public class DKHPContext : DbContext
    {
        public DKHPContext (DbContextOptions<DKHPContext> options)
            : base(options)
        {
        }

        public DbSet<DVHTUS.Models.SinhVien> SinhVien { get; set; } = default!;

        public DbSet<DVHTUS.Models.LopHP> LopHP { get; set; } = default!;

        public DbSet<DVHTUS.Models.DangKyHocPhan> DangKyHocPhan { get; set; } = default!;
    }
}
