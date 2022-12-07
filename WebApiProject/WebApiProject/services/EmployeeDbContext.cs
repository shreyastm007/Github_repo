using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.model;

namespace WebApiProject.services
{

    public class EmployeeDbContext : DbContext
    {

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) {

        }
        //only one type is present in our project as of now
        public DbSet<Employee> employee { get; set; }

    }
}