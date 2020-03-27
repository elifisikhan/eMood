using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Repository.Abstract;
using e_Mood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_Mood.Controllers
{
    public class ActivityController : Controller
    {
        private IActivityRepo ActivityRepo;
        private IActivityAttributeRepo ActivityAttributeRepo;
        public ActivityController(IActivityRepo _repo, IActivityAttributeRepo _repo2)
        {
            ActivityRepo = _repo;
            ActivityAttributeRepo = _repo2;
        }
        public IActionResult List(string kind_of_emotion, bool inside)
        {
            if (inside == true && !string.IsNullOrEmpty(kind_of_emotion))
            {
                var activities = ActivityRepo.GetAll();
                var attributes = ActivityAttributeRepo.GetAll();
                attributes = attributes
                    .Include(a => a.Emotion)
                    .Include(a => a.Activity)
                    .Where(i => i.Emotion.EmotionName == kind_of_emotion && i.InInside == true);
                return View(
                         new ActivityListModel()
                         {
                             Activities = activities,
                             ActivityAttributes = attributes
                         });
            }
            else if (inside == false && !string.IsNullOrEmpty(kind_of_emotion))
            {
                var activities = ActivityRepo.GetAll();
                var attributes = ActivityAttributeRepo.GetAll();
                attributes = attributes
                    .Include(a => a.Emotion)
                    .Include(a => a.Activity)
                    .Where(i => i.Emotion.EmotionName == kind_of_emotion && i.InInside == false);
                return View(
                         new ActivityListModel()
                         {
                             Activities = activities,
                             ActivityAttributes = attributes
                         });
            }
            else
            {
                var activities = ActivityRepo.GetAll();
                return View(
                          new ActivityListModel()
                          {
                              Activities = activities
                          });
            }

        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}