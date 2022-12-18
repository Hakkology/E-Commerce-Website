using BuyFS.Entity.POCO;
using MerchantFS.DataAccessLayer.Concreate.Context.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantFS.DataAccessLayer.SeedData
{
    public static class Seed
    {
        //Data seed is where data is added to the database and shall work as static - and only once for testing purposes (or for actual data building)
        public static void Seed1()
        {
            MarketDbContext db = new MarketDbContext();
            List<Category> categories = new List<Category>
            {
                new Category{ Name="Woman",
                    ImageURL="/Image/ImageCategory/banner-2.jpg"},//1
                new Category{ Name="Man",
                ImageURL="/Image/ImageCategory/banner-1.jpg"},//2
                new Category{ Name="Children",
                ImageURL="/Image/ImageCategory/banner-3.jpg"},//3
            };
            db.Category.AddRange(categories);
            List<Product> products = new List<Product>()
            {
                new Product{Name="Bag",Price=150,Stock=1000 },//1
                new Product{Name="Shoes",Price=50,Stock=150 },//2
                new Product{Name="Coat Men",Price=10,Stock=75 },//3
                new Product{Name="Shirts Men",Price=125,Stock=25 },//4
                new Product{Name="Suit",Price=52,Stock=35 },//5
                new Product{Name="Blouse Woman",Price=85,Stock=45 },//6
                new Product{Name="Blouse2 Woman",Price=24,Stock=55 },//7
                new Product{Name="Scarf",Price=25,Stock=75 },//8
                new Product{Name="Hat",Price=35,Stock=35 },//9
                new Product{Name="Sweater",Price=75,Stock=87 },//10
                new Product{Name="Bag Woman",Price=12,Stock=70 },//11
                new Product{Name="Suit Woman",Price=15,Stock=30 },//12
            };
            db.Product.AddRange(products);
            db.SaveChanges();

            List<ProductCategory> productCategories = new List<ProductCategory>
            {
                new ProductCategory{ CategoryId=2,ProductId=1},
                new ProductCategory{ CategoryId=2,ProductId=2},
                new ProductCategory{ CategoryId=2,ProductId=3},
                new ProductCategory{ CategoryId=2,ProductId=4},
                new ProductCategory{ CategoryId=2,ProductId=5},
                new ProductCategory{ CategoryId=1,ProductId=6},
                new ProductCategory{ CategoryId=1,ProductId=7},
                new ProductCategory{ CategoryId=1,ProductId=8},
                new ProductCategory{ CategoryId=1,ProductId=9},
                new ProductCategory{ CategoryId=1,ProductId=10},
                new ProductCategory{ CategoryId=1,ProductId=11},
                new ProductCategory{ CategoryId=1,ProductId=12},
            };
            db.ProductCategory.AddRange(productCategories);
            db.SaveChanges();

            List<ProductImage> productImages = new List<ProductImage>
            {
                new ProductImage{ ProductId=1, ImageURL="/Image/ImageProduct/man-1.jpg"},
                new ProductImage{ ProductId=1, ImageURL="/Image/ImageProduct/product-7.jpg"},
                new ProductImage{ ProductId=2, ImageURL="/Image/ImageProduct/product-9.jpg"},
                new ProductImage{ ProductId=2, ImageURL="/Image/ImageProduct/man-2.jpg"},
                new ProductImage{ ProductId=3, ImageURL="/Image/ImageProduct/man-3.jpg"},
                new ProductImage{ ProductId=4, ImageURL="/Image/ImageProduct/man-4.jpg"},
                new ProductImage{ ProductId=3, ImageURL="/Image/ImageProduct/product-8.jpg"},
                new ProductImage{ ProductId=5, ImageURL="/Image/ImageProduct/man-large.jpg"},
                new ProductImage{ ProductId=6, ImageURL="/Image/ImageProduct/product-1.jpg"},
                new ProductImage{ ProductId=6, ImageURL="/Image/ImageProduct/product-2.jpg"},
                new ProductImage{ ProductId=6, ImageURL="/Image/ImageProduct/women-1.jpg"},
                new ProductImage{ ProductId=6, ImageURL="/Image/ImageProduct/women-2.jpg"},
                new ProductImage{ ProductId=6, ImageURL="/Image/ImageProduct/women-3.jpg"},
                new ProductImage{ ProductId=7, ImageURL="/Image/ImageProduct/product-3.jpg"},
                new ProductImage{ ProductId=8, ImageURL="/Image/ImageProduct/product-4.jpg"},
                new ProductImage{ ProductId=9, ImageURL="/Image/ImageProduct/product-5.jpg"},
                new ProductImage{ ProductId=10,ImageURL="/Image/ImageProduct/product-6.jpg"},
                new ProductImage{ ProductId=11,ImageURL="/Image/ImageProduct/women-4.jpg"},
                new ProductImage{ ProductId=12,ImageURL="/Image/ImageProduct/women-large.jpg"},
            };
            db.ProductImage.AddRange(productImages);
            db.SaveChanges();
        }
    }
}
