using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVVM_Project.Models;
using MVVM_Project.DBContext;
namespace MVVM_Project.Service
{
    public class UnitOfWork: IDisposable
    {
        private MyShopDBContext context = new MyShopDBContext();
        private GenericRepository<Admin> adminRepository;
        private GenericRepository<Category> categoryRepository;

        public GenericRepository<Admin> AdminRepository
        {
            get
            {

                if (this.adminRepository == null)
                {
                    this.adminRepository = new GenericRepository<Admin>(context);
                }
                return adminRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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