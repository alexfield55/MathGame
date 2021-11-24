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
    public class GamesIndexModel : PageModel
    {
        public IUnitOfWork _unitOfWork { get; set; }

        [BindProperty]
        public Player Player { get; set; }

        [BindProperty]
        public Infrastructure.Data.Game Game { get; set; }

        [BindProperty]
        public int Answer { get; set; }
        [BindProperty]
        public int CorrectAnswer { get; set; }
        [BindProperty]
        public int _type { get; set; } //REMEBER TO LOOK AT THIS

        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public int Score { get; set; }

        [BindProperty]
        public int QuestionCount { get; set; }

        public GamesIndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int? id, int? type)
        {
            if (Player == null)
            {
                //change type
                _type = (int)type;
                Player = new Player();
                Player = _unitOfWork.Players.Get(p => p.id == id);
                Game = new Infrastructure.Data.Game()
                {
                    type = _type
                };
                Game.gameQuestions();
                Score = 0;
                QuestionCount = 1;
            }

        }

        public void OnPost()
        {
            QuestionCount++;

            if(Answer==CorrectAnswer)
            {
                Score++;
                Message = "Correct!";
            }
            else
            {
                Message = "Wrong!";
            }

            if(QuestionCount>=10)
            {
                Player.Score = Score;
                _unitOfWork.Players.Update(Player);
                _unitOfWork.Commit();
                Response.Redirect("/Games/Scores");
            }

            Game.gameQuestions();
        }
    }
}
