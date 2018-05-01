using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    class Program
    {
        public static int leftOperand, rightOperand, result;
        public static String operation;
        public static String intErrorMsg = 
            "Sorry, it isn't integer number, try another one...";
        public static String operationErrorMsg = 
            "Sorry, it isn't valid operation, try another one (+, -, *, /)...";
        static void Main(string[] args)
        {
            Console.WriteLine("This is simple integer calculator");

            while (true)
            {
                Console.WriteLine("Input two integer operands and arifmetical operation then");

                Console.Write("Left operand: ");
                while (!int.TryParse(Console.ReadLine(), out leftOperand))
                {
                    Console.WriteLine(intErrorMsg);
                }

                Console.Write("Right operand: ");
                while (!int.TryParse(Console.ReadLine(), out rightOperand))
                {
                    Console.WriteLine(intErrorMsg);
                }

                Console.Write("Operation: ");
                while (
                    !(
                        ((operation = Console.ReadLine()) == "+")
                        || (operation == "-")
                        || (operation == "*")
                        || (operation == "/")
                    )
                    )
                {
                    Console.WriteLine(operationErrorMsg);
                }

                switch (operation)
                {
                    case "+":
                        result = leftOperand + rightOperand;
                        break;
                    case "-":
                        result = leftOperand - rightOperand;
                        break;
                    case "*":
                        result = leftOperand * rightOperand;
                        break;
                    case "/":
                        try
                        {
                            result = leftOperand / rightOperand;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                }

                Console.WriteLine(leftOperand + " " + operation + " " + rightOperand + " = " + result);
                Console.WriteLine();
            }
        }
    }
}
