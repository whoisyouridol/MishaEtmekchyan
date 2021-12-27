using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_25_Task
{
    public static class WorkWithDataHelper
    {
        public static void PrintCustomersOrdersAmount(List<Customer> customers, List<Order> orders)
        {
            var customersOrdersAmount = customers
                .Select(cust => new
                {

                    cust.CustomerID,
                    ordersAmount = orders.Where(ord => ord.CustomerID == cust.CustomerID).Count()

                });

            foreach (var item in customersOrdersAmount)
            {
                Console.Write($"Customer ID : {item.CustomerID} ");
                Console.WriteLine($"Order amount : {item.ordersAmount}");
            }
        }

        

        public static void PrintTotalCost(List<Customer> customers, List<Order> orders)
        {
            var totalCost = customers.Select(cust => new
            {
                cust.CustomerID,
                SumPrice = orders.Where(ord => ord.CustomerID == cust.CustomerID).Sum(x => x.Price)
            });
            foreach (var item in totalCost)
            {
                Console.Write($"Customer ID : {item.CustomerID} ");
                Console.WriteLine($"Total sum : {item.SumPrice}");
            }
        }


        public static void PrintCustomersMinPriceOrder(List<Customer> customers, List<Order> orders)
        {
            var minPrice = customers.Select(cust => new
            {
                cust.CustomerID,
                MinPrice = orders.Where(ord => ord.CustomerID == cust.CustomerID).Min(x => x.Price)
            });
            foreach (var item in minPrice)
            {
                Console.Write($"Customer ID : {item.CustomerID} ");
                Console.WriteLine($"Minimum order`s price : {item.MinPrice}");
            }
        }


        public static void PrintCustomersWithMoreThan1Order(List<Customer> customers, List<Order> orders)
        {
            var morethan10 = customers.Select(y => new
            {
                Customer = y,
                NumOrders = orders.Count(x => x.CustomerID == y.CustomerID)

            }).Where(x => x.NumOrders > 1);


            foreach (var item in morethan10)
            {
                Console.WriteLine("Customer id : " + item.Customer.CustomerID);
                Console.WriteLine("Num orders : " + item.NumOrders);
            }
        }


        public static void PrintCustomersWithExpensiveProducts(List<Customer> customers, List<Order> orders)
        {
            var expensive = customers.Select(y => new
            {
                Customer = y,
                Orders = orders.Where(x => x.CustomerID == y.CustomerID)

            }).Where(x => x.Orders.Average(ord => ord.Price) > 10);
            foreach (var item in expensive)
            {
                Console.WriteLine("Customer with expensive orders : " + item.Customer.CustomerName);
            }
        }
        public static List<Customer> GetCustomers(string path)
        {
            using StreamReader sr = new StreamReader(path);
            List<string> strings = new List<string>();
            while (!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }

            var result = new List<Customer>();

            foreach (var el in strings)
            {
                var splited = el.Split('|').ToList();
                result.Add(new Customer 
                {
                    CustomerID = Convert.ToInt32(splited[0]),
                    CustomerName = splited[1]

                });
                
            }
            return result;
        }

        public static List<Order> GetOrders(string path)
        {
            using StreamReader sr = new StreamReader(path);
            List<string> strings = new List<string>();
            while (!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }

            var result = new List<Order>();

            foreach (var el in strings)
            {
                var splited = el.Split('|').ToList();
                result.Add(new Order
                {
                    OrderID = Convert.ToInt32(splited[0]),
                    Date = splited[1],
                    Product = splited[2],
                    Price = Convert.ToDouble(splited[3]),
                    CustomerID = Convert.ToInt32(splited[4]),

                }) ;

            }
            return result;
        }
    }
}
