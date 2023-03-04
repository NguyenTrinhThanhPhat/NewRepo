using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public object User { get; private set; }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (!_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
            {
                var attendance = new Attendance
                {
                    CourseId = attendanceDto.CourseId,
                    AttendeeId = User.Identity.GetUserId()
                };

                _dbContext.Attendances.Add(attendance);
                _dbContext.SaveChanges();
                return Ok();
            }

            return BadRequestResult("The Attendance already exists!");
        }

        private IHttpActionResult BadRequestResult(string v)
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult Ok()
        {
            throw new NotImplementedException();
        }
    }
}
