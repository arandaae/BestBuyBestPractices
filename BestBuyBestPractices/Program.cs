using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BestBuyBestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion 

            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            #region DepartmentRepository
            //Console.WriteLine("Hello use, here are the current departments:");
            //Console.WriteLine("Please press enter . . .");
            //Console.ReadLine();

            //var depos = repo.GetAllDepartments();

            //Console.WriteLine("Do you want to add a department?");
            //string userResponse = Console.ReadLine();

            //if (userResponse.ToLower() == "yes")
            //{
            //    Console.WriteLine("What is the name of your new Department?");
            //    userResponse = Console.ReadLine();

            //    repo.InsertDepartment(userResponse);
            //    Print(repo.GetAllDepartments());
            //}

            //Console.WriteLine("Have a great day.");
            #endregion

            IDbConnection conn2 = new MySqlConnection(connString);
            DapperProductRepository repo2 = new DapperProductRepository(conn2);

            repo2.CreateProduct("New product", 9.99, 10);

            var products = repo2.GetAllProducts();

            foreach (var p in products)
            {
                Console.WriteLine(p.ProductID);
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Price);
                Console.WriteLine(p.CategoryID);
                Console.WriteLine(p.OnSale);
                Console.WriteLine(p.StockLevel);
                Console.WriteLine();
            }
        }

        private static void Print(IEnumerable<Department> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentId} Name: {depo.Name}");
            }
        }
    }
}
