using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace grammarTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[100];
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("loop in for " + i);
                
                threads[i] = new Thread(() => {
                    Print(i);
                    //Console.WriteLine("  thread name is "+threads[i].Name);
                });
                threads[i].Name = i.ToString();
                threads[i].Start();
            }

        }
        static void Print(int a)
        {
            Console.WriteLine("in thread "+a);
        }
    }
}
