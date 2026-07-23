using do_an_Nhom7.Models;

namespace do_an_Nhom7.ViewModels
{
    public class DashboardViewModel
    {
        public int CourseCount { get; set; }
        public int StudentCount { get; set; }
        public int TeacherCount { get; set; }
        public int ClassCount { get; set; }
        public int PendingEnrollmentCount { get; set; }
        public int ApprovedEnrollmentCount { get; set; }
        public int CanceledEnrollmentCount { get; set; }
        public decimal Revenue { get; set; }
        public decimal TotalTuition { get; set; }
        public decimal OutstandingTuition { get; set; }
        public int PaymentTransactionCount { get; set; }
        public List<(string ClassCode, string CourseName, int StudentCount)> ClassStatistics { get; set; } = new();
        public List<Course> FeaturedCourses { get; set; } = new();
    }
}
