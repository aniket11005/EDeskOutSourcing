using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EDeskOutSourcing.Models
{
    public class CompanyContext:DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            foreach (var temp in mb.Model.GetEntityTypes().SelectMany(p => p.GetForeignKeys()))
            {
                temp.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyFAQ> CompanyFAQs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<FinishedProject> FinishedProjects { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<FreelancerCertifications> FreelancerCertifications { get; set; }
        public DbSet<FreelancerEducation> FreelancerEducations { get; set; }
        public DbSet<FreelancerExperience> FreelancerExperiences { get; set; }
        public DbSet<FreelancerFAQ> FreelancerFAQs { get; set; }
        public DbSet<FreelancerPreviousProject> FreelancerPreviousProjects { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PaymentMode> PaymentModes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectApplication> ProjectApplications { get; set; }
        public DbSet<ProjectAssigned> ProjectAssigneds { get; set; }
        public DbSet<ProjectDocument> ProjectDocuments { get; set; }
        public DbSet<ProjectStages> ProjectStages { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<ProjectTaskAssignment> ProjectTaskAssignments { get; set; }
        public DbSet<ProjectTaskDocument> ProjectTaskDocuments { get; set; }
        public DbSet<ProjectTaskQuery> ProjectTaskQueries { get; set; }
        public DbSet<ProjectTaskQuerySolution> ProjectTaskQuerySolutions { get; set; }
        public DbSet<ProjectTaskReport> ProjectTaskReports { get; set; }
        public DbSet<ProjectTaskReportConflict> ProjectTaskReportConflicts { get; set; }
        public DbSet<ProjectTaskReportConflictSolution> ProjectTaskReportConflictSolutions { get; set; }
        public DbSet<ProjectTaskReportPaymentConflictSolution> ProjectTaskReportPaymentConflictSolutions { get; set; }
        public DbSet<ProjectTaskReportReleasePayment> ProjectTaskReportReleasePayments { get; set; }
        public DbSet<ProjectTaskReportReleasePaymentConflict> ProjectTaskReportReleasePaymentConflicts { get; set; }
        public DbSet<SelectedApplication> SelectedApplications { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Technologies> Technologies { get; set; }
        public DbSet<TerminatedProject> TerminatedProjects { get; set; }
        public DbSet<TermsAndConditionForCompany> TermsAndConditionForCompanies { get; set; }
        public DbSet<TermsAndConditionForFreelancer> TermsAndConditionForFreelancers { get; set; }

    }
}
