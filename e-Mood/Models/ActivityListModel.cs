using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Mood.Models

{

    public class ActivityListModel
    {
        public IEnumerable<Activity> Activities { get; set; }
        public IEnumerable<ActivityAttribute> ActivityAttributes { get; set; }

    }
}
