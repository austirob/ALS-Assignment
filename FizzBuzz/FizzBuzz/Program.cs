using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
               
                for (var i = 1; i <= 100; i++)
                {
                    Console.WriteLine(EvaluateFizzBuzz.Print(i));
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            finally
            {
                Console.ReadLine();

            }


        }
    }
}
