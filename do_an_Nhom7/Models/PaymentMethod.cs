using System.ComponentModel.DataAnnotations;

namespace do_an_Nhom7.Models
{
    public enum PaymentMethod
    {
        [Display(Name = "Tiền mặt")]
        Cash,

        [Display(Name = "Chuyển khoản")]
        BankTransfer,

        [Display(Name = "Thẻ")]
        Card
    }
}
