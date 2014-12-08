using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core.Entities;

namespace BlogProject.BLInterfaces.BLLInterfaces
{
    public interface IPointService : IService
    {
        Point CreatePoint(DateTime createDate, Guid userId);
        void UpdatePoint(Point point);
        void RemovePoint(Point point);
        Point GetPointById(int pointId);
        IQueryable<Point> GetAllPoints();
        void SetCommentOfPoint(Comment comment, Point point);
    }
}
