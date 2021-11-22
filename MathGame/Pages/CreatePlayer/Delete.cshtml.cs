using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;
using Infrastructure.Data;

namespace MathGame
{
    public class DeleteModel : PageModel
    {
        private readonly MathGameContext _context;

        public DeleteModel(MathGameContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Player.FirstOrDefaultAsync(m => m.id == id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Player.FindAsync(id);

            if (Player != null)
            {
                _context.Player.Remove(Player);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
