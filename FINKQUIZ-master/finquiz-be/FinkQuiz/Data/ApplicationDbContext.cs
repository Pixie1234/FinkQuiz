using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinkQuiz.Models;
using Microsoft.AspNetCore.Identity;

namespace FinkQuiz.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        // Add DbSets for all quiz-related models
        public DbSet<Student> Students { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SingleChoiceQuestion> SingleChoiceQuestions { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public DbSet<EssayQuestion> EssayQuestions { get; set; }
        public DbSet<CompletedQuiz> CompletedQuizzes { get; set; }
        public DbSet<Predmet> Predmets { get; set; }
        public DbSet<Oblast> Oblasts { get; set; }
        public DbSet<PredmetStudent> PredmetStudents { get; set; }
        public DbSet<PredmetStaff> PredmetStaff { get; set; }
        public DbSet<PredmetOblast> PredmetOblasts { get; set; }
        public DbSet<PredmetQuiz> PredmetQuizzes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure the User table name to be AspNetUsers (default Identity table)
            // This tells EF that your User class maps to the AspNetUsers table
            modelBuilder.Entity<User>().ToTable("AspNetUsers");
            
            // Configure the Student and Staff as TPT
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Staff>().ToTable("Staff");
            
            // Configure Table-per-Hierarchy inheritance for Question
            modelBuilder.Entity<Question>()
                .ToTable("Questions")
                .HasDiscriminator(q => q.QuestionType)
                .HasValue<SingleChoiceQuestion>("SingleChoice")
                .HasValue<MultipleChoiceQuestion>("MultipleChoice")
                .HasValue<EssayQuestion>("Essay");
                
            // Configure relationships
            modelBuilder.Entity<Quiz>()
                .HasOne(q => q.Creator)
                .WithMany(s => s.CreatedQuizzes)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany(qz => qz.Questions)
                .HasForeignKey(q => q.QuizId);
                
            modelBuilder.Entity<CompletedQuiz>()
                .HasOne(cq => cq.Student)
                .WithMany(s => s.CompletedQuizzes)
                .HasForeignKey(cq => cq.StudentId);
                
            modelBuilder.Entity<CompletedQuiz>()
                .HasOne(cq => cq.Quiz)
                .WithMany(q => q.CompletedQuizzes)
                .HasForeignKey(cq => cq.QuizId);
            
            // Configure many-to-many relationships
            modelBuilder.Entity<PredmetStudent>()
                .HasOne(ps => ps.Student)
                .WithMany(s => s.Subjects)
                .HasForeignKey(ps => ps.StudentId);

            ///   .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PredmetStudent>()
                .HasOne(ps => ps.Predmet)
                .WithMany(p => p.Students)
                .HasForeignKey(ps => ps.PredmetId);

            ///   .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PredmetStaff>()
                .HasOne(ps => ps.Professor)
                .WithMany(s => s.Subjects)
                .HasForeignKey(ps => ps.ProfessorId);
               

            modelBuilder.Entity<PredmetStaff>()
                .HasOne(ps => ps.Predmet)
                .WithMany(p => p.Professors)
                .HasForeignKey(ps => ps.PredmetId);
            
            modelBuilder.Entity<PredmetOblast>()
                .HasOne(po => po.Predmet)
                .WithMany(p => p.Areas)
                .HasForeignKey(po => po.PredmetId);
            
            modelBuilder.Entity<PredmetOblast>()
                .HasOne(po => po.Oblast)
                .WithMany(o => o.Subjects)
                .HasForeignKey(po => po.OblastId);
            
            modelBuilder.Entity<PredmetQuiz>()
                .HasOne(pq => pq.Predmet)
                .WithMany(p => p.Quizzes)
                .HasForeignKey(pq => pq.PredmetId);
            
            modelBuilder.Entity<PredmetQuiz>()
                .HasOne(pq => pq.Quiz)
                .WithMany(q => q.Predmets)
                .HasForeignKey(pq => pq.QuizId);
        }
    }
} 