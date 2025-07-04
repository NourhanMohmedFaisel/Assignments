using Assignments.Models;
using Assignments.ModelView;
using Assignments.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Assignments.Controllers
{
    public class CourseController : Controller
    {
        // ITIContext context = new ITIContext();
       // IRepository<Course> CourseRepository;
        IRepository<Department> DepartmentRepository;
        ICourseRepo CourseRepository;

        public CourseController(/*IRepository<Course>*/ICourseRepo courseRepository, IRepository<Department> departmentRepository)
        {
            CourseRepository = courseRepository;
            DepartmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            //List<Course> CourseList =
            //  context.Course
            //  .ToList();
            List<Course> CourseList =
             CourseRepository.GetAll();
            return View("Index", CourseList);
        
        }
        public IActionResult Details(int id)
        {
            Course crs = CourseRepository.GetByID(id);

            return View("Details", crs);
        }

        public IActionResult Add()
        {
            CourseDetailsViewModel crsVM = new CourseDetailsViewModel();
            //crsVM.Insts = context.Instractor.ToList();
            crsVM.Departments = DepartmentRepository.GetAll() ;
            //crsVM.CrsResults = context.CrsResult.ToList();
            return View("Add", crsVM);

        }
        public ActionResult SaveAdd(CourseDetailsViewModel crsVM)
        {
            if (ModelState.IsValid == true)
            {
                Course crsDB = new Course();
                
                    crsDB.Name = crsVM.Name;
                    crsDB.Degree = crsVM.Degree;
                    crsDB.MinDegree = crsVM.MinDegree;
                    crsDB.Hours = crsVM.Hours;
                    crsDB.DepartmentID = crsVM.DepartmentID;
                try
                {
                   CourseRepository.Add(crsDB);
                   CourseRepository.Save();
                    return RedirectToAction("Index");
                }catch (Exception ex)
                {
                ModelState.AddModelError("DepartmentID", ex.InnerException.Message);
            }
        }
          //  crsVM.Insts = context.Instractor.ToList();
            crsVM.Departments =DepartmentRepository.GetAll();
            //crsVM.CrsResults = context.CrsResult.ToList();
            return View("Add", crsVM);
        }

        public IActionResult CheckDegree(int MinDegree, int Degree)
        {
            if (MinDegree<Degree)
                return Json(true);
           
            else
                return Json(false);
        }

        public IActionResult CheckHours(int Hours)
        {
            if (Hours%3==0)
                return Json(true);

            else
                return Json(false);
        }


    }
}
