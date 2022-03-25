// Austin Dugas
// C00231110
// CMPS 358
// Assignment: a2b_7

using System;

namespace DelegateExample1
{
    class Program
    {
        delegate void MyDelegateType(double d);

        static void ShowAll(double[] b, MyDelegateType mdt)
        {
            for (int i = 0; i < b.Length; i++)
                mdt(b[i]);
        }

        static void ShowTwice(double d) => Console.WriteLine("Twice: " + d * 2);

        static void ShowThrice(double d) => Console.WriteLine("Thrice: " + d * 3);

        static void ShowQuad(double d) => Console.WriteLine("Quad: " + d * 4);

        static void Main(string[] args)
        {
            double[] a = {1.1, 5.5, 9.9};

            MyDelegateType md = ShowTwice;
            md += ShowThrice;
            md += ShowQuad;
            
            ShowAll(a,md);
        }
    }
}