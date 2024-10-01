using Microsoft.EntityFrameworkCore;

namespace Form_test.Model
{
    public class RegisterPatientContext : DbContext
    {
        public RegisterPatientContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<RegisterPatient> RegisterPatient { get; set;}
    }
}
