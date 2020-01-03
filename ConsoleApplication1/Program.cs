using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int q = GetPrimeNumber();
            int p = GetPrimeNumber(q);
            int n = q * p;
            int fn = (p - 1) * (q - 1);
            int d =GetD(fn, n);
            int e = GetE(d, fn);
            Console.WriteLine(q+" "+p+" "+fn+" "+d+" "+e);
            
           
            string s = "сьешь";
            
            
            Console.WriteLine(encrypt(n, e, s));
            Console.WriteLine(Decrypt(n, d, encrypt(n, e, s)));
            
        }
        static string encrypt(long n,long e,string s)
        {
            string s2 = "";
            for (int i = 0; i < s.Length; i++)
            {
                double temp = (Math.Pow(GetNumberSymbol(s[i]), e)) % n;
                s2 += " " + temp;
                Console.WriteLine("Enckrypt"+temp);

            }
            return s2;
        }
        static string Decrypt(long n, long d,string s)
        {
            string s2 = "";
            string[] s3 = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < s3.Length; i++)
            {
                double temp = (Math.Pow(double.Parse(s3[i]), d)) % n;
                s2 += " " + GetSymbolNumber(temp);
            }
            Console.WriteLine("Descrypt"+s2);
            return s2;
        }
        static int GetD(int fn, int n)
        {

            int d;
            for ( d= 2; d <= fn; d++)
                if ((MutuallySimple(d, fn)) && (d%2!=0) && (SearchK(d,fn)==true)) //если имеют общие делители
                {
                    Console.WriteLine(SearchK(d, fn)+" "+d);
                    return d;
                }
            
            return d;
        }
        public static bool SearchK(int d,int fn)
        {
            int i = 0;
            int n = 0;
            for (i = 3; i < fn; i++)
                if ((i * fn + 1) % d == 0)
                {
                    n++;
                    Console.WriteLine(i);
                    break;
                }
            if (n != 0) return true;
            else return false;
        }
        static int GetE(int d, int fn)
        {
            int e=1;
            int i = 0;
            if(SearchK(d, fn))
            for(i=0;i<fn; i++)
               if((i*fn+1)%d==0)
            {
                    break;
            }
            e = (i * fn + 1) / d;
            return e;
            //for(e=2;e< fn; e++)
            //{
            //    if (((e * d) % fn == 1)) break;
            //}
            //return e;

           
        }
        static public int GetPrimeNumber()
        {
            Random rand = new Random();
            int n;
            for (n = rand.Next(3, 17); n < 20; n++)
            {
                if (PrimeNumber(n)) break;

            }
            return n;
        }
        static public int GetPrimeNumber(int num)
        {
            Random rand = new Random();
            int n ;
            for (n = rand.Next(3, 17); n < 20; n++)
            {
                if (PrimeNumber(n)&&n!=num) break;

            }
            return n;
        }
        static public bool PrimeNumber(long n)
        {
            for (int i = 2; i < n - 1; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public static char GetSymbolNumber(double number)//symbol
        {
            char letter = '0';
            int i = 0;
            for (int symbol = 'а'; symbol <= 'я'; ++symbol)
            {
                letter = (char)symbol;
                if (i == number - 1) return letter;
                i++;
            }
            return letter;
        }
        public static int GetNumberSymbol(char s)
        {
            char letter = '0';
            int i = 0;
            for (int symbol = 'а'; symbol <= 'я'; ++symbol)
            {

                letter = (char)symbol;
                if (letter == s) return i + 1;
                i++;
            }
            return i;
        }
        public static bool MutuallySimple(int num1, int num2)
        {
            if (num1 == num2)
            {
                return num1 == 1;
            }
            else
            {
                if (num1 > num2)
                {
                    return MutuallySimple(num1 - num2, num2);
                }
                else
                {
                    return MutuallySimple(num2 - num1, num1);
                }
            }
        }
    }
}
