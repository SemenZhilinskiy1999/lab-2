using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            double x0, xn, xnp1, e;
          
            e = 0.001;
            x0 = 2;
            xn = x0 - (Math.Pow(x0, 2)-2)/(2*x0) ;
            xnp1 = xn - (Math.Pow(xn, 2)-2)/(2*xn);


            while (xn - xnp1 >= e)
            {
                xn = xnp1;
                xnp1 = xn - (Math.Pow(xn, 2)-2) / (2 * xn);
 
            }

            Console.WriteLine("{0:0.000}", xnp1);
        }
    }
}
