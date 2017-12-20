using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkSmartSchools.Models.Common
{
    public class UploadResultViewModel
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public decimal FirstCa { get; set; }
        public decimal SecondCa { get; set; }
        public decimal ThirdCa { get; set; }
        public decimal FourthCa { get; set; }
        public decimal FifthCa { get; set; }
        public decimal ClassExercise1 { get; set; }
        public decimal ClassExercise2 { get; set; }
        public decimal ClassExercise3 { get; set; }
        public decimal ClassExercise4 { get; set; }
        public decimal ClassExercise5 { get; set; }
        public decimal Assignment1 { get; set; }
        public decimal Assignment2 { get; set; }
        public decimal Assignment3 { get; set; }
        public decimal Assignment4 { get; set; }
        public decimal Assignment5 { get; set; }
        public decimal Exam { get; set; }
    }

    public class UploadResult
    {
        private readonly ForSchoolsDBContext _context;

        public IEnumerable<CaResult> CA { get; set; }

        public IEnumerable<CeResult> CE { get; set; }

        public IEnumerable<AssignmentResult> AssResult { get; set; }

        public IEnumerable<Exam> Exam { get; set; }

        public IEnumerable<SCSt> SCST { get; set; }

        public List<string> Columns { get; set; }

        public List<UploadResultViewModel> URVM { get; set; }

        //For Current SessionTerm
        public UploadResult(ForSchoolsDBContext context, int classID, int institutionID)
        {
            _context = context;
            //int sessionID = db.Sessions.FirstOrDefault(u => u.Status == true).ID;
            //int termID = db.Terms.FirstOrDefault(d => d.Status == true && d.InstitutionID == institutionID).ID;
            //SessionAndTerm SAT = new SessionAndTerm();
            //int sessionTermID = db.SessionTerms.FirstOrDefault(v => v.SessionID == sessionID && v.TermID == termID && v.InstitutionID == institutionID).ID;
            var students = _context.Student.Where(w => w.ClassId == classID);
            URVM = new List<UploadResultViewModel>();
            Columns = new List<string> { "StudentId", "Name", "Exam" };
            foreach (var student in students)
            {
                UploadResultViewModel model = new UploadResultViewModel
                {
                    StudentId = String.Format("{0}/STUD/{1}", _context.Institution.Find(institutionID).ShortName, student.Id),
                    Name = student.LastName + student.FirstName + student.OtherNames
                };
                URVM.Add(model);
            }
            int ca = (_context.ResultType.FirstOrDefault(c => c.SchoolId == 1 && c.AssessmentTypeId == 1).NoOfItems) ?? 0;
            int ass = (_context.ResultType.FirstOrDefault(c => c.SchoolId == 1 && c.AssessmentTypeId == 2).NoOfItems) ?? 0;
            int ce = (_context.ResultType.FirstOrDefault(c => c.SchoolId == 1 && c.AssessmentTypeId == 3).NoOfItems) ?? 0;
            if (ca != 0 && ca < 6)
            {
                switch (ca)
                {
                    case 1: Columns.Add("FirstCa"); break;
                    case 2: Columns.AddRange(new List<string> { "FirstCa", "SecondCa" }); break;
                    case 3: Columns.AddRange(new List<string> { "FirstCa", "SecondCa", "ThirdCa" }); break;
                    case 4: Columns.AddRange(new List<string> { "FirstCa", "SecondCa", "ThirdCa", "FourthCa" }); break;
                    default: Columns.AddRange(new List<string> { "FirstCa", "SecondCa", "ThirdCa", "FourthCa", "FifthCa" }); break;
                }
            }
            if (ass != 0 && ass < 6)
            {
                switch (ass)
                {
                    case 1: Columns.Add("Assignment1"); break;
                    case 2: Columns.AddRange(new List<string> { "Assignment1", "Assignment2" }); break;
                    case 3: Columns.AddRange(new List<string> { "Assignment1", "Assignment2", "Assignment3" }); break;
                    case 4: Columns.AddRange(new List<string> { "Assignment1", "Assignment2", "Assignment3", "Assignment4" }); break;
                    default: Columns.AddRange(new List<string> { "Assignment1", "Assignment2", "Assignment3", "Assignment4", "Assignment5" }); break;
                }
            }
            if (ce != 0 && ce < 6)
            {
                switch (ce)
                {
                    case 1: Columns.Add("ClassExercise1"); break;
                    case 2: Columns.AddRange(new List<string> { "ClassExercise1", "ClassExercise2" }); break;
                    case 3: Columns.AddRange(new List<string> { "ClassExercise1", "ClassExercise2", "ClassExercise3" }); break;
                    case 4: Columns.AddRange(new List<string> { "ClassExercise1", "ClassExercise2", "ClassExercise3", "ClassExercise4" }); break;
                    default: Columns.AddRange(new List<string> { "ClassExercise1", "ClassExercise2", "ClassExercise3", "ClassExercise4", "ClassExercise5" }); break;
                }
            }
        }
    }
}
