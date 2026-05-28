using Microsoft.EntityFrameworkCore;

namespace Buoi5.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Cuộc sống" },
                new Category { CategoryId = 2, CategoryName = "Lập trình" },
                new Category { CategoryId = 3, CategoryName = "Sức khỏe" }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book 
                { 
                    Id = 1, 
                    Title = "Cuộc Sống Rất Giống Cuộc Đời", 
                    Author = "Hải Dớ", 
                    Price = 61000, 
                    Description = "Cuộc sống rất giống cuộc đời...", 
                    Image = "cuoc-song.jpg", 
                    CategoryId = 1 
                },
                new Book 
                { 
                    Id = 2, 
                    Title = "Cho Tôi Xin Một Vé Đi Tuổi Thơ", 
                    Author = "Nguyễn Nhật Ánh", 
                    Price = 55000, 
                    Description = "Cho tôi xin một vé đi tuổi thơ...", 
                    Image = "ve-tuoi-tho.jpg", 
                    CategoryId = 1 
                },
                new Book 
                { 
                    Id = 3, 
                    Title = "Core Java: Fundamentals, Volume 1", 
                    Author = "Cay Horstmann", 
                    Price = 120000, 
                    Description = "Core Java Fundamentals...", 
                    Image = "java.jpg", 
                    CategoryId = 2 
                },
                new Book 
                { 
                    Id = 4, 
                    Title = "Lập trình C", 
                    Author = "TS. Lê Xuân Việt", 
                    Price = 85000, 
                    Description = "Lập trình C cơ bản...", 
                    Image = "lap-trinh-c.jpg", 
                    CategoryId = 2 
                }
            );
        }
    }
}
