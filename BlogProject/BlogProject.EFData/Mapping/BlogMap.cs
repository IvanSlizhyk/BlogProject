using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core.Entities;

namespace BlogProject.EFData.Mapping
{
    internal class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            HasKey(e => e.Id);
            Property(e => e.UserId).IsRequired();
            Property(e => e.Title).IsRequired().HasMaxLength(300);
            Property(e => e.Body).IsRequired().HasMaxLength(2000);
            Property(e => e.CreateDate).IsRequired();
            HasMany(e => e.Comments).WithRequired(e => e.Blog).HasForeignKey(e => e.BlogId);
        }
    }
}
