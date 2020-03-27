using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity
{
    public class Emotion
    {
        public int EmotionId { get; set; }
        public string EmotionName { get; set; }
        public IList<ActivityAttribute> ActivityAttributes { get; set; }
      //  public ICollection<Activity> Emotions { get; } = new List<Activity>();
        public ICollection<ActivityEmotion> ActivityEmotions { get; } = new List<ActivityEmotion>();


    }
}
