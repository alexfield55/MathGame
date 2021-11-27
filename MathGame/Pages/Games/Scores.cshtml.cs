using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MathGame.Pages.Games
{
    public class ScoresModel : PageModel
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public List<Player> PlayerList {get;set;}
        public ScoresModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int? id)
        {
            PlayerList = new List<Player>();
            PlayerList = _unitOfWork.Players.List().ToList();
        }
    }
}
