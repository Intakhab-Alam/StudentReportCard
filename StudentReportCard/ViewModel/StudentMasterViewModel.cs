using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StudentReportCard.ViewModel
{
    public class StudentMasterViewModel
    {
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Display(Name = "Roll Number")]
        public int RollNumber { get; set; }

        [Display(Name = "Exam")]
        public int ExamId { get; set; }

        [Display(Name = "Subject")]
        public int SubjectId { get; set; }
    
        public IEnumerable<SelectListItem> ListOfExams { get; set; }
        public IEnumerable<SelectListItem> ListOfSubjects { get; set; }

        [Display(Name = "Marks Obtained")]
        public decimal MarksObtained { get; set; }

        [Display(Name = "Total Marks")]
        public decimal TotalMarks { get; set; }

        [Display(Name = "Percentage")]
        public decimal Percentage { get; set; }
        public List<StudentModel> ListOfStudentModels { get; set; }
    }
}