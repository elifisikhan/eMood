using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace e_Mood.Controllers
{
    public class ParallelDotsController : Controller
    {
        public IConfiguration _configuration;

        public ParallelDotsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public IActionResult Index()
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            string path = "a67b0bf8-9fba-4af1-98eb-7d5703e612dd.jpg";
            using (SqlConnection connection = new SqlConnection(myDb1ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM ImageStore ORDER BY CreateDate DESC ", connection);
                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    path =(read["ImagePathString"]).ToString();
                }
                read.Close();
            }
            return View((object)path);
        }
    }
}