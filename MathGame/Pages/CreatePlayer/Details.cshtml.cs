﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly MathGameContext _context;

        public DetailsModel(MathGameContext context)
        {
            _context = context;
        }

        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players.FirstOrDefaultAsync(m => m.id == id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}