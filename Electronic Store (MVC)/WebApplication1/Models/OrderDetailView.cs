using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OrderDetailView
    {
        public Product Product { get; set; }
        public Order_details Order_details { get; set; }
        public Image Image { get; set; }
    }
}