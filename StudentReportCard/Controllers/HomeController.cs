using StudentReportCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentReportCard.ViewModel;

namespace StudentReportCard.Controllers
{
    public class HomeController : Controller
    {
        private StudentDBEntities objStudentDBEntities;
        public HomeController()
        {
            objStudentDBEntities = new StudentDBEntities();
        }
        public ActionResult Index()
        {
            StudentMasterViewModel objStudentMasterViewModel = new StudentMasterViewModel();
            objStudentMasterViewModel.ListOfExams = (from obj in objStudentDBEntities.Exams
                                                     select new SelectListItem()
                                                     {
                                                         Text = obj.ExamName,
                                                         Value = obj.ExamId.ToString()
                                                     }).ToList();

            objStudentMasterViewModel.ListOfSubjects = (from obj in objStudentDBEntities.Subjects
                                                        select new SelectListItem()
                                                        {
                                                            Text = obj.SubjectName,
                                                            Value = obj.SubjectId.ToString()
                                                        }).ToList();

            

            return View(objStudentMasterViewModel);
        }

        [HttpPost]
        public ActionResult Index(StudentViewModel objStudentViewModel)
        {
            StudentMaster objStudentMaster = new StudentMaster()
            {
                Name = objStudentViewModel.Name,
                ClassName = objStudentViewModel.ClassName,
                ExamId = objStudentViewModel.ExamId,
                RollNumber = objStudentViewModel.RollNumber
            };
            objStudentDBEntities.StudentMasters.Add(objStudentMaster);
            objStudentDBEntities.SaveChanges();

            foreach (var item in objStudentViewModel.ListOfStudentMarks)
            {
                StudentDetail objStudentDetail = new StudentDetail()
                {
                    StudentId = objStudentMaster.StudentId,
                    SubjectId = item.SubjectId,
                    TotalMarks = item.TotalMarks,
                    MarksObtained = item.MarksObtained,
                    Percentage = item.Percentage
                };
                objStudentDBEntities.StudentDetails.Add(objStudentDetail);
                objStudentDBEntities.SaveChanges();
            }

            return Json( new { message= "Data Successfully Added.", status=true } , JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetStudentMarks(int studentId)
        {
            List<StudentMarksModel> listStudentMarksModels = (from objStu in objStudentDBEntities.StudentDetails
                                                              join objSub in objStudentDBEntities.Subjects on objStu.SubjectId equals objSub.SubjectId
                                                              where objStu.StudentId == studentId
                                                              select new StudentMarksModel()
                                                              {
                                                                  StudentId = studentId,
                                                                  SubjectName = objSub.SubjectName,
                                                                  MarksObtained = objStu.MarksObtained,
                                                                  TotalMarks = objStu.TotalMarks,
                                                                  Percentage = objStu.Percentage
                                                              }).ToList();

            return PartialView("_StudentMarksPartial", listStudentMarksModels);
        }

        public JsonResult LoadStudent()
        {
            List<StudentModel> listOfStudentModel = (from objStu in objStudentDBEntities.StudentMasters
                                                     join objExam in objStudentDBEntities.Exams on objStu.ExamId equals objExam.ExamId
                                                     select new StudentModel()
                                                     {
                                                         Name = objStu.Name,
                                                         ClassName = objStu.ClassName,
                                                         RollNumber = objStu.RollNumber,
                                                         StudentId = objStu.StudentId,
                                                         ExamName = objExam.ExamName,
                                                     }).ToList();

            return Json(listOfStudentModel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}