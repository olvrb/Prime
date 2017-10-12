using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Numerics;

namespace Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Delete("PrimeNumbers.txt");
            init:
            Console.WriteLine("Where do you want to write the prime numbers and factors? (txt or console)");
            string whereToWrite = Console.ReadLine();
            if (whereToWrite != "txt" && whereToWrite != "console")
            {
                Console.WriteLine("txt or console?");
                Thread.Sleep(5000);
                Console.Clear();
                goto init;
            }
            BigInteger number = 0;
            BigInteger i = 2;
            BigInteger primeNumberNum = 0;
            while (true)
            {
                i++;
                bool isPrime = true; // Move initialization to here
                for (long j = 2; j < i; j++) // you actually only need to check up to sqrt(i)
                {
                    if (i % j == 0) // you don't need the first condition
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {                                                                                          //~~ TODO fix delete error with NonPrimeNumbers.txt (line 18)~~ 
                    if (whereToWrite == "txt")
                    {
                        using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter("PrimeNumbers.txt", true))
                        {
                            file.WriteLine("Prime Number " + primeNumberNum + ": " + i);
                        }
                    }
                    else if (whereToWrite == "console")
                    {
                        Console.WriteLine("Prime Number " + primeNumberNum + ": " + i);
                        Console.WriteLine(" ");
                    }
                    primeNumberNum++;
                }
                else if (true != IsPrime(i))
                {
                    if (whereToWrite == "txt")
                    {
                        NonPrimeFile.WriteLine(i + " with factors: ");
                        NonPrimeFile.WriteLine(ifPrimeFactors(i, whereToWrite));             //write to txt, 2.0 final
                        NonPrimeFile.WriteLine(" ");
                    }
                    else if (whereToWrite == "console")
                    { 
                        Console.WriteLine(i + " with factors: ");
                        Console.WriteLine(ifPrimeFactors(i, whereToWrite));
                        Console.WriteLine(" ");
                    }
                }

            }
        }
        
        public static System.IO.StreamWriter NonPrimeFile = new System.IO.StreamWriter("NonPrimeNumbers.txt", false);

        public static string ifPrimeFactors(BigInteger number, string whereToWrite)
        {
            for (int i = 2; i < (number); i++)
            {
                if (IsPrime(i))
                {
                    while (number % i == 0)
                    {
                        number /= i;
                        if (whereToWrite == "txt")
                        {
                            NonPrimeFile.WriteLine(i);
                        }
                        else
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
            }
            return number.ToString();
        }

        public static bool IsPrime(BigInteger number)
        {
            if (number % 2 == 0 && number != 2) { return false; }

            bool isPrime = true; // Move initialization to here
            for (long j = 3; j < number; j += 2) // you actually only need to check up to sqrt(i)
            {
                if (number % j == 0) // you don't need the first condition
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
    }
}
