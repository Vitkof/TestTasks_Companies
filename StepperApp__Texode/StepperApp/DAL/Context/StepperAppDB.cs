using Microsoft.EntityFrameworkCore;

namespace StepperApp.DAL.Context
{
    public class StepperAppDB
    {
        public DbSet<User> Users { get; set; }
    }
}
