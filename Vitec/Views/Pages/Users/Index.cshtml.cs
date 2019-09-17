using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vitec.Models;

namespace Vitec.Views.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly Vitec.Models.VitecContext _context;

        public IndexModel(Vitec.Models.VitecContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
