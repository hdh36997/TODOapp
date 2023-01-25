using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TODO_App.Models;

namespace TODO_App
{
    public class DbTaskContext : IdentityDbContext<UserModel>
    {
        public DbTaskContext(DbContextOptions<DbTaskContext> options) : base(options) { }
        public DbSet<TaskModel> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
