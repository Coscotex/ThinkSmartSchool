using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ThinkSmartSchools.Models
{
    public partial class ForSchoolsDBContext : DbContext
    {
        public virtual DbSet<AffectiveResult> AffectiveResult { get; set; }
        public virtual DbSet<AssessmentType> AssessmentType { get; set; }
        public virtual DbSet<AssignmentResult> AssignmentResult { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookBorrowed> BookBorrowed { get; set; }
        public virtual DbSet<CaResult> CaResult { get; set; }
        public virtual DbSet<CarMaintenance> CarMaintenance { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CeResult> CeResult { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassSubject> ClassSubject { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Discussion> Discussion { get; set; }
        public virtual DbSet<DriverCar> DriverCar { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<ExtraFees> ExtraFees { get; set; }
        public virtual DbSet<Fees> Fees { get; set; }
        public virtual DbSet<FeesPaid> FeesPaid { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<PsycomotResult> PsycomotResult { get; set; }
        public virtual DbSet<ResultType> ResultType { get; set; }
        public virtual DbSet<ResultTypeItem> ResultTypeItem { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<SCSt> SCSt { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<SessionTerm> SessionTerm { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StaffSubject> StaffSubject { get; set; }
        public virtual DbSet<Stops> Stops { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentSubject> StudentSubject { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Term> Term { get; set; }


        public ForSchoolsDBContext(DbContextOptions<ForSchoolsDBContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffectiveResult>(entity =>
            {
                entity.ToTable("Affective_Result");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ResultTypeItemId).HasColumnName("ResultTypeItemID");

                entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SessionTermId).HasColumnName("SessionTermID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AffectiveResult)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Affective_Result_Class");

                entity.HasOne(d => d.ResultTypeItem)
                    .WithMany(p => p.AffectiveResult)
                    .HasForeignKey(d => d.ResultTypeItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Affective_Result_ResultTypeItem");

                entity.HasOne(d => d.SessionTerm)
                    .WithMany(p => p.AffectiveResult)
                    .HasForeignKey(d => d.SessionTermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Affective_Result_SessionTerm");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AffectiveResult)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Affective_Result_Student");
            });

            modelBuilder.Entity<AssessmentType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AssignmentResult>(entity =>
            {
                entity.ToTable("Assignment_Result");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Assignment1)
                    .HasColumnName("Assignment_1")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Assignment2)
                    .HasColumnName("Assignment_2")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Assignment3)
                    .HasColumnName("Assignment_3")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Assignment4)
                    .HasColumnName("Assignment_4")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Assignment5)
                    .HasColumnName("Assignment_5")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.SessionTermId).HasColumnName("SessionTermID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AssignmentResult)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_Result_Class");

                entity.HasOne(d => d.SessionTerm)
                    .WithMany(p => p.AssignmentResult)
                    .HasForeignKey(d => d.SessionTermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_Result_SessionTerm");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AssignmentResult)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_Result_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.AssignmentResult)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_Result_Subject");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Category");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_School");
            });

            modelBuilder.Entity<BookBorrowed>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TimeBorrowed).HasColumnType("datetime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookBorrowed)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookBorrowed_Book");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.BookBorrowed)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_BookBorrowed_Staff");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.BookBorrowed)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_BookBorrowed_Student");
            });

            modelBuilder.Entity<CaResult>(entity =>
            {
                entity.ToTable("CA_Result");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.FifthCa)
                    .HasColumnName("Fifth_CA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FirstCa)
                    .HasColumnName("First_CA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FourthCa)
                    .HasColumnName("Fourth_CA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SecondCa)
                    .HasColumnName("Second_CA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SessionTermId).HasColumnName("SessionTermID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.ThirdCa)
                    .HasColumnName("Third_CA")
                    .HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.CaResult)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CA_Result_Class");

                entity.HasOne(d => d.SessionTerm)
                    .WithMany(p => p.CaResult)
                    .HasForeignKey(d => d.SessionTermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CA_Result_SessionTerm");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CaResult)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CA_Result_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.CaResult)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CA_Result_Subject");
            });

            modelBuilder.Entity<CarMaintenance>(entity =>
            {
                entity.ToTable("Car_Maintenance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DriverCarId).HasColumnName("DriverCarID");

                entity.HasOne(d => d.DriverCar)
                    .WithMany(p => p.CarMaintenance)
                    .HasForeignKey(d => d.DriverCarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Maintenance_Driver_Car");
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PlateNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK_Cars_Staff");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cars_School");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<CeResult>(entity =>
            {
                entity.ToTable("CE_Result");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassExercise1)
                    .HasColumnName("Class_Exercise_1")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ClassExercise2)
                    .HasColumnName("Class_Exercise_2")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ClassExercise3)
                    .HasColumnName("Class_Exercise_3")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ClassExercise4)
                    .HasColumnName("Class_Exercise_4")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ClassExercise5)
                    .HasColumnName("Class_Exercise_5")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.SessionTermId).HasColumnName("SessionTermID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.CeResult)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CE_Result_Class");

                entity.HasOne(d => d.SessionTerm)
                    .WithMany(p => p.CeResult)
                    .HasForeignKey(d => d.SessionTermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CE_Result_SessionTerm");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CeResult)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CE_Result_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.CeResult)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CE_Result_Subject");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Institution");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_School");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Staff");
            });

            modelBuilder.Entity<ClassSubject>(entity =>
            {
                entity.ToTable("Class_Subject");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassSubject)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Subject_Class");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ClassSubject)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Subject_Subject");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DiscussionId).HasColumnName("DiscussionID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Discussion)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.DiscussionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Discussion");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Comment_Staff");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Comment_Student");
            });

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Discussion)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Discussion_School");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Discussion)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Discussion_Staff");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Discussion)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Discussion_Student");
            });

            modelBuilder.Entity<DriverCar>(entity =>
            {
                entity.ToTable("Driver_Car");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.DriverCar)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_Car_Cars");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.DriverCar)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_Car_Staff");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Remark).HasColumnType("text");

                entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SessionTermId).HasColumnName("SessionTermID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_Class");

                entity.HasOne(d => d.SessionTerm)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.SessionTermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_SessionTerm");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_Subject");
            });

            modelBuilder.Entity<ExtraFees>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.StudentGuid)
                    .IsRequired()
                    .HasColumnName("StudentGUID")
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<Fees>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fees_Class");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fees_School");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fees_Session");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fees_Term");
            });

            modelBuilder.Entity<FeesPaid>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AmountPaid).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FeesId).HasColumnName("FeesID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Fees)
                    .WithMany(p => p.FeesPaid)
                    .HasForeignKey(d => d.FeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeesPaid_Fees");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.FeesPaid)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeesPaid_Student");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_School");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_News_Staff");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("GUID")
                    .HasMaxLength(70);

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Parent)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parent_Institution");
            });

            modelBuilder.Entity<PsycomotResult>(entity =>
            {
                entity.ToTable("Psycomot_Result");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ResultTypeItemId).HasColumnName("ResultTypeItemID");

                entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SessionTermId).HasColumnName("SessionTermID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.PsycomotResult)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Psycomot_Result_Class");

                entity.HasOne(d => d.ResultTypeItem)
                    .WithMany(p => p.PsycomotResult)
                    .HasForeignKey(d => d.ResultTypeItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Psycomot_Result_ResultTypeItem");

                entity.HasOne(d => d.SessionTerm)
                    .WithMany(p => p.PsycomotResult)
                    .HasForeignKey(d => d.SessionTermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Psycomot_Result_SessionTerm");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.PsycomotResult)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Psycomot_Result_Student");
            });

            modelBuilder.Entity<ResultType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssessmentTypeId).HasColumnName("AssessmentTypeID");

                entity.Property(e => e.MaxScore).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NoOfItems).HasDefaultValueSql("((0))");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.HasOne(d => d.AssessmentType)
                    .WithMany(p => p.ResultType)
                    .HasForeignKey(d => d.AssessmentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultType_AssessmentType");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.ResultType)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultType_School");
            });

            modelBuilder.Entity<ResultTypeItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResultTypeId).HasColumnName("ResultTypeID");

                entity.HasOne(d => d.ResultType)
                    .WithMany(p => p.ResultTypeItem)
                    .HasForeignKey(d => d.ResultTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultTypeItem_ResultType");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(70)");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Route)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Route_Staff");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Penalty).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Salary_Staff");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.School)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_School_Institution");
            });

            modelBuilder.Entity<SCSt>(entity =>
            {
                entity.ToTable("S_C_ST");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassTRemarks)
                    .HasColumnName("ClassT_Remarks")
                    .HasMaxLength(50);

                entity.Property(e => e.HeadTRemarks)
                    .HasColumnName("HeadT_Remarks")
                    .HasMaxLength(50);

                entity.Property(e => e.SessionTermId).HasColumnName("SessionTermID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SCSt)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_S_C_ST_Class");

                entity.HasOne(d => d.SessionTerm)
                    .WithMany(p => p.SCSt)
                    .HasForeignKey(d => d.SessionTermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_S_C_ST_SessionTerm");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.SCSt)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_S_C_ST_Student");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SessionTerm>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.SessionTerm)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionTerm_Institution");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionTerm)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionTerm_Session");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.SessionTerm)
                    .HasForeignKey(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionTerm_Term");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("GUID")
                    .HasMaxLength(70);

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LicenceNo)
                    .HasColumnName("Licence_No")
                    .HasMaxLength(50);

                entity.Property(e => e.OtherNames).HasMaxLength(50);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Institution");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_School");
            });

            modelBuilder.Entity<StaffSubject>(entity =>
            {
                entity.ToTable("Staff_Subject");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StaffSubject)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Subject_Class");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.StaffSubject)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Subject_Institution");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.StaffSubject)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Subject_Staff");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StaffSubject)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Subject_Subject");
            });

            modelBuilder.Entity<Stops>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(30)");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Stops)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stops_Route");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("GUID")
                    .HasMaxLength(70);

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OtherNames).HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Student_Class");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Institution");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Parent");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_School");
            });

            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.ToTable("Student_Subject");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentSubject)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Subject_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentSubject)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Subject_Subject");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_Institution");
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateStart).HasColumnType("datetime");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Term)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Term_Institution");
            });
        }
    }
}
