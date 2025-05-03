﻿using Microsoft.EntityFrameworkCore; // To use Include method.
using Northwind.EntityModels; // To use Northwind, Category, Product.
partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();
        SectionTitle("Categories and how many products they have");
        // A query to get all categories and their related products.
        // This is a query definition. Nothing has executed against the database.
        IQueryable<Category>? categories = db.Categories?
          .Include(c => c.Products);
        // You could call any of the following LINQ methods and nothing will be executed against the database:
        // Where, GroupBy, Select, SelectMany, OfType, OrderBy, ThenBy, Join, GroupJoin, Take, Skip, Reverse.
        // Usually, methods that return IEnumerable or IQueryable support deferred execution.
        // Usually, methods that return a single value do not support deferred execution.
        if (categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }
        // Enumerating the query converts it to SQL and executes it against the database.
        // Execute query and enumerate results.
        foreach (Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        }
    }

    private static void FilteredIncludes()
    {
        using NorthwindDb db = new();
        SectionTitle("Products with a minimum number of units in stock");
        string? input;
        int stock;
        do
        {
            Write("Enter a minimum for units in stock: ");
            input = ReadLine();
        } while (!int.TryParse(input, out stock));
        IQueryable<Category>? categories = db.Categories?
          .Include(c => c.Products.Where(p => p.Stock >= stock));
        if (categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }
        foreach (Category c in categories)
        {
            WriteLine(
              "{0} has {1} products with a minimum {2} units in stock.",
              arg0: c.CategoryName, arg1: c.Products.Count, arg2: stock);
            foreach (Product p in c.Products)
            {
                WriteLine($"  {p.ProductName} has {p.Stock} units in stock.");
            }
        }
    }

    private static void QueryingProducts()
    {
        using NorthwindDb db = new();
        SectionTitle("Products that cost more than a price, highest at top");
        string? input;
        decimal price;
        do
        {
            Write("Enter a product price: ");
            input = ReadLine();
        } while (!decimal.TryParse(input, out price));
        IQueryable<Product>? products = db.Products?
          .Where(product => product.Cost > price)
          .OrderByDescending(product => product.Cost);
        if (products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }

        // Calling ToQueryString does not execute against the database.
        // LINQ to Entities just converts the LINQ query to an SQL statement.
        Info($"ToQueryString: {products.ToQueryString()}");

        foreach (Product p in products)
        {
            WriteLine(
              "{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
              p.ProductId, p.ProductName, p.Cost, p.Stock);
        }
    }

    private static void GettingOneProduct()
    {
        using NorthwindDb db = new();
        SectionTitle("Getting a single product");
        string? input;
        int id;
        do
        {
            Write("Enter a product ID: ");
            input = ReadLine();
        } while (!int.TryParse(input, out id));
        // This query is not deferred because the First method does not return IEnumerable or IQueryable.
        // The LINQ query is immediately converted to SQL and executed to fetch the first product.
        Product? product = db.Products?
          .First(product => product.ProductId == id);
        Info($"First: {product?.ProductName}");
        if (product is null) Fail("No product found using First.");
        product = db.Products?
          .Single(product => product.ProductId == id);
        Info($"Single: {product?.ProductName}");
        if (product is null) Fail("No product found using Single.");
    }

    private static void QueryingWithLike()
    {
        using NorthwindDb db = new();
        SectionTitle("Pattern matching with LIKE");
        Write("Enter part of a product name: ");
        string? input = ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Fail("You did not enter part of a product name.");
            return;
        }
        IQueryable<Product>? products = db.Products?
          .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
        if (products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }
        foreach (Product p in products)
        {
            WriteLine("{0} has {1} units in stock. Discontinued: {2}",
              p.ProductName, p.Stock, p.Discontinued);
        }
    }

    private static void GetProductUsingSql()
    {
        using NorthwindDb db = new();
        SectionTitle("Get product using SQL");
        int? rowCount = db.Products?.Count();
        if (rowCount is null)
        {
            Fail("Products table is empty.");
            return;
        }
        int productId = 1;
        Product? p = db.Products?.FromSql(
          $"SELECT * FROM Products WHERE ProductId = {productId}").FirstOrDefault();
        if (p is null)
        {
            Fail("Product not found.");
            return;
        }
        WriteLine($"Product: {p.ProductId} - {p.ProductName}");
    }
}