using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkSmartSchools.Models;

namespace ThinkSmartSchools.Models.Common
{
    public class TotalGrade
    {
        public decimal? Total { get; set; }
        public decimal? Average { get; set; }
        public int? NoOfSubjects { get; set; }
        public String Grade { get; set; }
        public int StudentId { get; set; }
    }

    public class ResultViewModel
    {
        private readonly ForSchoolsDBContext _context;
        public IEnumerable<CaResult> CAResult { get; set; }
        public IEnumerable<AffectiveResult> AffectiveResult { get; set; }

        public IEnumerable<AssignmentResult> AssignmentResult { get; set; }

        public IEnumerable<CeResult> CEResult { get; set; }

        public IEnumerable<PsycomotResult> PsycomotResult { get; set; }

        public IEnumerable<Exam> Exam { get; set; }

        public IEnumerable<SCSt> S_C_ST { get; set; }

        public IEnumerable<ResultType> ResultType { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public decimal? Avg { get; set; }

        public List<TotalGrade> TotalGrade { get; set; }

        public ResultViewModel(ForSchoolsDBContext context)
        {
            _context = context;
        }

        public ResultViewModel(ForSchoolsDBContext context, int ClassID, int SessionTermID)
        {
            _context = context;
            TotalGrade = new List<TotalGrade>();
            S_C_ST = _context.SCSt.Where(z => z.ClassId == ClassID && z.SessionTermId == SessionTermID);
            Students = _context.SCSt.Include(y => y.Student).Where(z => z.ClassId == ClassID && z.SessionTermId == SessionTermID).Select(p => p.Student);
            Exam = _context.Exam.Where(e => e.ClassId == ClassID && e.SessionTermId == SessionTermID);
            PsycomotResult = _context.PsycomotResult.Where(a => a.ClassId == ClassID && a.SessionTermId == SessionTermID);
            CEResult = _context.CeResult.Where(b => b.ClassId == ClassID && b.SessionTermId == SessionTermID);
            AssignmentResult = _context.AssignmentResult.Where(c => c.ClassId == ClassID && c.SessionTermId == SessionTermID);
            AffectiveResult = _context.AffectiveResult.Where(d => d.ClassId == ClassID && d.SessionTermId == SessionTermID);
            CAResult = _context.CaResult.Where(f => f.ClassId == ClassID && f.SessionTermId == SessionTermID);

            foreach (var student in Students)
            {
                TotalGrade tg = new TotalGrade
                {
                    StudentId = student.Id,
                    NoOfSubjects = _context.Exam.Where(k => k.StudentId == student.Id && k.SessionTermId == SessionTermID && k.Score != null).Count()
                };
                IEnumerable<Subject> subjects = _context.Exam.Include(q => q.Subject).Where(k => k.StudentId == student.Id && k.SessionTermId == SessionTermID && k.Score != null).Select(g => g.Subject);

                Exam = Exam.Where(e => e.StudentId == student.Id);
                PsycomotResult = PsycomotResult.Where(a => a.StudentId == student.Id);
                CEResult = CEResult.Where(b => b.StudentId == student.Id);
                AssignmentResult = AssignmentResult.Where(c => c.StudentId == student.Id);
                AffectiveResult = AffectiveResult.Where(d => d.StudentId == student.Id);
                CAResult = CAResult.Where(f => f.StudentId == student.Id);

                foreach (var subject in subjects)
                {
                    tg.Total = tg.Total + (Exam.FirstOrDefault(a => a.SubjectId == subject.Id).Score +

                            CAResult.FirstOrDefault(a => a.SubjectId == subject.Id).FirstCa +
                            CAResult.FirstOrDefault(a => a.SubjectId == subject.Id).SecondCa +
                            CAResult.FirstOrDefault(a => a.SubjectId == subject.Id).ThirdCa +
                            CAResult.FirstOrDefault(a => a.SubjectId == subject.Id).FourthCa +
                            CAResult.FirstOrDefault(a => a.SubjectId == subject.Id).FifthCa +

                            AssignmentResult.FirstOrDefault(a => a.SubjectId == subject.Id).Assignment1 +
                            AssignmentResult.FirstOrDefault(a => a.SubjectId == subject.Id).Assignment2 +
                            AssignmentResult.FirstOrDefault(a => a.SubjectId == subject.Id).Assignment3 +
                            AssignmentResult.FirstOrDefault(a => a.SubjectId == subject.Id).Assignment4 +
                            AssignmentResult.FirstOrDefault(a => a.SubjectId == subject.Id).Assignment5 +

                            CEResult.FirstOrDefault(a => a.SubjectId == subject.Id).ClassExercise1 +
                            CEResult.FirstOrDefault(a => a.SubjectId == subject.Id).ClassExercise2 +
                            CEResult.FirstOrDefault(a => a.SubjectId == subject.Id).ClassExercise3 +
                            CEResult.FirstOrDefault(a => a.SubjectId == subject.Id).ClassExercise4 +
                            CEResult.FirstOrDefault(a => a.SubjectId == subject.Id).ClassExercise5);
                }
                if (tg.NoOfSubjects == 0) { tg.Average = 0; } else { tg.Average = tg.Total / tg.NoOfSubjects; }
                Avg = Avg + tg.Average;
                TotalGrade.Add(tg);
            }
            if (Students.Count() == 0) { Avg = 0; } else { Avg = Avg / Students.Count(); }
        }
        public ResultViewModel(ForSchoolsDBContext context, int ClassID, int SubjectID, int SessionTermID)
        {
            _context = context;
            TotalGrade = new List<TotalGrade>();
            Exam = _context.Exam.Where(e => e.ClassId == ClassID && e.SubjectId == SubjectID && e.SessionTermId == SessionTermID);
            PsycomotResult = _context.PsycomotResult.Where(a => a.ClassId == ClassID && a.SessionTermId == SessionTermID);
            CEResult = _context.CeResult.Where(b => b.ClassId == ClassID && b.SubjectId == SubjectID && b.SessionTermId == SessionTermID);
            AssignmentResult = _context.AssignmentResult.Where(c => c.ClassId == ClassID && c.SubjectId == SubjectID && c.SessionTermId == SessionTermID);
            AffectiveResult = _context.AffectiveResult.Where(d => d.ClassId == ClassID && d.SessionTermId == SessionTermID);
            CAResult = _context.CaResult.Where(f => f.ClassId == ClassID && f.SubjectId == SubjectID && f.SessionTermId == SessionTermID);
            Students = _context.SCSt.Include(y => y.Student).Where(z => z.ClassId == ClassID && z.SessionTermId == SessionTermID).Select(p => p.Student);
            IEnumerable<Grade> grade = _context.Grade.Where(v => v.SchoolId == _context.Class.Find(ClassID).SchoolId);
            foreach (var student in Students)
            {
                TotalGrade tg = new TotalGrade
                {
                    StudentId = student.Id,
                    Total = (Exam.FirstOrDefault(a => a.StudentId == student.Id).Score +

                            CAResult.FirstOrDefault(a => a.StudentId == student.Id).FirstCa +
                            CAResult.FirstOrDefault(a => a.StudentId == student.Id).SecondCa +
                            CAResult.FirstOrDefault(a => a.StudentId == student.Id).ThirdCa +
                            CAResult.FirstOrDefault(a => a.StudentId == student.Id).FourthCa +
                            CAResult.FirstOrDefault(a => a.StudentId == student.Id).FifthCa +

                            AssignmentResult.FirstOrDefault(a => a.StudentId == student.Id).Assignment1 +
                            AssignmentResult.FirstOrDefault(a => a.StudentId == student.Id).Assignment2 +
                            AssignmentResult.FirstOrDefault(a => a.StudentId == student.Id).Assignment3 +
                            AssignmentResult.FirstOrDefault(a => a.StudentId == student.Id).Assignment4 +
                            AssignmentResult.FirstOrDefault(a => a.StudentId == student.Id).Assignment5 +

                            CEResult.FirstOrDefault(a => a.StudentId == student.Id).ClassExercise1 +
                            CEResult.FirstOrDefault(a => a.StudentId == student.Id).ClassExercise2 +
                            CEResult.FirstOrDefault(a => a.StudentId == student.Id).ClassExercise3 +
                            CEResult.FirstOrDefault(a => a.StudentId == student.Id).ClassExercise4 +
                            CEResult.FirstOrDefault(a => a.StudentId == student.Id).ClassExercise5)
                };
                tg.Grade = grade.FirstOrDefault(u => u.UpperLimit >= tg.Total && u.LowerLimit <= tg.Total).Name;
                TotalGrade.Add(tg);
            }
        }
    }
}
