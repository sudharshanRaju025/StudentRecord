using Microsoft.EntityFrameworkCore;

namespace StudentRecord.Data
{
    public class ApllicationDbContext:DbContext
    {
        public void ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {

        }
        
    }
}
