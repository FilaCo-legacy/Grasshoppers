using System.Collections.Generic;
using System.Threading.Tasks;
using Grasshoppers.Data;
using Grasshoppers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grasshoppers.Areas.Administration.Controllers
{
    public class GameSessionsController
    {
        private readonly GrasshoppersContext _db;

        public GameSessionsController(GrasshoppersContext context)
        {
            _db = context;
        }
        
        /*public async Task<IActionResult> List(int page = 1, int pageSize = 5)
        {
            return View(await PaginationViewModel<GameSession>.CreateAsync(_db.GameSessions, page, pageSize));
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(IEnumerable<int> elems)
        {
            foreach (var curId in elems)
            {
                var character = await _db.Characters.FirstOrDefaultAsync(ch => ch.Id == curId);

                if (character == null) continue;
                
                _db.Characters.Remove(character);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }
        
        public IActionResult Create() => View();
        
        [HttpPost]
        public async Task<IActionResult> Create(Character character)
        { 
            _db.Characters.Add(character);
            await _db.SaveChangesAsync();
            
            return RedirectToAction("List");
        }*/
    }
}