using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CatalogueApp.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace CatalogueApp.Controllers
{
    [Route("/api/categories")]
    public class CategoryRestController : Controller
    {

       private CatalogueDbRepository categoryRpository ;
       
       public CategoryRestController(CatalogueDbRepository repository)
       {
         categoryRpository = repository;
       }

        [HttpGet]
        public IEnumerable<Category> categoryList()
        {
            return categoryRpository.categories;
        }
        [HttpPost]
        public Category saveCategory([FromBody] Category category)
        {
            categoryRpository.categories.Add(category);
            categoryRpository.SaveChanges();
            return category;
        }
        [HttpGet("{Id}")]
        public Category getCategory(int Id)
        {
            
            return categoryRpository.categories.FirstOrDefault(c=>c.CategoryID ==Id);
        }
        [HttpGet("{Id}/products")]
        public IEnumerable<Product> products(int Id)
        {
            Category category = categoryRpository.categories.Include(c=>c.Products).FirstOrDefault(c=>c.CategoryID ==Id);
            return category.Products;
        }
        [HttpDelete("{Id}")]
        public void delete(int Id){
            Category category=categoryRpository.categories.FirstOrDefault(c=>c.CategoryID==Id);
            categoryRpository.categories.Remove(category);
            categoryRpository.SaveChanges();
        }
        [HttpPut("{Id}")]
        public Category update(int Id,[FromBody]Category category){
            category.CategoryID=Id;
            categoryRpository.categories.Update(category);
            categoryRpository.SaveChanges();
            return category;
        }

     

       
    }
}
