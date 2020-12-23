using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace interview_questions.geeks4geeks.Strings
{
    class StringSegmentation
    {
        public static void Test()
        {

            var stopwatch = new Stopwatch();
            stopwatch.Start();
                
            
            // Assert("apple pear onion pie", "applepeer", false);
            // Assert("apple pear onion pie", "applepie", true);
            // Assert("apple pear onion pie", "pieapple", true);
            //Assert("apple pear onion pie", "pieapplepieapplepieapplepieapplepieapplepieapplepieapplepieapplepieapplepieapple", true); // 10 chars = 37msec, 20 = 39msec, 30 = 385ms (39), 33=1768ms, 40 = 2min (57ms) 80 = 110ms?
            Assert("apple pear onion pie", "pieapplepieapplepieaprplepieapplepieapplepieapplepieapplepieapplepieapplepieapplepieapplepieappleptieapplepieapplepieapplepieapplepieapplepieapplepieapplepieapple", true); // 10 chars = 37msec, 20 = 39msec, 30 = 385ms (39), 33=1768ms, 40 = 2min (165ms) 80 = 143ms?

            stopwatch.Stop();
            Console.WriteLine($"It took {stopwatch.Elapsed.TotalSeconds} seconds.");
        }

        private static void Assert(string dictionaryString, string input, bool expected)
        {
            var dict = dictionaryString.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToHashSet();

            var cache = new Dictionary<string, bool>();
            
            var actual = AllWordsInDictionary(input, dict, cache);
            if (actual != expected)
            {
                Console.WriteLine($"for input '{input}' and dict '{dictionaryString}' expected {expected} actual {actual}");
            }
            
        }

        private static bool AllWordsInDictionary(string input, HashSet<string> dict, Dictionary<string, bool> cache)
        {
            // applepie
            // return true if leftSide can be slit to words from dict and right side

            if (cache.TryGetValue(input, out var result))
                return result;
            
            if (input.Length == 0)
                result = true;
            else if (dict.Contains(input))
                result = true;
            else if (input.Length == 1)
                result = false;
            else
            {
                result = false;

                for (var i = 1; i < input.Length - 1; i++)
                {
                    var left = input[..i];
                    var right = input[i..];

                    // left = a
                    // right = pplepie
                    // i = 2
                    // left = ap
                    // right = plepie
                    // i = 3
                    // left = app
                    // right = lepie
                    // i = 4
                    // left = appl
                    // right = epie
                    // i = 5
                    // left = apple
                    // right = pie


                    if (AllWordsInDictionary(left, dict, cache) && AllWordsInDictionary(right, dict, cache))
                    {
                        result = true;
                        break;
                    }
                }
            }

            cache[input] = result;

            return result;
            // big O notation
            // 2**N optimized to N**2
        }
    }
}
