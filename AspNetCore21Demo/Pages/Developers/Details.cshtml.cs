using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCore21Demo.Data;

namespace AspNetCore21Demo.Pages.Developers
{
    public class DetailsModel : PageModel
    {
        private readonly AspNetCore21Demo.Data.ApplicationDbContext _context;

        public DetailsModel(AspNetCore21Demo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Developer Developer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Developer = await _context.Developers.FirstOrDefaultAsync(m => m.Id == id);

            if (Developer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
