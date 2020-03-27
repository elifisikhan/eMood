
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.Abstract
{
    public interface IActivityRepo:IGenericRepo<Activity>
    {
        List<Activity> GetTop5Activities();
    }
}
