using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context : DbContext
    {
      
      
        public DbSet<Category> Categories { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TytDeneme> tytDenemes { get; set; }
        public DbSet<AytDeneme> aytDenemes { get; set; }
        public DbSet<Exam> exams { get; set; }
        public DbSet<calendar> calendars { get; set; }
        public DbSet<AboutUs> aboutUs { get; set; }
       
        
      
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
     
   
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CourseFallow> courseFallows { get; set; }
        public DbSet<ExamQuestionFollow> ExamQuestionFollow { get; set; }
        public DbSet<Course> courses { get; set; }
   



    }
}
