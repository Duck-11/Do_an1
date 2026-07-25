using System.ComponentModel.DataAnnotations;

namespace do_an_Nhom7.Models
{
    public class SavedCourse
    {
        public int Id { get; set; }

        [Display(Name = "Học viên")]
        public int StudentId { get; set; }

        [Display(Name = "Khóa học")]
        public int CourseId { get; set; }

        [Display(Name = "Ngày lưu")]
        public DateTime SavedAt { get; set; } = DateTime.Now;

        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
