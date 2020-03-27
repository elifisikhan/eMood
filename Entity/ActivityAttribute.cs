
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class ActivityAttribute
    {
        public int ActivityAttributeID { get; set; }
        public string AttributeName { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public string Image { get; set; }

        public bool InInside { get; set; }

        public int? EmotionID { get; set; }
        public Emotion Emotion { get; set; }
        

        
        public int? ActivityID { get; set; }
        public Activity Activity { get; set; }

    }
}