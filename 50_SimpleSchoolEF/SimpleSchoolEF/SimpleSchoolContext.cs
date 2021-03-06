using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleSchoolEF.Core;

namespace SimpleSchoolEF
{
    public class SimpleSchoolContext : DbContext
    {
        public DbSet<Building> Building { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<GradeItem> GradeItem { get; set; }
        public DbSet<GradeType> GradeType { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<SectionRoster> SectionRoster { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        public SimpleSchoolContext(DbContextOptions options) : base(options) 
        {
        
        }

        public static SimpleSchoolContext GetDBContext()
        {
            var options = new DbContextOptionsBuilder<SimpleSchoolContext>()
                .UseSqlServer("Server=localhost;Database=SimpleSchool;User Id=sa;Password=YOUR_strong_*pass4w0rd*")
                .Options;
            return new SimpleSchoolContext(options);
        }
    }
}
