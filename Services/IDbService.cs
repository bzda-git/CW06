using Cw6.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IDbService
    {
        public IActionResult EnrollStudent(Student request);
          public IActionResult PromoteStudents(PromotionRequest promotionRequest);

        public bool CheckIndex(string index)
        {
            return index == null ? false : true;
        }

       
    }
}
