using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.Abstract
{
    public interface Iuow:IDisposable
    {
        IActivityRepo Activities { get; }
        IEmotionRepo Emotions { get; }

        int SaveChanges();
    }
}
