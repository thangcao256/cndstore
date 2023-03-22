using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDNSTORES.Models.CDNSTORES
{
    public class Product
    {
        [Key]
        [DisplayName("Mã sản phẩm :")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên sản phẩm!")]
        [DisplayName("Tên sản phẩm :")]
        public string Name { get; set; }

        public int ImagesId { get; set; }
        public Images Images { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int PriceId { get; set; }
        public Price Price { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}