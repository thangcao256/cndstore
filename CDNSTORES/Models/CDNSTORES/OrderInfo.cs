using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDNSTORES.Models.CDNSTORES
{
    public class OrderInfo
    {
        [Key]
        [DisplayName("Mã đơn :")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên người nhận hàng!")]
        [DisplayName("Tên người nhận :")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập số điện thoại người nhận!")]

        [DisplayName("Số điện thoại :")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập địa chỉ nhận hàng!")]

        [DisplayName("Địa chỉ :")]
        public string Place { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}