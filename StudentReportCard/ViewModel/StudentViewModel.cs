using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentReportCard.ViewModel
{
    public class StudentViewModel
    {
        public string Name { get; set; }
        public int ExamId { get; set; }
        public string ClassName { get; set; }
        public int RollNumber { get; set; }
        public List<StudentMarksViewModel> ListOfStudentMarks { get; set; }
    }
}