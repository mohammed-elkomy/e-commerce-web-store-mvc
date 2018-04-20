using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Models;
using ECommerce.Models.NewDb;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        public ViewResult Index(
            int? minPrice = null,
            int? maxPrice = null,
            int perPage = 9,
            int page = 0,
            int? category = null,
            string keywords = null,
            OrderBy orderBy = OrderBy.Default)
        {
            var result = _context.Products.AsQueryable();
            if (minPrice != null)
                result = result.Where(o => o.Price >= minPrice);
            if (maxPrice != null)
                result = result.Where(o => o.Price <= maxPrice);
            if (category != null)
                result = result.Where(o => o.CategoryId == category);
            if (!string.IsNullOrWhiteSpace(keywords))
                result = result.Where(o => o.Name.Contains(keywords));
            switch (orderBy)
            {
                case OrderBy.Price:
                    result = result.OrderBy(o => o.Price);
                    break;
                case OrderBy.Popularity:
                    result = result.OrderBy(o => o.SoldCount);
                    break;
                case OrderBy.AverageRating:
                    break;
                default:
                    result = result.OrderBy(o => o.Id);
                    break;
            }

            ViewData["minPrice"] = minPrice;
            ViewData["maxPrice"] = maxPrice;
            ViewData["perPage"] = perPage;
            ViewData["page"] = page;
            ViewData["category"] = category;
            ViewData["keywords"] = keywords;
            ViewData["orderBy"] = orderBy;

            BuildCategoryTree(result);
            result = result.Skip(page * perPage).Take(perPage);
            SetAd(category);
            return View(result);
        }

        public IActionResult Single(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null || product.Id < 1)
            {
                return RedirectToAction("Index");
            }

            SetAd(product.CategoryId);
            return View(product);
        }


        private void SetAd(int? category)
        {
            var ads = _context.Advertisements.Where(a => a.Enabled);
            if (category != null)
                ads = ads.Where(a => a.Categories.Any(c => c.CategoryId == category));
            ViewData["Ad"] = ads.Skip(new Random().Next(ads.Count() - 1)).Take(1);
        }

        private void BuildCategoryTree(IQueryable<Product> products)
        {
            var categoryTree = _context.Categories.ToLookup(c => c.ParentId);
            ViewData["CategoryTree"] = BuildSubTree(null);

            CategoryTreeEntry BuildSubTree(int? key)
            {
                var result = new CategoryTreeEntry { Id = key, Children = new List<CategoryTreeEntry>() };
                foreach (var category in categoryTree[key])
                {
                    var child = BuildSubTree(category.Id);
                    result.Children.Add(child);
                    result.Count += child.Count;
                }

                result.Count += products.Count(p => p.CategoryId == key);
                return result;
            }
        }
    }
}
