using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDNSTORES.Models.CDNSTORES
{
    public class Material
    {
        [Key]
        [DisplayName("Mã chất liệu :")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên chất liệu!")]
        [DisplayName("Chất liệu :")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}