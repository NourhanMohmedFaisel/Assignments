using Assignments.Models;
using Assignments.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Controllers
{
    public class TraineeController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult ShowResult(int id,int crsid)
        {
            TraineeCourseResultViewModel TResultVM= new TraineeCourseResultViewModel();
            
            CrsResult crsResult = context.CrsResult.Include(crs => crs.Trainee).Include(crs => crs.Course).FirstOrDefault(c=>c.CourseID==crsid&&c.TraineeID==id);
            if (crsResult == null )
                return NotFound();
            TResultVM.TraineeName=crsResult.Trainee.Name;
            TResultVM.CourseName=crsResult.Course.Name;
            TResultVM.TraineeDegree = crsResult.Degree;
            TResultVM.MinCourseDegree=crsResult.Course.MinDegree;
            if (crsResult.Degree < crsResult.Course.MinDegree)
            {
                TResultVM.Status = "Fail";
            }
            else {

                TResultVM.Status = "Pass";
            }
            if(TResultVM.Status == "Fail")
            {
                TResultVM.Color = "red";
            }
            else if (TResultVM.Status =="Pass")
            {
                TResultVM.Color = "green";
            }

            return View("ShowResult",TResultVM);
        }
    }
}
