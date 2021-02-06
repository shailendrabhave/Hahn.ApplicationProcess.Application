using Hahn.ApplicationProcess.December2020.Data.DAO;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hahn.ApplicationProcess.December2020.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }
        public DbSet<Applicant> Applicants { get; set; }
    }
}
