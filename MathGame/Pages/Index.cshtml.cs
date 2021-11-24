using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathGame.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Player PlayerObj { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
           // _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //add new player in
            //_unitOfWork.Players.Add(new Player
            //{
            //    Name = PlayerObj.Name,
            //    Age = PlayerObj.Age
            //});

            //go to game page
            return RedirectToPage("/Game/GameIndex");
        }
    }
}
