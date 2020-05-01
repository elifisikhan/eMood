using Data.Abstract;
using Data.Repository.Abstract;
using e_Mood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Mood.Components
{
    public class CollectiveMenu: ViewComponent
    {
        private IActivityRepo ActivityRepo;
        private IActivityAttributeRepo ActivityAttributeRepo;
        public CollectiveMenu(IActivityRepo _repo, IActivityAttributeRepo _repo2)
        {
            ActivityRepo = _repo;
            ActivityAttributeRepo = _repo2;
        }
        public IViewComponentResult Invoke()
        {
            
                var activities = ActivityRepo.GetAll();
                var attributes = ActivityAttributeRepo.GetAll();
                attributes = attributes
                    .Include(a => a.Emotion)
                    .Include(a => a.Activity)
                    .Where(i => i.EmotionID==1);
                return View(
                         new ActivityListModel()
                         {
                             Activities = activities,
                             ActivityAttributes = attributes
                         });
        }
    }
}
