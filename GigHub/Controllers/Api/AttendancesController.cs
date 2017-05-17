using System.Linq;
using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var currentUserId = User.Identity.GetUserId();


            if (_context.Attendances.Any(a => a.AttendeeId == currentUserId && a.GigId == dto.GigId))
            {
                return BadRequest("The attendance already exists.");
            }

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = currentUserId

            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
