using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrojkatTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Trojkat x;
            x = new Trojkat(2, 1, 2.5);
            Console.WriteLine(x);
            Console.WriteLine(x.Obwod());  //funkcja
            Console.WriteLine(x.Odwód);    //properties 'get' obwód
            //x.C = 2.9;                   //nadpisujemy jeden z boków trojkata dzięki właściwości set. Gdyby 'set' był 'private' w źródłowym pliku trojkata, to operacja nadpisania z tego poziomu nie byłaby możliwa
            Console.WriteLine(x.Odwód);
            Console.WriteLine(x.Pole);

            var y = new Trojkat();  // deklaracja z przypisaniem - 2w1; inny zapis niż powyżej
            Console.WriteLine(y);

        }
    }
}
