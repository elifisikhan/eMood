using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete.EntityFramework;
using e_Mood.Models;
using Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace e_Mood.Controllers
{
    public class CameraController : Controller
    {
        //private readonly DatabaseContext _context;
        private  eMoodContext _context;
        public IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;
        public CameraController(IHostingEnvironment hostingEnvironment, eMoodContext context, IConfiguration configuration)
        {
            _environment = hostingEnvironment;
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public IActionResult Capture()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Capture(string name)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            // Getting Filename
                            var fileName = file.FileName;
                            // Unique filename "Guid"
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                            // Getting Extension
                            var fileExtension = Path.GetExtension(fileName);
                            // Concating filename + fileExtension (unique filename)
                            var newFileName = string.Concat(myUniqueFileName, fileExtension);
                            var filepathShort = string.Concat(myUniqueFileName, fileExtension);


                            //  Generating Path to store photo 
                            var filepath = Path.Combine(_environment.WebRootPath, "CameraPhotos") + $@"\{newFileName}";
                            var filepath1 = newFileName;

                            if (!string.IsNullOrEmpty(filepath))
                            {
                                // Storing Image in Folder
                                StoreInFolder(file, filepath);
                                
                            }

                            var imageBytes = System.IO.File.ReadAllBytes(filepath);
                            if (imageBytes != null)
                            {
                                // Storing Image in Folder
                                StoreInDatabase(imageBytes, filepath1);
                            }

                        }
                    }
                  //  C: \Users\isikh\Documents\GitHub\eMood\e - Mood\wwwroot\CameraPhotos\5b656c80 - b973 - 41a2 - a0e2 - 9716b6d723a3.jpg


                   

                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Saving captured image into Folder.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        private void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        /// <summary>
        /// Saving captured image into database.
        /// </summary>
        /// <param name="imageBytes"></param>
        public void StoreInDatabase(byte[] imageBytes, string filepath)
        {
            try
            {
                if (imageBytes != null && filepath !=null)
                {
                    string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    string imageUrl = string.Concat("data:image/jpg;base64,", base64String);

                    Entity.ImageStore imageStore = new Entity.ImageStore()
                    {
                        CreateDate = DateTime.Now,
                        ImageBase64String = imageUrl,
                        ImageId = 0,
                        ImagePathString = filepath
                    };

                    _context.ImageStore.Add(imageStore);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}