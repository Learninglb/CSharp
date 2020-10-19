using System;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;

namespace MyFirstConsoleApp
{
    class Program
    {


        static void Main(string[] args)
        {
            OperatorExamples();
            TryAnIf();
            TrySomeLoops();
            TryAnIfElse();
        }


        private static void OperatorExamples()
        {
            // This statement declares a variable and sets it to 3
            int width = 3;
            
            //the ++ operator increments a variable (adds 1 to it)
            width++;
            
            //Declare two more int variables to hold numbers and 
            //use the + and * operators to add and multiply values
            int height = 2 + 4;
            int area = width * height;
            Console.WriteLine(area);
            
            //The next two statements declare string variables
            //and use + to concatenate them (join them together)
            string result = "The area";
            result = result + " is " + area;

            while (area < 50)
            {
                height++;
                area = width * height;
            }

            do
            {
                width--;
                area = width * height;
            } while (area > 25);
            
            Console.WriteLine(result);
            
            //A boolean variable is either true or false
            bool truthValue = true;
            Console.WriteLine(truthValue);
        }

        private static void TryAnIf()
        {
            int someValue = 3;
            string name = "Joe";
            if ((someValue == 3) && (name == "Joe"))
            {
                Console.WriteLine("x is 3 and the name is Joe");
            }
            Console.WriteLine("this line runs no matter the condition");
        }

        private static void TrySomeLoops()
        {
            int count = 0;
            while (count < 10)
            {
                count = count + 1;
            }

            for (int i = 0; i < 5; i++)
            {
                count = count - 1;
            }
            Console.WriteLine("The answer is " + count);
        }
        
        private static void TryAnIfElse()
        {
            int x = 5;
            if (x == 10)
            {
                Console.WriteLine("x must be 10");
            }
            else
            {
                Console.WriteLine("x is not 10");
            }
        }
        
    }
    
    
    
    
}
