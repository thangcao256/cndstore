using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDNSTORES.Models.CDNSTORES
{
    public class Images
    {
        [Key]
        [DisplayName("Mã sản phẩm :")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập hình ảnh 1!")]
        [DisplayName("Hình ảnh 1 :")]
        public string Picture1 { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập hình ảnh 2!")]
        [DisplayName("Hình ảnh 2 :")]
        public string Picture2 { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập hình ảnh 3!")]
        [DisplayName("Hình ảnh 3 :")]
        public string Picture3 { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập hình ảnh 4!")]
        [DisplayName("Hình ảnh 4 :")]
        public string Picture4 { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập hình ảnh 5!")]
        [DisplayName("Hình ảnh 5 :")]
        public string Picture5 { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập hình ảnh 6!")]
        [DisplayName("Hình ảnh 6 :")]
        public string Picture6 { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập hình ảnh 7!")]
        [DisplayName("Hình ảnh 7 :")]
        public string Picture7 { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}