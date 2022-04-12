
using System.Collections;
using System.Linq.Expressions;

// Project: Project 2
// Author: Roberto Amaral
//  Date: April 11, 2022 

namespace Project2
{
    public class ExpressionEvaluation
    {


        // check if operand or not
        private static Boolean isOperand(char c)
        {
            if (c >= 48 && c <= 57)
                return true;
            else
                return false;
        }

        //expression trees
        private static Expression<Func<double, double, double>> addition = (num1, num2) => num1 + num2;
        private Func<double, double, double> add = addition.Compile();
        private static Expression<Func<double, double, double>> subtraction = (num1, num2) => num1 - num2;
        private Func<double, double, double> sub = subtraction.Compile();
        private static Expression<Func<double, double, double>> multtiplication = (num1, num2) => num1 * num2;
        private Func<double, double, double> mul = multtiplication.Compile();
        private static Expression<Func<double, double, double>> division = (num1, num2) => num1 / num2;
        private Func<double, double, double> div = division.Compile();

        // Fuction to evaluate value of  a prefix expression 
        public double evaluate_Prefix(String expression)
        {
            Stack<Double> Stack = new Stack<Double>();
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                if (isOperand(expression[i]))
                    Stack.Push((double)(expression[i] - 48));
                else
                {
                    double o1 = Stack.Peek();
                    Stack.Pop();
                    double o2 = Stack.Peek();
                    Stack.Pop();
                    switch (expression[i])
                    {
                        case '+':
                            Stack.Push(add(o1, o2));
                            break;
                        case '-':
                            Stack.Push(sub(o1, o2));
                            break;
                        case '*':
                            Stack.Push(mul(o1, o2));
                            break;
                        case '/':
                            Stack.Push(div(o1, o2));
                            break;
                    }
                }
            }
            return Stack.Peek();
        }
        // Fuction to evaluate value of  a postfix expression 
        public double evaluate_Postfix(string exprsn)
        {
            string v, answer;
            v = exprsn;
            Stack stack = new Stack();
            double a, b, ans;
            for (int i = 0; i < v.Length; i++)
            {
                String c = v.Substring(i, 1);
                if (c.Equals("*"))
                {
                    String sa = stack.Pop().ToString();
                    String sb = stack.Pop().ToString();
                    a = Convert.ToDouble(sb);
                    b = Convert.ToDouble(sa);
                    ans = a * b;
                    stack.Push(ans.ToString());

                }
                else if (c.Equals("/"))
                {
                    String sa = stack.Pop().ToString();
                    String sb = stack.Pop().ToString();
                    a = Convert.ToDouble(sb);
                    b = Convert.ToDouble(sa);
                    ans = a / b;
                    stack.Push(ans.ToString());
                }
                else if (c.Equals("+"))
                {
                    String sa = stack.Pop().ToString();
                    String sb = stack.Pop().ToString();
                    a = Convert.ToDouble(sb);
                    b = Convert.ToDouble(sa);
                    ans = a + b;
                    stack.Push(ans.ToString());

                }
                else if (c.Equals("-"))
                {
                    String sa = stack.Pop().ToString();
                    String sb = stack.Pop().ToString();
                    a = Convert.ToDouble(sb);
                    b = Convert.ToDouble(sa);
                    ans = a - b;
                    stack.Push(ans.ToString());

                }
                else
                {
                    stack.Push(v.Substring(i, 1));
                }
            }
            answer = stack.Pop().ToString();
            return Convert.ToDouble(answer);
        }
    }
}
