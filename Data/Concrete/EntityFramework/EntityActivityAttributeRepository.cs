using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EntityFramework
{
   public class EntityActivityAttributeRepository :EfGenericRepository<ActivityAttribute>, IActivityAttributeRepo
    {
        public EntityActivityAttributeRepository(eMoodContext context) : base(context)
        {
        }
        public eMoodContext eMoodContext
        {
            get { return context as eMoodContext; }
        }
    }
}
