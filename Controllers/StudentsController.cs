using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService; 
        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student>()
            {
                new Student{IndexNumber=1, FirstName="Jan", LastName="Kowalski"},
                new Student{IndexNumber=2, FirstName="Andrzej", LastName="Malewicz"},
                new Student{IndexNumber=3, FirstName="Krzysztof", LastName="Andrzejewicz"}
            };

            

            return Ok(list);
        }



    }
}