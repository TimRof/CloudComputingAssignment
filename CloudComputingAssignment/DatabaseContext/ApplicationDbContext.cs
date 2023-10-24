using Microsoft.EntityFrameworkCore;

namespace Repository.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base()
        {
        }
    }
}