using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Task_1
{
    class Program
    {
        private async static Task WriteToFile(int i, CancellationToken token)
        {
            var path = @$"C:\Users\Admin Admin\source\repos\MishaEtmekchyan\Day_28\Task_1\{i}.txt";
            File.Create(path).Close();
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(100 * i);
                await File.AppendAllTextAsync(path, $"Task{i} ");
            }
        }
        static async Task Main(string[] args)
        {
            var tokenSrc = new CancellationTokenSource();
            List<Task> tasks = new List<Task>(10);
            tasks.Add(Task.Run(() => 
            {
                Console.WriteLine("Stop ?");
                var ans = Console.ReadLine();
                if (ans == "stop")
                {
                    tokenSrc.Cancel();
                }
            }));
            for (int i = 1; i < 10; i++)
            {
                tasks.Add(Task.Run(() => WriteToFile(i, tokenSrc.Token)));
            }

            await Task.WhenAll(tasks);


        }
    }
}
