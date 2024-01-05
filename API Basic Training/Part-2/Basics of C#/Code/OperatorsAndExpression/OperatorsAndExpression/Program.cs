using System;
namespace OperatorsAndExpression;

class OperatorsAndExpression
{
    static void Main(string[] args)
    {
        //Arithmetic Operators

        int a = 10;
        int b = 20;
        Console.WriteLine("Arithmetic Operators......");
        Console.WriteLine("{0} + {1} = {2} " ,a , b, (a+b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b)); 
        Console.WriteLine("a / b = " + (a / b));
        Console.WriteLine("a % b = " + (a % b));
        Console.WriteLine("a++ = " + (a++));
        Console.WriteLine("++a = " + (++a));
        Console.WriteLine("b-- = " + (b--));
        Console.WriteLine("--b = " + (--b));


        //Assignment Operators
        int c = 5;
        Console.WriteLine("Assignment Operators.....");
        Console.WriteLine("c = "+c);
        Console.WriteLine("c+=5 =>" + (c += 5));
        Console.WriteLine("c-=5 =>" + (c -= 5));
        Console.WriteLine("c*=5 =>" + (c *= 5));
        Console.WriteLine("c/=5 =>" + (c /= 5));
        Console.WriteLine("c%=5 =>" + (c %= 5));
        Console.WriteLine("c&=5 =>" + (c &= 5));
        Console.WriteLine("c|=5 =>" + (c |= 5));
        Console.WriteLine("c^=5 =>" + (c ^= 5));
        Console.WriteLine("c>>=5 =>" + (c >>= 5));
        Console.WriteLine("c<<=5 =>" + (c <<= 5));



        //Comparision Operators
        int i = 5 , j = 10 , k = 0 ;


    }
}
