using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RomanMath.Impl
{
    public class SolveExpression
    {
        public static int PolishMethod(string[] subs)
        {
            Stack<string> operationStack = new Stack<string>();
            List<string> output = new List<string>();
            foreach (var sub in subs)
            {
                if (sub == "+" || sub == "-" || sub == "*")
                {
                    if(sub == "-" || sub == "+")
                    {
                        while (operationStack.Count > 0 && operationStack.Peek() == "*" )
                        {
                            output.Add(operationStack.Pop());
                        }

                       // operationStack.Push(sub);
                    }

                    operationStack.Push(sub);
                }
                else
                {
                    output.Add(sub);
                }
            }

            while(operationStack.Count > 0)
            {
                output.Add(operationStack.Pop());
            }
            

            Stack<int> integerStack = new Stack<int>();

            foreach (var sub in output)
            {
                if (sub == "+" || sub == "-" || sub == "*")
                {
                    var stack1 = integerStack.Pop();
                    var stack2 = integerStack.Pop();

                    if (sub == "+")
                    {
                        var operation = stack1 + stack2;
                        integerStack.Push(operation);
                    }
                    if (sub == "-")
                    {
                        var operation = stack2 - stack1;
                        integerStack.Push(operation);
                    }
                    if (sub == "*")
                    {
                        var operation = stack2 * stack1;
                        integerStack.Push(operation);
                    }
                    continue;
                }
                integerStack.Push(int.Parse(sub));
            }

            return integerStack.Pop();
        }
    }
}
