using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foundation
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallerWithAsync();
            //CallerWithContinuationTask();
            //MultipleAsyncMethods();
            MultipleAsnycMethodsWithCombinators1();
            Console.ReadKey();
        }

        static string Greeting(string name)
        {
            Thread.Sleep(3000);
            return string.Format("hello,{0}", name);
        }
        static Task<string> GreetingAsync(string name)
        {
            return Task.Run<string>(() =>
            {
                return Greeting(name);
            });
        }

        private async static void CallerWithAsync()
        {
            string result = await GreetingAsync("Stephanie");
            Console.WriteLine(result);
            
        }

        private static void CallerWithContinuationTask()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            t1.ContinueWith(t =>
            {
                string result = t.Result;
                Console.WriteLine(result);
            });
        }

        private async static void MultipleAsyncMethods()
        {
            string s1 = await GreetingAsync("Stephanie");
            string s2 = await GreetingAsync("Mark");

            Console.WriteLine("finished both method. \n" + "Result 1:{0} 2:{1}", s1, s2);
        }

        private async static void MultipleAsnycMethodsWithCombinators1()
        {
            Task<string> t1 = GreetingAsync("Ann");
            Task<string> t2 = GreetingAsync("Mark");

            await Task.WhenAll(t1, t2);
            Console.WriteLine("finished both method. \n" + "Result 1:{0} 2:{1}", t1.Result, t2.Result);
        }
    }
}
