using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using FarmCentral2.Models;

namespace FarmCentral2.Controllers
{
    public class Filter : Controller
    {
        public class FilterProductsController : Controller
        {
            private readonly FarmCentral2Context _context;

            public FilterProductsController(FarmCentral2Context context)
            {
                _context = context;
            }

            // GET: FilterProducts
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            public async Task<IActionResult> Index(string sortOrder, string searchString)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            {
                var Products = from s in _context.Products
                               select s;

                if (!String.IsNullOrEmpty(searchString))
                {
                    Products = Products.Where(s => s.ProductName.Contains(searchString));

                }

                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "names_desc" : "";
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "namess_desc" : "";
                //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
                Products = sortOrder switch
                {
                    "name_desc" => Products.OrderByDescending(s => s.ProductId),
                    "names_desc" => Products.OrderByDescending(s => s.TypeOfProduct),
                    "namess_desc" => Products.OrderByDescending(s => s.ProductName),
                    _ => Products.OrderBy(s => s.FarmerId),
                };
                return View(Products.ToList());
            }

            // GET: FilterFarmerProducts
            public Task<IActionResult> Home(string sortOrder, string searchString)
            {
                return Task.FromResult<IActionResult>(View());
            }

        }
    }
}
  