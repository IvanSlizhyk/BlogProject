using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core;
using BlogProject.Core.Entities;

namespace BlogProject.EFData.Mapping
{
    internal class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            HasKey(e => e.Id);
            Property(e => e.UserId).IsRequired();
            HasRequired(e => e.Blog).WithMany(e => e.Comments).HasForeignKey(e => e.BlogId);
            Property(e => e.Text).IsRequired().HasMaxLength(2000);
            Property(e => e.CreateDate).IsRequired();
            HasMany(e => e.Points).WithRequired(e => e.Comment).HasForeignKey(e => e.CommentId);
        }
    }
}
