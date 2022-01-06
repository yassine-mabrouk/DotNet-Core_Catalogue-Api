using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogueApp
{
    [Table("Products")]
    public class Product
    {

        [Key]
        public  int ProductID { get;  set; }
        public  string Name { get;  set; }
        public  double Price { get;  set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category category  { get; set; } 
    }
}