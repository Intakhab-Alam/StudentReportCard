using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentReportCard.ViewModel
{
    public class StudentMarksViewModel
    {
        public int SubjectId { get; set; }
        public decimal MarksObtained { get; set; }
        public decimal TotalMarks { get; set; }
        public decimal Percentage { get; set; }
    }
}