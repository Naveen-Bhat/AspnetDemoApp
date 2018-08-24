using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpDemoApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var task = Task.Factory.StartNew(async () => Console.WriteLine(await GetData()));

            // This wait, doesn't have a useful effect here.
            task.Wait(); 
            // but this does: var t = GetData(); t.Wait(); Now we are synchronously waiting for the internal async call.

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        //public static int GetData()
        //{
        //    Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId);
        //    Thread.Sleep(1000 * 3);
        //    Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId);
        //    return 100;
        //}

        public static async Task<int> GetData()
        {
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000 * 3);
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId);
            return 100;
        }
    }
}
