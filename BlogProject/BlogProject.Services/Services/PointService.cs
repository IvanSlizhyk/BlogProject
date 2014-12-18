using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.BLInterfaces.BLLInterfaces;
using BlogProject.BLInterfaces.Exceptions;
using BlogProject.Core.Entities;
using BlogProject.DALInterfaces;

namespace BlogProject.Services.Services
{
    public class PointService : BaseService, IPointService
    {
        public PointService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public Point CreatePoint(DateTime createDate, int userId)
        {
            var pointRepository = RepositoryFactory.GetPointRepository();
            var point = new Point { CreateDate = createDate, UserId = userId };
            pointRepository.Create(point);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (PointServiceException ex)
            {
                throw new PointServiceException(ex);
            }

            return point;
        }

        public void UpdatePoint(Point point)
        {
            var pointRepository = RepositoryFactory.GetPointRepository();

            try
            {
                pointRepository.Update(point);
            }
            catch (PointServiceException ex)
            {
                throw new PointServiceException(ex);
            }
        }

        public void RemovePoint(Point point)
        {
            var pointRepository = RepositoryFactory.GetPointRepository();

            try
            {
                pointRepository.Remove(point);
            }
            catch (PointServiceException ex)
            {
                throw new PointServiceException(ex);
            }
        }

        public Point GetPointById(int pointId)
        {
            var pointRepository = RepositoryFactory.GetPointRepository();

            try
            {
                var point = pointRepository.GetEntiyById(pointId);
                return point;
            }
            catch (PointServiceException ex)
            {
                throw new PointServiceException(ex);
            }
        }

        public IQueryable<Point> GetAllPoints()
        {
            var pointRepository = RepositoryFactory.GetPointRepository();

            try
            {
                var point = pointRepository.All();
                return point;
            }
            catch (PointServiceException ex)
            {
                throw new PointServiceException(ex);
            }
        }

        public void SetCommentOfPoint(Comment comment, Point point)
        {
            point.Comment = comment;
            point.CommentId = comment.Id;
        }
    }
}
