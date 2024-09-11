using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input = "There are 4 numbers in this string: 40.6, 30, and 10 11.555";

            int[] intNumbers = GetNumbers<int>(input).ToArray();
            double[] doubleNumbers = GetNumbers<double>(input).ToArray();
            Console.WriteLine(string.Join(",", doubleNumbers));
            Console.ReadLine();
        }




        private static IEnumerable<T> GetNumbers<T>(string input) where T : struct, IComparable, IFormattable, IConvertible
        {
            List<T> numbers = [];

            ReadOnlySpan<char> span = input.AsSpan();
            int startIndex = 0;

            while (startIndex < span.Length)
            {
                int endIndex = span.Slice(startIndex).IndexOfAny(',', ' ');

                if (endIndex == -1)
                {
                    endIndex = span.Length;
                }
                else
                {
                    endIndex += startIndex;
                }

                var numberSpan = span.Slice(startIndex, endIndex - startIndex);

                if (numberSpan.Length > 0)
                {
                    T number;
                    if (typeof(T) == typeof(int))
                    {
                        if (int.TryParse(numberSpan, out var intValue))
                        {
                            number = (T)(object)intValue;
                            numbers.Add(number);
                        }
                    }
                    else if (typeof(T) == typeof(double))
                    {
                        if (double.TryParse(numberSpan, out var doubleValue))
                        {
                            number = (T)(object)doubleValue;
                            numbers.Add(number);
                        }
                    }
                }

                startIndex = endIndex + 1;
            }

            return numbers;
        }
    }

    
}
