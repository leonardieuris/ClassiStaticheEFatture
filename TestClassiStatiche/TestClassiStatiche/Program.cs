using System;

namespace TestClassiStatiche
{
    class Program
    {
        static void Main(string[] args)
        {
            var valorePiGreco = CostantiMatematiche.PiGreco;
            Console.WriteLine($"Il valore del pigreco è {valorePiGreco} ");

            var circonferenza = CostantiMatematiche.CalcoloCirconferenza(45);

            Console.WriteLine($"Il valore della circonferenza è {circonferenza} ");

            Console.ReadLine();
        }
    }
}
