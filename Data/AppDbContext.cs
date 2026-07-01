using Microsoft.EntityFrameworkCore;
using ELearning.Api.Models;
using eLearning.Api.Models;

namespace ELearning.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}