using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a number");
            int nr1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a another number");
            int nr2 = int.Parse(Console.ReadLine());

            do
            {
              
                if (nr1 < nr2)
                {

                    string x = "Hej";
                    string y = "då!";
                    Console.WriteLine(x + y);
                }
                else
                {
                    Console.WriteLine("n1 är inte större än n2");
                }

            } while (nr2 < 2);
            Console.ReadLine();


        }
    }
}

