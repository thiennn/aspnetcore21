using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCore21Demo.Data;

namespace AspNetCore21Demo.Pages.Developers
{
    public class CreateModel : PageModel
    {
        private readonly AspNetCore21Demo.Data.ApplicationDbContext _context;

        public CreateModel(AspNetCore21Demo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Developer Developer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Developers.Add(Developer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}