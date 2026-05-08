using Microsoft.EntityFrameworkCore;
using QLCT_Backend.Models; // Đảm bảo namespace này khớp với thư mục Models của bạn

namespace QLCT_Backend.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Khai báo các bảng tương ứng với database
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nếu bạn muốn cấu hình thêm (ví dụ tên bảng cụ thể nếu không dùng Annotation)
            base.OnModelCreating(modelBuilder);
        }
    }
}