﻿using Shop.API.Entities;
using Shop.Models.Dtos;

namespace Shop.API.Extensions
{
    /// <summary>
    /// Provides extension methods for converting entities to DTOs.
    /// </summary>
    public static class DtoConversions
    {
        /// <summary>
        /// Converts a collection of Product entities to ProductDto objects.
        /// </summary>
        /// <param name="products">The collection of Product entities to convert.</param>
        /// <param name="productCategories">The collection of ProductCategory entities to use for category information.</param>
        /// <returns>A collection of ProductDto objects.</returns>
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products,
            IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.Name
                    }).ToList();
        }

        /// <summary>
        /// Converts a collection of User entities to UserDto objects.
        /// </summary>
        /// <param name="users">The collection of User entities to convert.</param>
        /// <returns>A collection of UserDto objects.</returns>
        public static IEnumerable<UserDto> ConvertToDto(this IEnumerable<User> users)
        {
            return (from user in users
                    select new UserDto
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Admin = user.Admin,
                    }).ToList();
        }
    }
}