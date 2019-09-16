using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrojkatTest
{
    class Trojkat
    {
        //fields
        private decimal a;      //prywatne - nie widoczne w innych częściach (innych plikach cs) kodu
                                //robimy decimal, bo później robimy działania na liczbach wykorzystując równania
        public double A        // publiczne, służące do pobierania lub zapisywania danych
        {
            get { return (double)a; }
            set
            {
                if (!jestWarunekTrojkata((decimal)value, b, c))  //trzeba sprawdzić, czy wolno to wykonać -> jestWarunekTrojkata
                    throw new ArgumentException("Nie można zmienić boku A");

                a = (decimal)value;
            }
        }



        private decimal b;
        public double B
        {
            get => (double)b; //strzałka oznacza wyrzuć = 'return'
            set
            {
                if (!jestWarunekTrojkata((decimal)value, a, c))
                    throw new ArgumentException("Nie można zmienić boku B");
                b = (decimal)value;
            }
        }

        private decimal c;
        public double C
        {
            get => (double)c;
            set
            {
                if (!jestWarunekTrojkata((decimal)value, b, a))
                    throw new ArgumentException("Nie można zmienić boku C");
                c = (decimal)value;
            }
        }

        private bool jestWarunekTrojkata(decimal x, decimal y, decimal z)
        {
            return x + z > y && x + y > z && z + y > x;
        }

        //konstruktory
        public Trojkat(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)           // '||' - lub
                throw new ArgumentException("Argument musi być dodatni");

            if (!jestWarunekTrojkata((decimal)a, (decimal)b, (decimal)c))
                // a + b <= 0 || a +c  <= 0 || b + c <= a //prawo de Morgana
                throw new ArgumentException("Nie spełniony warunek trójkąta");

            this.a = (decimal)a;  //'this' potrzebne do identyfikacji odwołania przy konflikcie nazewniczym
            this.b = (decimal)b;
            this.c = (decimal)c;
        }

        public Trojkat ()
        {
            a = b = c = 1;
        }

        //przeciążenie ToString
        public override string ToString()  //nadpisanie domyślnej formuły prezentacji obiektu zapisanego w obiekcie - bez tego cecha jest dziedziczona
        {
            return $"Trojkat: a ={a} b={b} c={c}";
        }

        public double Obwod()
        {
            return (double)(a + b + c);
        }

        public double Odwód //properties - licznie towarzyszy niejako pobieraniu \ 'get' wartości\właściwości
        {
            get { return (double)(a + b + c); }
        }

        public double Pole
        {
            get
            {
                decimal p = (decimal)(0.5 * Obwod());
                return Math.Sqrt((double)(p * (p - a) * (p - b) * (p - c)));  //wzrór Herona na obliczenia pola trójkąta na podstawie długości odcinków
            }

        }

        bool jestProstokatny
        {
            get
            {
                throw new NotImplementedException(); //a2+b2=c2 - jeżeli którykolwiek jest prawdziwy
            }
        }

        bool jestOstrokatny
        {
            get
            {
                throw new NotImplementedException(); //a2+b2<c2 - ostrokątny
            }
        }
    }
}
