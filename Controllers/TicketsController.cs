using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Downstream.Data;
using Downstream.Models;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System.IO;

namespace Downstream.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index(string ticketIssueType, string searchString)
        {

            if (_context.Ticket == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ticket is null.");
            }

            
            int ticketsCount = _context.Ticket.Count();

            ViewBag.TicketsCount = ticketsCount;

            IQueryable<string> issueTypeQuery = from t in _context.Ticket
                                                orderby t.IssueType
                                                select t.IssueType;


            var tickets = from t in _context.Ticket
                          select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(ticketIssueType))
            {
                tickets = tickets.Where(x => x.IssueType == ticketIssueType);
            }

            var ticketIssueTypeVM = new TicketIssueTypeViewModel
            {
                IssueTypes = new SelectList(await issueTypeQuery.Distinct().ToListAsync()),
                Tickets = await tickets.ToListAsync()

            };

            return View(ticketIssueTypeVM);

        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }
            
            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description, IssueType,TimeEntered,RequiredResolutionTime, IsResolved")] Ticket ticket)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    BasicLogger.WriteToFile("CreateLog", DateTime.Now.ToString() + " Ticket Create action completed successfully from Tickets controller!");
                    _context.Add(ticket);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
               
         
            }

            catch 
            {

                BasicLogger.WriteToFile("CreateLog", DateTime.Now.ToString() + " Error occured during Create action within Tickets controller!");

            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description, IssueType,TimeEntered,RequiredResolutionTime, IsResolved")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
               
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ticket == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ticket'  is null.");
            }
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
          return (_context.Ticket?.Any(e => e.Id == id)).GetValueOrDefault();
        }



    }
}
