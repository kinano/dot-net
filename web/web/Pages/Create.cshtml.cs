using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace web.Pages
{
    public class CreateModel : PageModel
    {
        // Make the DB context private and readonly to protect it from other modules
        private readonly AppDbContext _db;

        [BindProperty]
        public Customer Customer { get; set; }
        [TempData]
        public string Message { get; set; }

        private ILogger<CreateModel> Log;

        public CreateModel(AppDbContext db, ILogger<CreateModel> log)
        {
            _db = db;
            Log = log;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            var msg = $"Customer {Customer.Name} added!";
            Message = msg;
            Log.LogCritical(msg);
            return RedirectToPage("/Index");
        }
    }
}
