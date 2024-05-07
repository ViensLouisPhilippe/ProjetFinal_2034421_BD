using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinalBD.Data;
using ProjetFinalBD.Models;
using ProjetFinalBD.ViewModels;

namespace ProjetFinalBD.Controllers
{
    public class ImagesController : Controller
    {
        private readonly BD1_BengalsCincinnati_TP1Context _context;

        public ImagesController(BD1_BengalsCincinnati_TP1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Ajouter(Player player)
        {
            if(player == null)
            {
                return NotFound();
            }
            Player? p = await _context.Players.FindAsync(player);
            if(p == null)
            {
                return NotFound();
            }
            Image image = new Image()
            { 
                Nom = player.FirstName + player.LastName, 
            };
            ImageUploadVM imageUploadVM = new ImageUploadVM();
            imageUploadVM.FormFile = null;
            return RedirectToAction("Index");
        }

        public IActionResult AjouterImageAuJoueur()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AjouterImageAuJoueur(ImageUploadVM imageUploadVM)
        {
            if (ModelState.IsValid)
            {
                if (imageUploadVM.FormFile != null && imageUploadVM.FormFile.Length >= 0)
                {
                    MemoryStream stream = new MemoryStream();
                    await imageUploadVM.FormFile.CopyToAsync(stream);
                    byte[] bytes = stream.ToArray();
                    imageUploadVM.Image.FichierImage = bytes;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(imageUploadVM.Image);
        }
    }
}
