using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CategoryView
    {
        public List<Category> Parent { get; set; }
        public List<Category> Child { get; set; }
    }
}