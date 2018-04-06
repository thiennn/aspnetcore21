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
    public class IndexModel : PageModel
    {
        private readonly DevelopersClient _developersClient;

        public IndexModel(DevelopersClient developersClient)
        {
            _developersClient = developersClient;
        }

        public IList<Developer> Developer { get;set; }

        public async Task OnGetAsync()
        {
            Developer = await _developersClient.GetDevelopers();
        }
    }
}
