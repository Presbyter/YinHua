
using Microsoft.EntityFrameworkCore;

namespace YinHua.Data
{
    public class YinHuaContext : DbContext
    {
        public YinHuaContext() : base()
        {

        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./YinHua.db");
        }
    }
}
