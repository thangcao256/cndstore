using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDNSTORES.Models.CDNSTORES
{
    public class Size
    {
        [Key]
        [DisplayName("Mã kích cỡ :")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập kích cỡ!")]
        [DisplayName("Kích cỡ :")]
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}