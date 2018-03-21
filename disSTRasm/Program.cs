using System;

namespace disSTRasm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            UNIT_TESTS_StringEnum utse = new UNIT_TESTS_StringEnum();

            utse.RunTests( );

            Console.ReadKey();
        }
    }
}
