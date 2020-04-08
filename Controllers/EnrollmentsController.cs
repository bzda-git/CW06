using Cw6.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Services;

namespace Cw6.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {


        private IDbService _service;

        public EnrollmentsController(IDbService service)
        {
            _service = service;

        }

        [HttpPost]
       // public IActionResult EnrollStudent(EnrollStudentRequest request)
    //    {

        //    var response = _service.EnrollStudent(request);
       //     return Ok(response);


     //   }

        [HttpPost("promotions")]
        public IActionResult PromoteStudents(PromotionRequest promotionRequest)
        {

            var response = _service.PromoteStudents(promotionRequest);
            return Ok(response);
        }
    }
    
}
