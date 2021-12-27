using System;
using System.Collections.Generic;
using System.Linq;
namespace Day_25_Task
{
    class Program
    {
        
        static void Main(string[] args)
        {

            string customersPath = @"C:\Users\Admin Admin\source\repos\MishaEtmekchyan\Day_25\Day_25_Task\Customers.txt";
            string ordersPath = @"C:\Users\Admin Admin\source\repos\MishaEtmekchyan\Day_25\Day_25_Task\Orders.txt";

            var customers = WorkWithDataHelper.GetCustomers(customersPath);

            var orders = WorkWithDataHelper.GetOrders(ordersPath);


            //1
            WorkWithDataHelper.PrintCustomersOrdersAmount(customers,orders);
            Console.WriteLine("-------------------------------------");
            //2
            WorkWithDataHelper.PrintTotalCost(customers,orders);
            Console.WriteLine("-------------------------------------");
            //3
            WorkWithDataHelper.PrintCustomersMinPriceOrder(customers, orders);
            Console.WriteLine("-------------------------------------");
            //4
            WorkWithDataHelper.PrintCustomersWithMoreThan1Order(customers, orders);
            Console.WriteLine("-------------------------------------");
            //5
            WorkWithDataHelper.PrintCustomersWithExpensiveProducts(customers, orders);
            Console.WriteLine("-------------------------------------");
        }
    }
}
