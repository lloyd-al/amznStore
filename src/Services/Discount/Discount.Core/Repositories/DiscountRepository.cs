using amznStore.Services.Discount.Core.Entities;
using amznStore.Services.Discount.Core.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amznStore.Services.Discount.Core.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Coupon> GetDiscount(string categoryName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("NpgSql"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE CategoryName = @CategoryName", new { CategoryName = categoryName });

            if (coupon == null)
                return new Coupon { CategoryName = "No Discount", Discount = 0 };
            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("NpgSql"));

            var affected =
                await connection.ExecuteAsync
                    ("INSERT INTO Coupon (CategoryName, Discount, Amount) VALUES (@CategoryName, @Discount, @ValidTill)",
                            new { CategoryName = coupon.CategoryName, Discount = coupon.Discount, ValidTill = coupon.ValidTill });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("NpgSql"));

            var affected = await connection.ExecuteAsync
                    ("UPDATE Coupon SET CatgeryName=@CategoryName, Discount = @Discount, ValidTill = @ValidTill WHERE Id = @Id",
                            new { CategoryName = coupon.CategoryName, Discount = coupon.Discount, ValidTill = coupon.ValidTill, Id = coupon.Id });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDiscount(string categoryName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("NpgSql"));

            var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE CategoryName = @CategoryName",
                new { CategoryName = categoryName });

            if (affected == 0)
                return false;

            return true;
        }
    }
}
