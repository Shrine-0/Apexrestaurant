using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apexrestaurant.Mvc.Models;
using System.Net.Http.Headers;
// using System.Net.Http.Formatting;


namespace Apexrestaurant.mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly TodoContext _context;

        public CustomersController(TodoContext context)
        {
            _context = context;
        }

        // GET: Customers
        [HttpGet]
        [Route("api/customer")]
        public async Task<IActionResult> Index()
        {
            return _context.Customers != null
                ? View(await _context.Customers.ToListAsync())
                : Problem("Entity set 'TodoContext.Customers'  is null.");
            // using (var httpClient = new HttpClient())
            // {
            //     httpClient.BaseAddress = new Uri("https://localhost:5001/api/customer/");
            //     httpClient.DefaultRequestHeaders.Accept.Clear();
            //     httpClient.DefaultRequestHeaders.Accept.Add(
            //         new MediaTypeWithQualityHeaderValue("application/json")
            //     );

            //     // Call the remote API and handle the response
            //     HttpResponseMessage response = await httpClient.GetAsync("items");
            //     if (response.IsSuccessStatusCode)
            //     {
            //         var items = await response.Content.ReadAsAsync<List<Item>>();
            //         return View(items);
            //     }
            //     else
            //     {
            //         return View("Error");
            //     }
            // }
        }

        // GET: Customers/Details/5

        public async Task<IActionResult> Details([FromRoute] int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "Id,FirstName,LastName,Address,PhoneRes,PhoneMob,EnrollDate,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn"
            )]
                Customer customer
        )
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5

        public async Task<IActionResult> Edit([FromRoute] int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            [FromRoute] int id,
            [Bind(
                "Id,FirstName,LastName,Address,PhoneRes,PhoneMob,EnrollDate,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn"
            )]
                Customer customer
        )
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'TodoContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
