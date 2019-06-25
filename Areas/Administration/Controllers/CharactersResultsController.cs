using System.Collections.Generic;
using System.Threading.Tasks;
using Grasshoppers.Data;
using Grasshoppers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grasshoppers.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class CharactersResultsController : Controller
    {
        private readonly GrasshoppersContext _db;

        public CharactersResultsController(GrasshoppersContext context)
        {
            _db = context;
        }
        
        public async Task<IActionResult> List(int page = 1, int pageSize = 5)
        {
            return View(await PaginationViewModel<CharacterResultEntry>.CreateAsync(_db.CharactersResults, page, pageSize));
        }
       
        public IActionResult Create() => View();
        
        [HttpPost]
        public async Task<IActionResult> Create(CharacterResultEntry characterResultEntry)
        { 
            _db.CharactersResults.Add(characterResultEntry);
            await _db.SaveChangesAsync();
            
            return RedirectToAction("List");
        }
    }
}