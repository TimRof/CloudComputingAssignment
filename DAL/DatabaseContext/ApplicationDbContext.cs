using Microsoft.EntityFrameworkCore;

namespace DAL.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base()
        {
        }
    }
}