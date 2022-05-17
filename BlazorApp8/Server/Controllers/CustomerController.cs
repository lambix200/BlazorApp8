//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using BlazorApp8.Server;
using BlazorApp8.Shared;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp8.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            //for (int i = 0; i < 300; i++)
            //{
            //    Product product = new Product
            //    {
            //        Description = Faker.TextFaker.Sentences(3),
            //        Name = Faker.StringFaker.Alpha(6),
            //        Price = Faker.NumberFaker.Number(6, 6000),
            //        CustomerId = Faker.NumberFaker.Number(2,100)
            //    };
            //    _context.Product.Add(product);
            //    _context.SaveChanges();
            //}
         

            _context.Customer.Include(_ => _.Products).ToList();
            var x = _mapper.Map<IEnumerable<Customer>>(_context.Customer);
            return x.ToArray();
        }

        
        // GET: Customers/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            _context.Customer.Include(_ => _.Products).ToList();
            var cus = _context.Customer.FirstOrDefault(_ => _.Id == id);
            return cus;
        }

        // GET: Customers/Delete/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            var obj = _context.Customer.FirstOrDefault(_ => _.Id == id);
            if (obj != null)
            {
                _context.Customer.Remove(obj);
                return _context.SaveChanges();
            }
            return 0; 
        }

        //private async void MakeBase()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Customer cust = new Customer
        //        {
        //            FirstName = Faker.NameFaker.FirstName(),
        //            LastName = Faker.NameFaker.LastName(),
        //            age = Faker.NumberFaker.Number(5, 92),
        //            DateNaissance = Faker.DateTimeFaker.BirthDay(),
        //            Email = Faker.InternetFaker.Email(),
        //            Telephone = Faker.PhoneFaker.Phone()
        //        };
        //        //EntityEntry<Customer> customer = await _context.Customer.AddAsync(cust);
        //        //await _context.SaveChangesAsync();
        //        _context.Customer.Add(cust);
        //        _context.SaveChanges();
        //    }
        //}        


        //// GET: Customers
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Customer != null ? 
        //                  View(await _context.Customer.ToListAsync()) :
        //                  Problem("Entity set 'AppDbContext.Customer'  is null.");
        //}

        //// GET: Customers/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Customer == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customer
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        //// GET: Customers/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Customers/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,age,DateNaissance,Telephone")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(customer);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}

        //// GET: Customers/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Customer == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customer.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(customer);
        //}

        //// POST: Customers/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,age,DateNaissance,Telephone")] Customer customer)
        //{
        //    if (id != customer.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(customer);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CustomerExists(customer.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}

        //// GET: Customers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Customer == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customer
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        //// POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Customer == null)
        //    {
        //        return Problem("Entity set 'AppDbContext.Customer'  is null.");
        //    }
        //    var customer = await _context.Customer.FindAsync(id);
        //    if (customer != null)
        //    {
        //        _context.Customer.Remove(customer);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CustomerExists(int id)
        //{
        //  return (_context.Customer?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
