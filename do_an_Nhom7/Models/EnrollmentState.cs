using System.ComponentModel.DataAnnotations;

namespace do_an_Nhom7.Models
{
    public enum EnrollmentState
    {
        [Display(Name = "Chờ duyệt")]
        Pending,

        [Display(Name = "Đã duyệt")]
        Approved,

        [Display(Name = "Đã hủy")]
        Cancelled
    }
}
