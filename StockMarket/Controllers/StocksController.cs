using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using StockMarket.Models;

namespace StockMarket.Controllers
{
    public class StocksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StocksController(ApplicationDbContext context)
        {
            _context = context;
 
        }

        
        public async Task<IActionResult> Index()
        {
               var x = await _context.Stocks.ToListAsync();
            Random random = new Random();
            int randomNumber1 = random.Next(0, 300);
            foreach (var item in x)
            {
                item.LastPrice = randomNumber1;
            }

            return View(x);
        }
        [HttpGet]
        public IActionResult GetStocks()
        {
            var result = _context.Stocks.ToList();
            return Ok(result);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stocks == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Stock stock)
        {
            if (ModelState.IsValid)
            {
               stock.CreationDate= DateTime.Now;
                stock.LastModified= DateTime.Now;
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stocks == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Stock stock)
        {
            if (id != stock.StockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                 var temp = _context.Stocks.Where(x => x.StockId == id).AsNoTracking().FirstOrDefault();
                    stock.CreationDate = temp.CreationDate;
                    stock.LastModified= DateTime.Now;
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.StockId))
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
            return View(stock);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stocks == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stocks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Stocks'  is null.");
            }
            var stock = await _context.Stocks.FindAsync(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int id)
        {
          return _context.Stocks.Any(e => e.StockId == id);
        }
    }
}
