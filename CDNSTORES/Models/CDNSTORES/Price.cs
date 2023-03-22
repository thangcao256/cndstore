using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDNSTORES.Models.CDNSTORES
{
    public class Price
    {
        [Key]
        [DisplayName("Mã giá tiền :")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập giá tiền!")]
        [DisplayName("Giá :")]
        public double Money { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}