using System;
using System.Collections.Generic;

namespace RomanMath.Impl
{
    public static class Service
    {
        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>

        public static int Evaluate(string expression)
        {
            if (String.IsNullOrEmpty(expression))
            {
                throw new ArgumentException("Expression is null or empty");
            }

            string regexItem = "+-*MDCLXVI ";
            if (!regexItem.Contains(expression))
            {
                throw new ArgumentException("Expression has unvalid characters");
            }
                        
            for (var i = 0; i < expression.Length; i++)
            {
                if(expression[i] == '+' || expression[i] == '-' || expression[i] == '*')
                {
                    expression = expression.Insert(i, " ");
                    expression = expression.Insert(i + 2, " ");
                    i++;
                }
            }
            List<string> list = new List<string>();
            char[] separators = new char[] { ' ' };
            string[] subs = expression.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < subs.Length; i++)
            {
                if (subs[i] == "+" || subs[i] == "-" || subs[i] == "*")
                {                   
                    continue;
                }
                subs[i] = ConvertToRoman.SimplerConverter(subs[i]).ToString();
            }
          
            return SolveExpression.PolishMethod(subs);
        }
    }
}
