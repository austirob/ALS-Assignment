using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public static class EvaluateFizzBuzz
    {
        public static string Print(int num)
        {

            var mod3 = num % 3;
            var mod5 = num % 5;

            if (mod3 == 0 && mod5 == 0)
            {
                
                return "FizzBuzz";
            }


            if (mod3 == 0)
            {
                return "Fizz";
            }

            if (mod5 == 0)
            {
                return "Buzz";
                
            }

            return num.ToString();
        }
    }
}
