using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDNSTORES.Models.CDNSTORES
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập số lượng sản phẩm nhỏ nhất bằng 1!")]
        [DisplayName("Số lượng :")]
        public int Number { get; set; }
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }

        public int OrderInfoId { get; set; }
        public OrderInfo OrderInfo { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        
    }
}