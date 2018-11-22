using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Models;

namespace Shop.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
