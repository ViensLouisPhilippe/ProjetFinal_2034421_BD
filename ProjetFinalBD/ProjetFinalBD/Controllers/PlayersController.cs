using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NuGet.Protocol.Plugins;
using ProjetFinalBD.Data;
using ProjetFinalBD.Models;
using ProjetFinalBD.ViewModels;

namespace ProjetFinalBD.Controllers
{
    public class PlayersController : Controller
    {
        private readonly BD1_BengalsCincinnati_TP1Context _context;

        public PlayersController(BD1_BengalsCincinnati_TP1Context context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var bD1_BengalsCincinnati_TP1Context = _context.Players.Include(p => p.Team);
            return View(await bD1_BengalsCincinnati_TP1Context.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }
            PlayerImageViewModel pivm = new PlayerImageViewModel()
            {
                Player = player,
                ImageUrl = player.Image?.FichierImage == null ? null : $"data:image/png;base64,{Convert.ToBase64String(player.Image.FichierImage)}"
            };


            return View(pivm);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,LastName,FirstName,BirthDate,AgeExperience,Number,Position,Available,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerId,LastName,FirstName,BirthDate,AgeExperience,Number,Position,Available,TeamId")] Player player)
        {
            if (id != player.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.PlayerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Players == null)
            {
                return Problem("Entity set 'BD1_BengalsCincinnati_TP1Context.Players'  is null.");
            }
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
          return (_context.Players?.Any(e => e.PlayerId == id)).GetValueOrDefault();
        }

        

        public async Task<IActionResult> VmInfoPlayerAndContract()
        {
            List<VwInfoJoueurEtContract> viewResult = await _context.VwInfoJoueurEtContracts.ToListAsync();
            return View(viewResult);
        }

        public async Task<IActionResult> DeChiffrementPosition(int id)
        {
            Player? player = await _context.Players.FindAsync(id);
            if (player == null) { return NotFound(); }

            string query = "EXEC [dbo].[DeChiffrementPositionDesJoueurs] @PlayerID";

            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter{ParameterName = "@PlayerID", Value = player.PlayerId }
            };
            List<DeChiffrePosition> deChiffrePositions = await _context.DeChiffrePositions.FromSqlRaw(query, parameters.ToArray()).ToListAsync();
            if (deChiffrePositions.Count > 0)
                return Ok(deChiffrePositions[0].Position);
            else
                return NotFound();
        }

        public async Task<IActionResult> Vw_AllPlayersFromSameTeam(int id)
        {
            Player? player = await _context.Players.FindAsync(id);
            if (player == null) { return NotFound(); }
            string query = "EXEC [dbo].[GetAllPlayersFromSameTeam] @TeamId";


            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter{ParameterName = "@TeamId", Value = player.TeamId }
            };

            List<VwAllPlayersFromSameTeam> viewResult = await _context.VwAllPlayersFromSameTeams.FromSqlRaw(query, parameters.ToArray()).ToListAsync();

            return View(viewResult);
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
                Player? player = await _context.Players.FirstOrDefaultAsync(x => x.LastName == imageUploadVM.Nom);
                if (player == null)
                {
                    ModelState.AddModelError("Player", "ce joueur n'existe pas.");
                    return View();
                }

                if (imageUploadVM.FormFile != null && imageUploadVM.FormFile.Length >= 0)
                {
                    MemoryStream stream = new MemoryStream();
                    await imageUploadVM.FormFile.CopyToAsync(stream);
                    byte[] bytes = stream.ToArray();
                    player.Image = new Image()
                    {
                        Nom = player.LastName,
                        Player = player,
                        PlayerId = player.PlayerId,
                        FichierImage = bytes
                    };

                    if (player.Image.FichierImage == null)
                    {
                        ModelState.AddModelError("Player", "Erreur dans la requête.");
                        return View();
                    }
                }
                await _context.SaveChangesAsync();
                ViewData["message"] = "Image ajoutée pour " + player.LastName + " !";
                return RedirectToAction("Details", new { id = player.PlayerId });
            }
            return View(imageUploadVM);
        }
        public async Task<IActionResult> VwVueImage(Player? p)
        {
            Player? player = await _context.Players.FindAsync(p.PlayerId);

            if (_context.Images == null || player == null || player.Image == null)
            {
                return RedirectToAction("AjouterImageAuJoueur");
            }

            ImageViewModel image = new ImageViewModel()
            {
                Image = player.Image,
                ImageUrl = player.Image.FichierImage == null ? null : $"data:image/png;base64,{Convert.ToBase64String(player.Image.FichierImage)}"
            };

            //VwVueImage? viewResult = await _context.VwVueImages.FirstOrDefaultAsync(x => x.Nom == player.Image.Player.LastName);
            //if (viewResult == null)
            //{
            //    ModelState.AddModelError("Player", "ce joueur n'existe pas.");
            //    return View();
            //}

            return View(image);
        }

    }
}
