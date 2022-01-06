using System;
namespace CatalogueApp.Services
{
    public class DbInit
    {
        public static void initDb(CatalogueDbRepository catalogueDb)
        {
         Console.WriteLine("Data init");
         catalogueDb.categories.Add(new Category{Name="Orginateurs"});
         catalogueDb.categories.Add(new Category{Name="Imprimantes"});
        
         catalogueDb.products.Add(new Product{Name="MAC",Price=9000,CategoryID=1});
         catalogueDb.products.Add(new Product{Name="HP",Price=5000,CategoryID=1});
         catalogueDb.products.Add(new Product{Name="HP imprimate",Price=500,CategoryID=2});
         catalogueDb.products.Add(new Product{Name="Dell imprimate",Price=450,CategoryID=2});
        
         catalogueDb.SaveChanges();
        }
    }
}