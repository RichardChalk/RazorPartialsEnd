using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPartialsEnd.ViewModels;
using SkysFormsDemo.Data;

namespace RazorPartialsEnd.Pages
{
    public class PopularModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public PopularModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ItemViewModel> PopularItems { get; set; }
        public void OnGet()
        {
            PopularItems = _context.Products
                .OrderByDescending(e => e.PopularityPercent)
                .Take(6)
                .Select(e => new ItemViewModel
                {
                    Id = e.Id,
                    Color = e.Color,
                    Ean13 = e.Ean13,
                    Name = e.Name,
                    Price = e.Price
                }).ToList();
        }
    }
}
