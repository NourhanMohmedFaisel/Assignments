using Assignments.Helpers;
using Assignments.Models;
using Assignments.ModelView;
using Assignments.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Assignments.Controllers
{


    public class InstractorController : Controller
    {
        ICourseRepo CourseRepository;
        IRepository<Department> DepartmentRepository;
        IRepository<Instractor> InstractorRepository;
        public InstractorController(ICourseRepo courseRepository, IRepository<Department> departmentRepository, IRepository<Instractor> instractorRepository)
        {
            CourseRepository = courseRepository;
            DepartmentRepository = departmentRepository;
            InstractorRepository = instractorRepository;
        }
      //  ITIContext context = new ITIContext();
        public IActionResult ViewAllInstractor()
        {

            List<Instractor> InstractorList =InstractorRepository.GetAll();
                //context.Instractor
                //.ToList();
            return View("ViewAllInstractor", InstractorList);

          
        }

        public IActionResult ViewInstractorDetails(int id)
        {
            Instractor inst=InstractorRepository.GetByID(id)/*context.Instractor.FirstOrDefault(e => e.Id == id)*/;


            return View("ViewInstractorDetails",inst);
        }

        public IActionResult Add()
        {
            InstractorDetailsViewModel instructorDetailsViewModel = new InstractorDetailsViewModel();
            instructorDetailsViewModel.Courses =CourseRepository.GetAll() /*context.Course.ToList()*/;
            instructorDetailsViewModel.Departments =DepartmentRepository.GetAll()/*context.Department.ToList()*/;
            return View("Add",instructorDetailsViewModel);

        }
        [HttpPost]
        public ActionResult SaveAdd(InstractorDetailsViewModel instructor)
        {
             Instractor newinstructor = new Instractor();
            instructor.Image = DocumentSettings.UploadFile(instructor.Imag, "Images");
            if (instructor.Name != null)
            {
                newinstructor.Name = instructor.Name;
                newinstructor.Imag = instructor.Image;
                newinstructor.Salary = instructor.Salary;
                newinstructor.Address = instructor.Address;
                newinstructor.CourseID = instructor.CourseID;
                newinstructor.DepartmentID = instructor.DepartmentID;
                InstractorRepository.Add(newinstructor);
                InstractorRepository.Save();
                return RedirectToAction("ViewAllInstractor");
            }
            instructor.Courses = CourseRepository.GetAll() /*context.Course.ToList()*/;
            instructor.Departments = DepartmentRepository.GetAll() /*context.Department.ToList()*/;
            return View("Add", instructor);
        }

        public ActionResult GetCoursesByDepartmentID(int deptID)
        {

            List<Course> courses =CourseRepository.GetCoursesByDepartmentID(deptID) ;
           
            return Json(courses);
          
        }
    }
}
