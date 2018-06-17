using Microsoft.EntityFrameworkCore;
using System.Linq;
using TechCafe.Repository.Entities;

namespace TechCafe.Repository
{
    public static class TechCafeDbInitializer
    {
        public static void Initialize(TechCafeDbContext context)
        {
            // Apply all pending migrations
            context.Database.Migrate();
        }
    }
}
