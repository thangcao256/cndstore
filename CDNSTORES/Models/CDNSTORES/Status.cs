using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDNSTORES.Models.CDNSTORES
{
    public class Status
    {
        [Key]
        [DisplayName("Mã trạng thái :")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập loại trạng thái!")]
        [DisplayName("Trạng thái sản phẩm :")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}