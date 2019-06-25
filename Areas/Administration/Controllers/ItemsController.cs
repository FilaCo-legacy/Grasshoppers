using System;
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
    public class ItemsController: Controller
    {
        private readonly GrasshoppersContext _db;

        public ItemsController(GrasshoppersContext context)
        {
            _db = context;
        }
        
        private void PopulateOwners(int id)
        {
            var inventoryQuery = from invEntry in _db.Inventories where invEntry.ItemId == id
                orderby invEntry.Owner.Name
                select invEntry.Owner;
            
            ViewBag.Owners = inventoryQuery.AsNoTracking().ToList();
        }
        
        private void PopulateCharactersDropDownList(params object[] selectedCharacters)
        {
            var charactersQuery = from character in _db.Characters
                orderby character.Name
                select character;
            
            ViewBag.Characters = new MultiSelectList(charactersQuery.AsNoTracking(), "Id", 
                "Name", selectedCharacters);
        }
        
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            return View(await PaginationViewModel<Item>.CreateAsync(_db.Items, page, pageSize));
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(IEnumerable<int> elems)
        {
            foreach (var curId in elems)
            {
                var item = await _db.Items.FirstOrDefaultAsync(it => it.Id == curId);

                if (item == null) continue;
                
                _db.Items.Remove(item);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        { 
            _db.Items.Add(item);
            await _db.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            
            var item = await _db.Items.Include(it=>it.InventoryEntries)
                .ThenInclude(invEntry => invEntry.Owner)
                .FirstOrDefaultAsync(it => it.Id == id);

            if (item == null)
                return NotFound();
                    
            PopulateOwners((int)id);
            return View(item);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            
            var item = await _db.Items.FirstOrDefaultAsync(it => it.Id == id);

            if (item == null)
                return NotFound();
            
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Item item)
        {
            _db.Items.Update(item);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}