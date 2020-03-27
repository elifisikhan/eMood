using Data.Concrete.EntityFramework;
using Data.Repository.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework
{
    public class EntityActivityRepo : EfGenericRepository<Activity>, IActivityRepo
    {
        public EntityActivityRepo(eMoodContext context) : base(context)
        {
        }
        public eMoodContext eMoodContext
        {
            get { return context as eMoodContext; }
        }

        public List<Activity> GetTop5Activities()
        {
            return eMoodContext.Activities
                .OrderByDescending(i => i.ActivityId)
                .Take(5)
                .ToList();
        }
    }
}
