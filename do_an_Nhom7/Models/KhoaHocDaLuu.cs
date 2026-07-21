using System.ComponentModel.DataAnnotations.Schema;

namespace do_an_Nhom7.Models
{
    public class SavedCourse
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public DateTime SavedAt { get; set; } = DateTime.Now;
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
