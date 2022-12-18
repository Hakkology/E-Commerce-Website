using BuyFS.Entity.DTO;
using BuyFS.Entity.POCO;

namespace Patrician.WebApp.Models
{
    //In order to provide Category details as model for view
    public class CategoryDetailsViewModel
    {
        public List <ProductDto> ProductDto { get; set; }
        public List <Category> Category { get; set; }
    }
}
