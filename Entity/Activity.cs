using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        
        public IList<ActivityAttribute> ActivityAttributes { get; set; }
     //   public ICollection<Emotion> Emotions { get; } = new List<Emotion>();
        public ICollection<ActivityEmotion> ActivityEmotions { get; } = new List<ActivityEmotion>();
    }
}
