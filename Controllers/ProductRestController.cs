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
    [Route("/api/products")]
    public class ProductRestController : Controller
    {

       private CatalogueDbRepository categoryRpository ;
       
       public ProductRestController(CatalogueDbRepository repository)
       {
         categoryRpository = repository;
       }

        [HttpGet]
        public IEnumerable<Product> productList()
        {
            return categoryRpository.products.Include(p=>p.category);
        }
        [HttpGet("paginate")]
        public IEnumerable<Product> page(int page=1,int size=1 )
        {
            int skipValue = (page-1)*size;
            return categoryRpository
            .products
            .Include(p=>p.category)
            .Skip(skipValue)
            .Take(size);
        }
        [HttpGet("search")]
        public IEnumerable<Product> search(string kw)
        {
            return categoryRpository
            .products
            .Include(p=>p.category)
            .Where(p=>p.Name.Contains(kw));
        }
        [HttpPost]
        public Product saveProduct([FromBody] Product product)
        {
            categoryRpository.products.Add(product);
            categoryRpository.SaveChanges();
            return product;
        }
        [HttpGet("{Id}")]
        public Product getProduct(int Id)
        {
            
            return categoryRpository.products.Include(p=>p.category).FirstOrDefault(p=>p.ProductID ==Id);
        }
        [HttpDelete("{Id}")]
        public void delete(int Id){
            Product product=categoryRpository.products.FirstOrDefault(p=>p.ProductID==Id);
            categoryRpository.products.Remove(product);
            categoryRpository.SaveChanges();
        }
        [HttpPut("{Id}")]
        public Product update(int Id,[FromBody]Product product){
            product.ProductID=Id;
            categoryRpository.products.Update(product);
            categoryRpository.SaveChanges();
            return product;
        }

     

       
    }
}
