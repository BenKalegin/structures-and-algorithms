using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.StacksQueues
{
    class ParenthesisChecker
    {
        //Given an expression string exp. Examine whether the pairs and the orders of “{“,”}”,”(“,”)”,”[“,”]” are correct in exp.
        // For example, the program should print 'balanced' for exp = “[()]{}{[()()] ()
        // }” and 'not balanced' for exp = “[(])”
        public static void Test()
        {
            AssertResult("{([])}", true);
            AssertResult("()", true);
            AssertResult("([]", false);
            AssertResult("[()]{}{[()()]()}", true);
        }

        public static void Main1()
        {
            var numberOfTestCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < 3; i++)
            {
                var testCase = Console.ReadLine();
                Console.WriteLine(IsBalanced(testCase) ? "balanced" : "not balanced");
            }
        }

        private static void AssertResult(string exp, bool expected)
        {
            var actual = IsBalanced(exp);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static Dictionary<char, char> bracketPairs = new Dictionary<char, char>
        {
            ['{'] = '}',
            ['['] = ']',
            ['('] = ')'
        };

        private static bool IsBalanced(string exp)
        {

            var seen = new Stack<char>();
            foreach (char c in exp)
            {
                switch (c)
                {
                    case '{':
                    case '[':
                    case '(':
                        seen.Push(c);
                        break;
                    
                    case '}':
                    case ']':
                    case ')':
                        if (!seen.Any())
                            return false;
                        var openBracket = seen.Pop();
                        if (bracketPairs[openBracket] != c)
                            return false;
                        break;
                    default:
                        throw new Exception($"Unexpected char: {c}");
                }
            }

            return !seen.Any();
        }
    }
}
