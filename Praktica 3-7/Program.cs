using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika
{
    class Program
    {
        static double Сheck(bool mod = true, double inf = 1000)//проверка ввода числа
        {
            double to = 0;
            bool flag = true;
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

            while (flag)
            {
                try
                {
                    string from = Console.ReadLine();
                    to = Double.Parse(from.Replace(',', '.'), CultureInfo.InvariantCulture);
                    flag = false;
                    if (to < 0 && mod)
                    {
                        flag = true;
                    }
                }
                catch (Exception e)

                {

                    Console.WriteLine("ошибка ввода. введите число (цифру)");
                }
                if (to > inf)
                {
                    flag = true;
                    Console.WriteLine("число больше заданного диапазона");
                }

            }
            return to;

        }
        static double Area(double x, double y)//3 250 //zadanie 3
        {
            if (y >= -x && y >= x && Math.Sqrt(x * x + y * y) <= 1)
            {
                //Если пара чисел принадлежит D
                Console.WriteLine("принадлежит");
                return Math.Sqrt(x * x - 1);
            }
            else
            {
                Console.WriteLine("не принадлежит");
                return x + y;
            }
        }
        static void Sequence(double a1, double a2, double a3, int N, double E, //zadanie 6
        int i = 1, int count = 0, bool flag = true)
        {
            if (flag)
            {
                if (Math.Abs(a2 - a1) > E && count < N)
                {
                    Console.Write($"{a1}[1] {a2}[2]");
                    count += 2;
                }
                else
                    Console.Write($"{a1} {a2} ");
                i += 2;

                if (Math.Abs(a2 - a3) > E && count <= N)
                {
                    Console.Write($"{a3}[3] ");
                    count++;
                }
                else
                {
                    Console.Write($"{a3} ");
                }
                //i++;
            }
            double a4 = a3 + 2 * a2 * a1;
            if (count < N)
            {
                if (Math.Abs(a4 - a3) > E)
                {
                    count++;
                    Console.Write($" {a4}[{i + 1}] ");
                }
                else
                    Console.Write($" {a4} ");
                i++;
                Sequence(a2, a3, a4, N, E, i, count, false);

            }
        }
        static double foo(double xh)//zadanie 4
        {
            return (2 * Math.Pow(Math.Sin(xh), 2) / 3) - (3 * Math.Pow(Math.Cos(xh), 2) / 4);
        }
        private static int num = 1;

        public static bool NextSet(int[] ae, int nr, int m)
        {
            int j = m - 1;
            while (ae[j] == nr && j >= 0) j--;
            if (j < 0) return false;
            if (ae[j] >= nr)
                j--;
            ae[j]++;
            if (j == m - 1) return true;
            for (int k = j + 1; k < m; k++)
                ae[k] = ae[j];
            return true;
        }


        public static void Print(ref int[] ae, int nr)
        {
            Console.Write("{0,3}", num++);
            Console.Write("{0,3}", ": ");
            for (int i = 0; i < nr; i++)
            {
                Console.Write(ae[i]);
                Console.Write(" ");
            }
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            int n = 0;
            bool Exit = false;
            while (!Exit)
            {
                Console.WriteLine("Введите номер задания");
                string selection2 = null;
                selection2 = Console.ReadLine();
                switch (selection2)
                {
                    case "3":
                        Console.WriteLine("Задание 3");
                        Console.WriteLine("Введите координаты Х");;
                        double x = Сheck(false);
                        Console.WriteLine("Введите у");
                        double y = Сheck(false);
                        Console.WriteLine("Значение выражения:");
                        Console.WriteLine(Area(x, y));
                        break;

                    case "4":
                        double a = 0, b = Math.PI / 2, xh = Math.Abs(b - a) / 2;
                        double eps;
                        Console.WriteLine("Введите значение е");
                        while (!double.TryParse(Console.ReadLine(), out eps) || eps<=0)
                        {
                            Console.WriteLine("Ошибка ввода!");
                        }
                        while (b - a > eps)
                        {
                            double dx = (b - a) / 2;
                            xh = a + dx;
                            if (Math.Abs(foo(a)) != Math.Abs(foo(xh))) b = xh; else a = xh;
                        }
                        Console.WriteLine("Найден корень уравнения x = {0}", xh);
                        Console.WriteLine("С точностью = {0}", eps);
                        break;

                    case "5":
                        Console.WriteLine("Задание 5");
                        Console.WriteLine("Введите размерность матрицы");
                        int ny = int.Parse(Console.ReadLine());
                        ny += 1;
                        int[,] arraya = new int[ny, ny];
                        int i, j, s_above = 0, s_below = 0, s_on = 0;
                        Random rng = new Random();
                        for (i = 1; i < ny; i++)
                        {
                            for (j = 1; j < ny; j++)
                            {
                                arraya[i, j] = rng.Next(-5, 5);
                                Console.Write("{0,3}", arraya[i, j]);
                            }
                            Console.WriteLine("");
                        }
                        for (i = 1; i < ny; i++)
                        {
                            for (j = 1; j < ny; j++)
                            {
                                if (arraya[i, 1] < 0)
                                {
                                    {
                                        if (i == j)
                                            s_on = s_on + arraya[i, j];

                                        else

                                        if (i > j)
                                            s_below = s_below + arraya[i, j];
                                        else

                                        if (i < j)
                                            s_above = s_above + arraya[i, j];
                                    }
                                }
                            }
                        }
                        Console.WriteLine("В строках начинающихся с отрицательного числа");
                        Console.WriteLine("Сумма на главной диагонали ={0} ", s_on);
                        Console.WriteLine("Сумма выше диагонали ={0} ", s_above);
                        Console.WriteLine("Сумма ниже диагонали ={0} ", s_below);
                        break;

                    case "6":
                        Console.WriteLine("Задание 6");
                        Console.WriteLine("Введите поочерёдно a1, a2, a3, E, N .");
                        double
                            a1 = Сheck(false),
                            a2 = Сheck(false),
                            a3 = Сheck(false),
                            E = Сheck();
                        n = (int)Сheck();
                        Sequence(a1, a2, a3, n, E);
                        break;

                    case "7":
                        int nr, m;
                        int[] ae;
                        Console.WriteLine("Введите целое число N");
                        while (!int.TryParse(Console.ReadLine(), out nr))
                        {
                            Console.WriteLine("Ошибка ввода! Введите целое число N");
                        }
                        Console.WriteLine("Введите целое число K");
                        while (!int.TryParse(Console.ReadLine(), out m))
                        {
                            Console.WriteLine("Ошибка ввода! Введите целое число K");
                        }
                        int h = nr > m ? nr : m; // размер массива а выбирается как max(n,m)
                        ae = new int[h];
                        for (int ia = 0; ia < h; ia++)
                        {
                            ae[ia] = 1;
                        }
                        int ik = 0;

                        int c1 = nr + m - 1;
                        int c2 = nr - 1;
                        int c3 = m;

                        int fak = 1;
                        int fak1 = 1;
                        int fak2 = 1;

                        for (int ia = 2; ia <= c1; ia++)
                        {
                            fak = fak * ia;
                        }
                        for (int ia = 2; ia <= c2; ia++)
                        {
                            fak1 = fak1 * ia;
                        }
                        for (int ia = 2; ia <= c3; ia++)
                        {
                            fak2 = fak2 * ia;
                        }
                        int sum = fak / (fak1 * fak2);

                        Print(ref ae, m);
                        while (ik < sum - 1)
                        {
                            NextSet(ae, nr, m);
                            Print(ref ae, m);
                            ik++;
                        }
                        Console.ReadKey();
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
