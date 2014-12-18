using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core.Entities;

namespace BlogProject.EFData.Mapping
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            HasKey(e => e.Id);
            Property(e => e.Title).IsRequired().HasMaxLength(200);
            Property(e => e.Body).IsRequired().HasMaxLength(2000);
            Property(e => e.CreateDate).IsRequired();
            Property(e => e.UserId).IsRequired();
        }
    }
}
