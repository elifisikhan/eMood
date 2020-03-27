using Data.Concrete.EntityFramework;
using Data.Repository.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework
{
    public class EntityEmotionRepo : EfGenericRepository<Emotion>, IEmotionRepo
    {

        public EntityEmotionRepo(eMoodContext context):base(context)
        {
        }
        public eMoodContext eMoodContext
        {
            get { return context as eMoodContext; }
        }

        //public IEnumerable<EmotionModel> GetAllWithActivityCount()
        //{
        //    return GetAll().Select(i => new EmotionModel()
        //    {
        //        EmotionID = i.EmotionId,
        //        CategoryName = i.EmotionName,
        //        Count = i.ActivityEmotions.Count()
        //    });
        //}

        public Emotion GetByName(string name)
        {
            return eMoodContext.Emotions
                .Where(i => i.EmotionName == name).FirstOrDefault();
        }
    }
}
