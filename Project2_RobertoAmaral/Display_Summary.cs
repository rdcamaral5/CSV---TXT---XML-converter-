// Project: Project 2
// Author: Roberto Amaral
//  Date: April 11, 2022 

namespace Project2
{
    public class Display_Summary
    {
        // Fuction to Display the Report
        public void Display_Console(int sno, String Infix, String Prefix, String Postfix, double prefix_res, double postfix_res, bool match)
        {
            Console.WriteLine("| {0,4}| {1,20}|  {2,15}|  {3,15}|  {4,10}| {5,10}|  {6,5}|", sno, Infix, Postfix, Prefix, prefix_res, postfix_res, match);
        }
    }
}
