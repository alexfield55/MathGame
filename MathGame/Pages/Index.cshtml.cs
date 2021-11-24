using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MathGame.Pages
{
    public class IndexModel : PageModel
    {
        public IUnitOfWork _unitOfWork { get; set; }

        [BindProperty]
        public Player PlayerObj { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                Response.Redirect("/Index");
            }

            //add new player in
            _unitOfWork.Players.Add(new Player
            {
                Name = PlayerObj.Name,
                Age = PlayerObj.Age
            });

            Player p = new Player();
            p = _unitOfWork.Players.Get(p => p.Name == PlayerObj.Name);

            //go to game page
            Response.Redirect("/Game/GameIndex?id="+p.id);
        }
    }
}
