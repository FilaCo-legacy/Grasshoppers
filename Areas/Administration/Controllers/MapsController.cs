using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grasshoppers.Data;
using Grasshoppers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Grasshoppers.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class MapsController: Controller
    {
        private readonly GrasshoppersContext _db;

        public MapsController(GrasshoppersContext context)
        {
            _db = context;
        }
        
        private void PopulateMissions(int id)
        {
            var missionsQuery = from mission in _db.Missions where mission.MapId == id
                orderby mission.Name
                select mission;
            
            ViewBag.Missions = missionsQuery.AsNoTracking().ToList();
        }
        
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            return View(await PaginationViewModel<Map>.CreateAsync(_db.Maps, page, pageSize));
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(IEnumerable<int> elems)
        {
            foreach (var curId in elems)
            {
                var map = await _db.Maps.FirstOrDefaultAsync(mp => mp.Id == curId);

                if (map == null) continue;
                
                _db.Maps.Remove(map);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Map map)
        { 
            _db.Maps.Add(map);
            await _db.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            
            var map = await _db.Maps.Include(mp=>mp.Missions)
                .FirstOrDefaultAsync(mp => mp.Id == id);

            if (map == null)
                return NotFound();
                    
            PopulateMissions((int)id);
            return View(map);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            
            var map = await _db.Maps.FirstOrDefaultAsync(mp => mp.Id == id);

            if (map == null)
                return NotFound();
            
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Map map)
        {
            _db.Maps.Update(map);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}