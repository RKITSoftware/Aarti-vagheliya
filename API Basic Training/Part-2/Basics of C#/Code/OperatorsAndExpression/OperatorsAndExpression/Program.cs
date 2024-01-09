using System;

namespace OperatorsAndExpression;

class OperatorsAndExpression
{
    /// <summary>
    /// Class demonstrating various operators and expressions in C#.
    /// </summary>
    static void Main(string[] args)
    {
        //Arithmetic Operators

        int a = 10;
        int b = 20;
        Console.WriteLine("Arithmetic Operators......");
        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));
        Console.WriteLine("a / b = " + (a / b));
        Console.WriteLine("a % b = " + (a % b));
        Console.WriteLine();



        //Assignment Operators
        int c = 5;
        Console.WriteLine("Assignment Operators.....");
        Console.WriteLine("c = " + c);
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
        Console.WriteLine();


        //Comparision Operators
        int i = 5, j = 10;
        Console.WriteLine("Comparision Operator.......");
        Console.WriteLine("{0} > {1} = {2} ", i, j, (i > j));
        Console.WriteLine("{0} < {1} = {2} ", i, j, (i < j));
        Console.WriteLine("{0} >= {1} = {2} ", i, j, (i >= j));
        Console.WriteLine("{0} <= {1} = {2} ", i, j, (i <= j));
        Console.WriteLine("{0} == {1} = {2} ", i, j, (i == j));
        Console.WriteLine("{0} != {1} = {2} ", i, j, (i != j));
        Console.WriteLine();

        //Logical Operators
        Console.WriteLine("Logical Operators.....");
        Console.WriteLine("i>6 && i <10 = " + (i > 6 && i < 10));
        Console.WriteLine("i>6 || i <10 = " + (i > 6 || i < 10));
        Console.WriteLine("!(i>6 && i <10) = " +!(i > 6 && i< 10));
        Console.WriteLine();


        //Unary Operators
        Console.WriteLine("Unary Operators.....");
        Console.WriteLine("+{0} = {1}" ,a , (+a));
        Console.WriteLine("-{0} = {1}", a, (-a));
        Console.WriteLine("{0}++ = {1} " ,a, (a++));
        Console.WriteLine("++{0} = {1} ", a, (++a));
        Console.WriteLine("{0}-- = {1} ", b, (b--));
        Console.WriteLine("--{0} = {1} " ,b, (--b));
        Console.WriteLine();


        //Ternary Operator
        int number = 10;
        string result;

        Console.WriteLine("Ternary Operator....");
        result = (number % 2 == 0) ? "Even Number" : "Odd Number";
        Console.WriteLine("{0} is {1}", number, result);
        Console.WriteLine();



        //Bitwise operator
        int p = 1, r = 2;
        Console.WriteLine("Bitwise Operator....");
        Console.WriteLine("~{0} = {1}", p, ~p);
        Console.WriteLine("{0} & {1} = {2}", p, r, p&r);
        Console.WriteLine("{0} | {1} = {2}", p, r, p | r);
        Console.WriteLine("{0} ^ {1} = {2}", p, r, p ^ r);
        Console.WriteLine("{0} << {1} = {2}", p, r, p << r);
        Console.WriteLine("{0} >> {1} = {2}", p, r, p >> r);
        Console.WriteLine();


    }
}
