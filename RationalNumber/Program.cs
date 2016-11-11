using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{
    class Program
    {
        /// <summary>
        /// Класс расчета дробных (рациональных) чисел
        /// </summary>
        private class Rational
        {
            /// <summary>
            /// up - числитель
            /// </summary>
            int up = 0;
            /// <summary>
            /// down - знаменатель
            /// </summary>
            int down =1;

            /// <summary>
            /// Констркутор по умолчанию формирующий дробь 0/1
            /// </summary>
            public Rational()
            {
                up = 0;
                down = 1;
            }

            /// <summary>
            /// Конструктор задающий числитель и знаменатель
            /// </summary>
            /// <param name="in_up"></param>
            /// <param name="in_down"></param>
            public Rational(int in_up, int in_down)
            {
                if (in_down == 0) throw (new Exception("init down=0"));

                up = in_up;
                down = in_down;
            }


            public void Set(int in_up, int in_down)
            {
                if (in_down == 0) throw (new Exception("set down=0"));

                up = in_up;
                down = in_down;
            }

            public void Set(int in_number, int in_up, int in_down)
            {
                if (in_down == 0) throw (new Exception("set down=0"));

                up = in_up + in_down * in_number;
                down = in_down;
            }

            private int Nod(int in_up1, int in_up2, int in_down)
            { 
                int result = 1;
                for (int i = 1; i <= in_down; i++)
                    if ((in_down>=i) && (in_down % i == 0))
                        if ((in_up1 >= i) && (in_up1 % i == 0))
                            if ((in_up2 >= i) && (in_up2 % i == 0))
                                { result = i; }
                return (result);
            }

            private int Nod(int in_up1, int in_down)
            {
                return (Nod(in_up1, in_up1, in_down));
            }

            public Rational Add(Rational in_r)
            {
                Rational r = new Rational (this.up, this.down);

                int x1, y1;
                x1 = in_r.up * down;
                y1 = in_r.down * down;

                int x2, y2;
                x2 = up * in_r.down;
                y2 = down * in_r.down;

                int nod = Nod(x1, x2, y1);

                x1 = x1 / nod;
                y1 = y1 / nod;
                x2 = x2 / nod;
                y2 = y2 / nod;

                x1 = x1 + x2;

                nod = Nod(x1, y1);

                x1 = x1 / nod;
                y1 = y1 / nod;
                x2 = x2 / nod;
                y2 = y2 / nod;

                r.Set(x1, y1);

                return r;
            }

            public override string ToString()
            {
                return 
                    (this.up.ToString() + "/" + this.down.ToString());
            }
        }

        static void Main(string[] args)
        {

            Rational r1 = new Rational(1, 2);
            Rational r2 = new Rational(1, 2);

            Console.Write(r1 + "+" + r2 + "=");

            r1 = r1.Add(r2);

            Console.WriteLine(r1.ToString ());


            Console.ReadLine();

        }
    }
}
