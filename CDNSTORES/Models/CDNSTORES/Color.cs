using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDNSTORES.Models.CDNSTORES
{
    public class Color
    {
        [Key]
        [DisplayName("Mã màu :")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên màu sắc!")]
        [DisplayName("Màu sắc :")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}