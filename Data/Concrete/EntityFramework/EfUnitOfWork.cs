using Data.Concrete.EntityFramework;
using Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework
{
    public class EfUnitOfWork : Iuow
    {
        private readonly eMoodContext dbContext;
        public EfUnitOfWork(eMoodContext _dbContext)
        {
            dbContext = _dbContext?? throw new ArgumentNullException("dbcontext cannot be null");
        }
        private IActivityRepo _activities;
        private IEmotionRepo _emotions;
        public IActivityRepo Activities
        {
            get
            {
                return _activities ?? (_activities = new EntityActivityRepo(dbContext));
            }
        }
        public IEmotionRepo Emotions
        {
            get
            {
                return _emotions ?? (_emotions = new EntityEmotionRepo(dbContext));
            }
        }
        public int SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void Dispose()
        {
            dbContext.Dispose();
        }

        
    }
}
