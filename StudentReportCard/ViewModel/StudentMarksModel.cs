using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentReportCard.ViewModel
{
    public class StudentMarksModel
    {
        public int StudentId { get; set; }
        public string SubjectName { get; set; }
        public decimal MarksObtained { get; set; }
        public decimal TotalMarks { get; set; }
        public decimal Percentage { get; set; }
    }
}