using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CartView
    {
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public Image Image { get; set; }
    }
}