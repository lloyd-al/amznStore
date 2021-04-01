using amznStore.Services.Catalog.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace amznStore.Services.Catalog.Infrastructure.DataContexts
{
    public class CatalogDbContextSeed
    {
        public static void SeedData(IMongoCollection<Category> categoryCollection, IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(_ => true).Any();
            bool existCategory = categoryCollection.Find(_ => true).Any();

            if (!existCategory)
            {
                categoryCollection.InsertManyAsync(GetPreconfiguredCategories());
            }

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }

        }

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = "5fd1c039216ec53182903551",
                    CategoryName = "HATS",
                    ImageUrl = "https://i.ibb.co/cvpntL1/hats.png",
                    LinkUrl = "shop/hats"
                },
                new Category()
                {
                    Id = "5fd1c2b6254e375c04f11741",
                    CategoryName = "JACKETS",
                    ImageUrl = "https://i.ibb.co/px2tCc3/jackets.png",
                    LinkUrl = "shop/jackets"
                },
                new Category()
                {
                    Id = "5fd36b7239ac66c6c085343f",
                    CategoryName = "SNEAKERS",
                    ImageUrl = "https://i.ibb.co/0jqHpnp/sneakers.png",
                    LinkUrl = "shop/sneakers"
                },
                new Category()
                {
                    Id = "5fd1c2c907b1a418fdf00ecf",
                    CategoryName = "WOMENS",
                    ImageUrl = "https://i.ibb.co/GCCdy8t/womens.png",
                    LinkUrl = "shop/womens"
                },
                new Category()
                {
                    Id = "5fd1c2d465e529f9befe03f1",
                    CategoryName = "MENS",
                    ImageUrl = "https://i.ibb.co/R70vBrQ/men.png",
                    LinkUrl = "shop/mens"
                }
            };
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                // Hats
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Brown Brim",
                    Category = "5fd1c039216ec53182903551",
                    Summary = "Brown Brim Hat",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/ZYW3VTp/brown-brim.png",
                    VariantDetails = FSVariantList(25)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Blue Beanie",
                    Category = "5fd1c039216ec53182903551",
                    Summary = "Freesize Blue Beanie",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/ypkgK0X/blue-beanie.png",
                    VariantDetails = FSVariantList(18)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Brown Cowboy",
                    Category = "5fd1c039216ec53182903551",
                    Summary = "Brown Cowboy Hat",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/QdJwgmp/brown-cowboy.png",
                    VariantDetails = FSVariantList(35)
                },
            new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Grey Brim",
                    Category = "5fd1c039216ec53182903551",
                    Summary = "Grey Bim Hat",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/RjBLWxB/grey-brim.png",
                    VariantDetails = FSVariantList(25)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Green Beanie",
                    Category = "5fd1c039216ec53182903551",
                    Summary = "Freesie Green Beanie",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/YTjW3vF/green-beanie.png",
                    VariantDetails = FSVariantList(18)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Palm Tree Cap",
                    Category = "5fd1c039216ec53182903551",
                    Summary = "Palm Tree Cap",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/rKBDvJX/palm-tree-cap.png",
                    VariantDetails = FSVariantList(14)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Red Beanie",
                    Category = "5fd1c039216ec53182903551",
                    Summary = "Red Beanie",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/bLB646Z/red-beanie.png",
                    VariantDetails = FSVariantList(18)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Wolf Cap",
                    Category = "5fd1c039216ec53182903551",
                    Summary = "Wolf Cap",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/1f2nWMM/wolf-cap.png",
                    VariantDetails = FSVariantList(14)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Blue Snapback",
                    Category = "5fd1c039216ec53182903551",
                    Summary = "Blue Snapback",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/X2VJP2W/blue-snapback.png",
                    VariantDetails = FSVariantList(16)
                },
                //Sneakers
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "AdIdas NMD",
                    Category = "5fd36b7239ac66c6c085343f",
                    Summary = "New ADIDAS Sneakers for Workout",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/0s3pdnc/adIdas-nmd.png",
                    VariantDetails = ShoeVariantList(220)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "AdIdas Yeezy",
                    Category = "5fd36b7239ac66c6c085343f",
                    Summary = "New ADIDAS Sneakers for Workout",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/dJbG1cT/yeezy.png",
                    VariantDetails = ShoeVariantList(280)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Black Converse",
                    Category = "5fd36b7239ac66c6c085343f",
                    Summary = "New Converse Sneakers for Casual Walk",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/bPmVXyP/black-converse.png",
                    VariantDetails = ShoeVariantList(110)
                },new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Nike White AirForce",
                    Category = "5fd36b7239ac66c6c085343f",
                    Summary = "New Nike Sneakers for Running",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/1RcFPk0/white-nike-high-tops.png",
                    VariantDetails = ShoeVariantList(160)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Nike Red High Tops",
                    Category = "5fd36b7239ac66c6c085343f",
                    Summary = "New Nike Sneakers for Running",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/QcvzydB/nikes-red.png",
                    VariantDetails = ShoeVariantList(160)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Nike Brown High Tops",
                    Category = "5fd36b7239ac66c6c085343f",
                    Summary = "New Nike Sneakers for Running",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/fMTV342/nike-brown.png",
                    VariantDetails = ShoeVariantList(160)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Air Jordan Limited",
                    Category = "5fd36b7239ac66c6c085343f",
                    Summary = "Lastest Sneakers for Regular Exercise",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/w4k6Ws9/nike-funky.png",
                    VariantDetails = ShoeVariantList(190)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Timberlands",
                    Category = "5fd36b7239ac66c6c085343f",
                    Summary = "Lastest Sneakers for Regular Exercise",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/Mhh6wBg/timberlands.png",
                    VariantDetails = ShoeVariantList(200)
                },
                // Jackets
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Black Jean Shearling",
                    Category = "5fd1c2b6254e375c04f11741",
                    Summary = "Designer Jackets for Everyone",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/XzcwL5s/black-shearling.png",
                    VariantDetails = ClothVariantList(125)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Brown Shearling",
                    Category = "5fd1c2b6254e375c04f11741",
                    Summary = "Designer Jackets for Everyone",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/s96FpdP/brown-shearling.png",
                    VariantDetails = ClothVariantList(165)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Designer Jackets for Everyone",
                    Category = "5fd1c2b6254e375c04f11741",
                    Summary = "New Nike Sneakers for Running",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/mJS6vz0/blue-jean-jacket.png",
                    VariantDetails = ClothVariantList(90)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Grey Jean Jacket",
                    Category = "5fd1c2b6254e375c04f11741",
                    Summary = "Designer Jackets for Everyone",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/N71k1ML/grey-jean-jacket.png",
                    VariantDetails = ClothVariantList(105)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Tan Trench",
                    Category = "5fd1c2b6254e375c04f11741",
                    Summary = "Designer Jackets for Everyone",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/M6hHc3F/brown-trench.png",
                    VariantDetails = ClothVariantList(182)
                },
                // Womens
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Blue Tanktop",
                    Category = "5fd1c2c907b1a418fdf00ecf",
                    Summary = "Designer Clothing for Women",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/7CQVJNm/blue-tank.png",
                    VariantDetails = ClothVariantList(25)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Floral Blouse",
                    Category = "5fd1c2c907b1a418fdf00ecf",
                    Summary = "Designer Clothing for Women",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/4W2DGKm/floral-blouse.png",
                    VariantDetails = ClothVariantList(20)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Floral Dress",
                    Category = "5fd1c2c907b1a418fdf00ecf",
                    Summary = "Designer Clothing for Women",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/KV18Ysr/floral-skirt.png",
                    VariantDetails = ClothVariantList(80)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Red Dots Dress",
                    Category = "5fd1c2c907b1a418fdf00ecf",
                    Summary = "Designer Clothing for Women",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/N3BN1bh/red-polka-dot-dress.png",
                    VariantDetails = ClothVariantList(82)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Striped Sweater",
                    Category = "5fd1c2c907b1a418fdf00ecf",
                    Summary = "Designer Clothing for Women",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/KmSkMbH/striped-sweater.png",
                    VariantDetails = ClothVariantList(45)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Yellow Track Suit",
                    Category = "5fd1c2c907b1a418fdf00ecf",
                    Summary = "Designer Clothing for Women",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/v1cvwNf/yellow-track-suit.png",
                    VariantDetails = ClothVariantList(135)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "White Blouse",
                    Category = "5fd1c2c907b1a418fdf00ecf",
                    Summary = "Designer Clothing for Women",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/qBcrsJg/white-vest.png",
                    VariantDetails = ClothVariantList(20)
                },
                //Mens
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Camo Down Vest",
                    Category = "5fd1c2d465e529f9befe03f1",
                    Summary = "Regular Size Menswear",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/xJS0T3Y/camo-vest.png",
                    VariantDetails = ClothVariantList(325)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Floral T-shirt",
                    Category = "5fd1c2d465e529f9befe03f1",
                    Summary = "Regular Size Menswear",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/qMQ75QZ/floral-shirt.png",
                    VariantDetails = ClothVariantList(20)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Black & White Longsleeve",
                    Category = "5fd1c2d465e529f9befe03f1",
                    Summary = "Regular Size Menswear",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/55z32tw/long-sleeve.png",
                    VariantDetails = ClothVariantList(25)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Pink T-shirt",
                    Category = "5fd1c2d465e529f9befe03f1",
                    Summary = "Regular Size Menswear",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/RvwnBL8/pink-shirt.png",
                    VariantDetails = ClothVariantList(32)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Jean Long Sleeve",
                    Category = "5fd1c2d465e529f9befe03f1",
                    Summary = "Regular Size Menswear",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/VpW4x5t/roll-up-jean-shirt.png",
                    VariantDetails = ClothVariantList(40)
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductName = "Burgundy T-shirt",
                    Category = "5fd1c2d465e529f9befe03f1",
                    Summary = "Regular Size Menswear",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageUrl = "https://i.ibb.co/mh3VM1f/polka-dot-shirt.png",
                    VariantDetails = ClothVariantList(25)
                }
            };
        }

        private static List<ProductVariantDetails> ClothVariantList(decimal price)
        {
            List<ProductVariantDetails> variantList = new List<ProductVariantDetails>();
            variantList.Add(new ProductVariantDetails() { Variant = "xs", Price = price});
            variantList.Add(new ProductVariantDetails() { Variant = "s", Price = price });
            variantList.Add(new ProductVariantDetails() { Variant = "m", Price = price });
            variantList.Add(new ProductVariantDetails() { Variant = "l", Price = price });
            variantList.Add(new ProductVariantDetails() { Variant = "xl", Price = price });
            variantList.Add(new ProductVariantDetails() { Variant = "xxl", Price = price });

            return variantList;
        }

        private static List<ProductVariantDetails> ShoeVariantList(decimal price)
        {
            List<ProductVariantDetails> variantList = new List<ProductVariantDetails>();
            variantList.Add(new ProductVariantDetails() { Variant = "6", Price = price });
            variantList.Add(new ProductVariantDetails() { Variant = "7", Price = price });
            variantList.Add(new ProductVariantDetails() { Variant = "8", Price = price });
            variantList.Add(new ProductVariantDetails() { Variant = "9", Price = price });
            variantList.Add(new ProductVariantDetails() { Variant = "10", Price = price });
            return variantList;
        }

        private static List<ProductVariantDetails> FSVariantList(decimal price)
        {
            List<ProductVariantDetails> variantList = new List<ProductVariantDetails>();
            variantList.Add(new ProductVariantDetails() { Variant = "fs", Price = price });
            return variantList;
        }
    }
}
