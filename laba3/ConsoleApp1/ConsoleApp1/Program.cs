using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace WholesaleStoreSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int clerkCount = 3; // Количество клерков
            int maxCustomersPerClerk = 6; // Максимальное количество клиентов на каждого клерка
            int simulationTime = 480; // Общее время моделирования (в секундах)

            List<Customer> buffer = new List<Customer>(); // Буфер клиентов
            List<Clerk> clerks = new List<Clerk>(); // Список клерков

            // Создание клерков
            for (int i = 0; i < clerkCount; i++)
            {
                clerks.Add(new Clerk(maxCustomersPerClerk));
            }

            int totalOrders = 0; // Общее количество заказов
            int processedOrders = 0; // Количество обработанных заказов
            int unprocessedOrders = 0; // Количество необслуженных заказов
            double totalWaitingTime = 0; // Суммарное время ожидания клиентов

            Random random = new Random();

            // Основной цикл моделирования
            for (int time = 0; time < simulationTime; time++)
            {
                // Обработка заказов клерками
                foreach (Clerk clerk in clerks)
                {
                    clerk.ServeCustomers();
                }

                // Приход новых клиентов
                if (random.NextDouble() < (1.0 / 120))
                {
                    Customer newCustomer = GenerateNewCustomer(random);
                    if (clerks.Count > 0 && clerks[0].CustomersCount < maxCustomersPerClerk)
                    {
                        clerks[0].AddCustomer(newCustomer);
                    }
                    else
                    {
                        buffer.Add(newCustomer);
                    }
                    totalOrders++;
                }

                // Обработка клиентов в буфере
                for (int i = 0; i < buffer.Count; i++)
                {
                    if (clerks.Count > 0 && clerks[0].CustomersCount < maxCustomersPerClerk)
                    {
                        clerks[0].AddCustomer(buffer[i]);
                        buffer.RemoveAt(i);
                        i--;
                    }
                }

                // Статистика
                processedOrders += clerks[0].ProcessedOrders;
                totalWaitingTime += clerks[0].TotalWaitingTime;
                unprocessedOrders += buffer.Count;
            }

            // Вывод результатов
            Console.WriteLine($"Общее количество заказов: {totalOrders}");
            Console.WriteLine($"Количество обработанных заказов: {processedOrders}");
            Console.WriteLine($"Количество необслуженных заказов: {unprocessedOrders}");
            Console.WriteLine($"Среднее время пребывания клиента в магазине: {totalWaitingTime / processedOrders} сек");

            foreach (Clerk clerk in clerks)
            {
                Console.WriteLine($"Загруженность клерка #{clerks.IndexOf(clerk) + 1}: {clerk.CustomersCount} клиентов");
            }

            Console.WriteLine($"Среднее число заказов, удовлетворяемых за один выход на склад: {processedOrders / (double)clerkCount}");

            Console.ReadLine();
        }

        static Customer GenerateNewCustomer(Random random)
        {
            double timeToWarehouse = random.NextDouble() * (1.5 - 0.5) + 0.5;
            int orderCount = random.Next(1, 7);
            double searchTimeMean = orderCount * 3;
            double searchTimeStandardDeviation = 0.2 * searchTimeMean;
            double searchTime = random.NextDouble(searchTimeMean, searchTimeStandardDeviation);
            double timeFromWarehouse = random.NextDouble() * (1.5 - 0.5) + 0.5;
            double calculationTime = random.NextDouble() * (3 - 1) + 1;

            return new Customer(timeToWarehouse, searchTime, timeFromWarehouse, calculationTime);
        }
    }

    class Customer
    {
        public double TimeToWarehouse { get; set; }
        public double SearchTime { get; set; }
        public double TimeFromWarehouse { get; set; }
        public double CalculationTime { get; set; }

        public Customer(double timeToWarehouse, double searchTime, double timeFromWarehouse, double calculationTime)
        {
            TimeToWarehouse = timeToWarehouse;
            SearchTime = searchTime;
            TimeFromWarehouse =
