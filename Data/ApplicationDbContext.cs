using AAO_App.Models;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace AAO_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LicenseType> LicenseTypes { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<RequestedStatus> RequestedStatus { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        //public DbSet<DriversLicenseRecord> DriversLicenseRecords { get; set; }
    }

}
