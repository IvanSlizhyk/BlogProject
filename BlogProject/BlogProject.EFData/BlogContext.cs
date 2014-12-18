using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core.Entities;
using BlogProject.EFData.Mapping;

namespace BlogProject.EFData
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public BlogContext(string connectionStringName)
            : base(connectionStringName)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new PointMap());
            modelBuilder.Configurations.Add(new BlogMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
