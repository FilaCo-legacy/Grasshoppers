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
    public class CharactersController : Controller
    {
        private readonly GrasshoppersContext _db;

        public CharactersController(GrasshoppersContext context)
        {
            _db = context;
        }

        private void PopulateUsersDropDownList(object selectedUser= null)
        {
            var usersQuery = from user in _db.Users
                    orderby user.UserName
                    select user;
            
            ViewBag.Users = new SelectList(usersQuery, "Id", 
                "UserName", selectedUser);
        }
        
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            return View(await PaginationViewModel<Character>.CreateAsync(_db.Characters, page, pageSize));
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

            return RedirectToAction("Index");
        }
        
        public IActionResult Create()
        {
            PopulateUsersDropDownList();
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Character character)
        { 
            character.LastTimeOnline = DateTime.Now;
            
            _db.Characters.Add(character);
            await _db.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            
            var character = await _db.Characters.FirstOrDefaultAsync(ch => ch.Id == id);
            
            if (character != null)
                return View(character);
            
            return NotFound();
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            
            var character = await _db.Characters.FirstOrDefaultAsync(ch => ch.Id == id);

            if (character == null)
                return NotFound();
            
            PopulateUsersDropDownList(character.UserId);
            
            return View(character);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Character character)
        {
            _db.Characters.Update(character);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}