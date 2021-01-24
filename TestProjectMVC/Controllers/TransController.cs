using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestProjectMVC.Models;

namespace TestProjectMVC.Controllers
{
    public class TransController : Controller
    {
        private readonly TransDbContext _context;

        public TransController(TransDbContext context)
        {
            _context = context;
        }

        // GET: Trans
        public async Task<IActionResult> Index()
        {

            List<TransModel> blog = _context.Trans.ToList<TransModel>();

            return View(await _context.Trans.ToListAsync());
        }

        

        // GET: Trans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Date1,Married,Phone,Salary")] TransModel transModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transModel);
        }

        // GET: Trans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transModel = await _context.Trans.FindAsync(id);
            if (transModel == null)
            {
                return NotFound();
            }
            return View(transModel);
        }

        // POST: Trans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Date1,Married,Phone,Salary")] TransModel transModel)
        {
            if (id != transModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransModelExists(transModel.id))
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
            return View(transModel);
        }

        // GET: Trans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transModel = await _context.Trans
                .FirstOrDefaultAsync(m => m.id == id);
            if (transModel == null)
            {
                return NotFound();
            }

            return View(transModel);
        }

        // POST: Trans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transModel = await _context.Trans.FindAsync(id);
            _context.Trans.Remove(transModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransModelExists(int id)
        {
            return _context.Trans.Any(e => e.id == id);
        }



    }
}
