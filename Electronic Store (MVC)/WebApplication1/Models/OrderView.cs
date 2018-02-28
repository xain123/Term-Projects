using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OrderView
    {
        public Order Order { get; set; }
        public Address Address { get; set; }
    }
}