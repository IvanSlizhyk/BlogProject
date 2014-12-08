using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core.Entities;

namespace BlogProject.EFData.Mapping
{
    internal class PointMap : EntityTypeConfiguration<Point>
    {
        public PointMap()
        {
            HasKey(e => e.Id);
            HasRequired(e => e.Comment).WithMany(e => e.Points).HasForeignKey(e => e.CommentId);
            Property(e => e.CreateDate).IsRequired();
            Property(e => e.UserId).IsRequired();
        }
    }
}
