using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Project: Project 2
// Author: Roberto Amaral
//  Date: April 11, 2022 

namespace Project2
{
    class CompareExpressions : IComparer<double>
    {
        //returns 1 or 0 if the expression is true or false
        public int Compare(double x, double y)
        {
            return Convert.ToInt32(x.Equals(y));
        }
    }
}
