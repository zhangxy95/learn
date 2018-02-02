using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var alphabet = new Stack<char>();
            alphabet.Push('A');
            alphabet.Push('B');
            alphabet.Push('C');

            Console.Write("First iteration:");
            foreach (char item in alphabet)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Console.Write("Second iteration:");
            while (alphabet.Count>0)
            {
                Console.Write(alphabet.Pop());
            }

            Console.ReadKey();
        }
    }
}
