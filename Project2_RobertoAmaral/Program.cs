// Project: Project 2
// Author: Roberto Amaral
//  Date: April 11, 2022 

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            //lists
            List<String> Infix = new List<string>();
            List<String> Prefix = new List<string>();
            List<String> Postfix = new List<string>();
            List<double> prefix_res = new List<double>();
            List<double> postfix_res = new List<double>();
            List<bool> match = new List<bool>();

            // csv reader from previous project  
            CSVFile csvreader = new CSVFile();
            Infix = csvreader.CSV_Serialized();
            ExpressionConverter converter = new ExpressionConverter();
            ExpressionEvaluation evaluator = new ExpressionEvaluation();
            CompareExpressions comparer = new CompareExpressions();
            XMLExtension xmlgenerator = new XMLExtension();
            Display_Summary display = new Display_Summary();


            // Infix to prefix and postfix convertion
            for (int i = 1; i < Infix.Count; i++)
            {
                Prefix.Add(converter.Infix_to_Prefix(Infix[i]));
                Postfix.Add(converter.Infix_to_Postfix(Infix[i]));
            }
            // evaluation of prefix and postfix
            for (int i = 0; i < Infix.Count - 1; i++)
            {
                prefix_res.Add(evaluator.evaluate_Prefix(Prefix[i]));
                postfix_res.Add(evaluator.evaluate_Postfix(Postfix[i]));
            }
            // comparision 
            for (int i = 0; i < Infix.Count - 1; i++)
            {
                match.Add(Convert.ToBoolean(comparer.Compare(prefix_res[i], postfix_res[i])));
            }
            // interface
            Console.WriteLine("*******************************************************************************************************");
            Console.WriteLine("*                                          Summary Report                                             *");
            Console.WriteLine("*******************************************************************************************************\n");
            Console.WriteLine("|  Sno|                Infix|          Postfix|           Prefix|  Prefix Res|Postfix Res|  Match|");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            for (int i = 0; i < Infix.Count - 1; i++)
            {
                display.Display_Console(i + 1, Infix[i + 1], Prefix[i], Postfix[i], prefix_res[i], prefix_res[i], match[i]);
            }

            // Xml Generator
            xmlgenerator.xmlwriter(Infix.Count - 1, Infix, Prefix, Postfix, postfix_res, match);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
