using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UowAndRepository.Models;
using UowAndRepository.Repository;

namespace UowAndRepository.UnitOfWork
{
    public class UOW : IDisposable
    {
        private DataContext _context = new DataContext();
        private ProductRepository productRe;

        public ProductRepository ProductRepository
        {
            get
            {
                if (this.productRe == null)
                {
                    this.productRe=new ProductRepository(_context);
                }

                return productRe;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        //Hàm Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}