using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core.Entities;
using BlogProject.DALInterfaces;

namespace BlogProject.EFData
{
    public class UnitOfWork : IUnitOfWork, IRepositoryFactory
    {
        private readonly BlogContext _context;
        private readonly DbContextTransaction _transaction;
        private bool _isTransactionActive;
        private bool _disposed;
        private IRepositoryGeneric<Post, int> _postRepository;
        private IRepositoryGeneric<Comment, int> _commentRepository;
        private IRepositoryGeneric<Point, int> _pointRepository;
        private IRepositoryGeneric<Blog, int> _blogRepository; 

        public UnitOfWork(BlogContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
            _isTransactionActive = true;
        }

        public void Commit()
        {
            try
            {
                if (_isTransactionActive && !_disposed)
                {
                    _context.SaveChanges();
                    _transaction.Commit();
                    _isTransactionActive = false;
                }
            }
            catch (Exception e)
            {
                _transaction.Rollback();
                _isTransactionActive = false;
                throw;
            }
        }

        public void Rollback()
        {
            if (_isTransactionActive && !_disposed)
            {
                _transaction.Rollback();
                _isTransactionActive = false;
            }
        }

        public void PreSave()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_isTransactionActive)
            {
                try
                {
                    _context.SaveChanges();
                    _transaction.Commit();
                    _isTransactionActive = false;
                }
                catch (Exception e)
                {
                    _transaction.Rollback();
                    _isTransactionActive = false;

                    _context.Dispose();
                    _disposed = true;
                    throw;
                }
            }
            if (_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }

        public IRepositoryGeneric<Post, int> GetPostRepository()
        {
            return _postRepository ?? (_postRepository = new RepositoryGeneric<Post, int>(_context));
        }

        public IRepositoryGeneric<Comment, int> GetCommentRepository()
        {
            return _commentRepository ?? (_commentRepository = new RepositoryGeneric<Comment, int>(_context));
        }

        public IRepositoryGeneric<Point, int> GetPointRepository()
        {
            return _pointRepository ?? (_pointRepository = new RepositoryGeneric<Point, int>(_context));
        }

        public IRepositoryGeneric<Blog, int> GetBlogRepository()
        {
            return _blogRepository ?? (_blogRepository = new RepositoryGeneric<Blog, int>(_context));
        }
    }
}
