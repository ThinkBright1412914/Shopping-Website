using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.ViewModel;

namespace Ecommerce.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shop
        public async Task<IActionResult> Index([FromQuery] string searchText ,[FromQuery] string categoryId , [FromQuery] string filter)
        {
            

            searchText ??= "";
            var productFilter = _context.Products.ToList();
            var productViewModel = new List<ProductViewModel>();
            if (filter != null && filter.Contains("all"))
            {
               
            }
            else if (filter != null)
            {
                productFilter = productFilter.Where(p =>
             (filter.Contains("1") && p.Price >= 0 && p.Price <= 100) ||
             (filter.Contains("2") && p.Price >= 100 && p.Price <= 200) ||
             (filter.Contains("3") && p.Price >= 200 && p.Price <= 300) ||
             (filter.Contains("4") && p.Price >= 300 && p.Price <= 400) ||
             (filter.Contains("5") && p.Price >= 400 && p.Price <= 500)
               ).ToList();
            }


            if (string.IsNullOrEmpty(categoryId))
            {
                var products = _context.Products.Where(x => x.Name.ToLower().StartsWith(searchText.ToLower())).ToList();

                products.ForEach(product =>
                {
                    var categories = _context.ProductCategoryHelpers.Include(x => x.Category).Where(x => x.ProductId == product.Id).Select(x => x.Category.Name).ToList();
                    var imgs = _context.ImageProductHelpers.Include(x => x.Image).Where(x => x.ProductId == product.Id).Select(x => x.Image.ImagePath).ToList();
                    productViewModel.Add(new ProductViewModel
                    {
                        Name = product.Name,
                        Id = product.Id,
                        Description = product.Description,
                        Discount = product.Discount,
                        HasDiscount = product.HasDiscount,
                        Price = product.Price,
                        Categories = categories,
                        ImagePaths = imgs

                    });
                });
            }
            else 
            {
                var catProduct = _context.ProductCategoryHelpers.Include(x => x.Product).Where(x => x.CategoryId == categoryId && x.Product.Name.ToLower().StartsWith(searchText.ToLower())).ToList();
                catProduct.ForEach(cat =>
                {
                    var categories = _context.ProductCategoryHelpers.Include(x => x.Category).Where(x => x.ProductId == cat.ProductId).Select(x => x.Category.Name).ToList();
                    var imgs = _context.ImageProductHelpers.Include(x => x.Image).Where(x => x.ProductId == cat.ProductId).Select(x => x.Image.ImagePath).ToList();
                    productViewModel.Add(new ProductViewModel
                    {
                        Name = cat.Product.Name,
                        Id = cat.Product.Id,
                        Description = cat.Product.Description,
                        Discount = cat.Product.Discount,
                        HasDiscount = cat.Product.HasDiscount,
                        Price = cat.Product.Price,
                        Categories = categories,
                        ImagePaths = imgs

                    });
                });
            }   

           
              return View(productViewModel);
        }

   
      

        // GET: Shop/Details/5
        public async Task<IActionResult> Details(string id)
        {

            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var selectedCategories = _context.ProductCategoryHelpers.Include(x => x.Category).Where(x => x.ProductId == product.Id).Select(x => x.Category.Name).ToList();
            var category = _context.Categories;
            var selectedImgs = _context.ImageProductHelpers.Include(x => x.Image).Where(x => x.ProductId == product.Id).Select(x => x.Image.ImagePath).ToList();
            return View(new ProductViewModel()
            {
                Id = product.Id,
                Categories = selectedCategories,
                ImagePaths = selectedImgs,
                Description = product.Description,
                Discount = product.Discount,
                HasDiscount = product.HasDiscount,
                Name = product.Name,
                Price = product.Price,
               
            }) ;
            
        }

        // GET: Shop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,HasDiscount,Discount")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Shop/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Price,HasDiscount,Discount")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Shop/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
