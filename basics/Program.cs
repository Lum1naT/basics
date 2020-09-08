using System;


namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Date date = new Date("30/11/2020");
            date.addDay();
            date.addDay();
            date.addDay();
            Console.WriteLine(date.Day + "/" + date.Month + "/" + date.Year);
        }

        static Boolean IsPrime(int input)
        {
            double sqrtInput = Math.Sqrt(input);
            for(int i = 2; i <= Math.Floor(sqrtInput); i++)
            {
                if((input % i) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
