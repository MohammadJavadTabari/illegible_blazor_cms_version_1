﻿using KernelLogic.DataBaseObjects.Entities;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;

namespace illShop.Shared.BasicServices
{
    public static class ProductQueryableExtensions
    {
        public static IQueryable<Product> Search(this IQueryable<Product> data, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return data;
            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();
            return data.Where(p => p.ProductName.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<Product> Sort(this IQueryable<Product> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return data.OrderBy(e => e.ProductName);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name
                .Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return data.OrderBy(e => e.ProductName);

            return data.OrderBy(orderQuery);
        }
    }
   
    public static class ProductCategoryQueryableExtensions
    {
        public static IQueryable<ProductCategory> Search(this IQueryable<ProductCategory> data, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return data;
            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();
            return data.Where(p => p.CategoryName.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<ProductCategory> Sort(this IQueryable<ProductCategory> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return data.OrderBy(e => e.CategoryName);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name
                .Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return data.OrderBy(e => e.CategoryName);

            return data.OrderBy(orderQuery);
        }
    }
   
    public static class PostQueryableExtensions
    {
        public static IQueryable<BlogPost> Search(this IQueryable<BlogPost> data, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return data;
            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();
            return data.Where(p => p.Title.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<BlogPost> Sort(this IQueryable<BlogPost> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return data.OrderBy(e => e.Title);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name
                .Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return data.OrderBy(e => e.Title);

            return data.OrderBy(orderQuery);
        }
    }
}
