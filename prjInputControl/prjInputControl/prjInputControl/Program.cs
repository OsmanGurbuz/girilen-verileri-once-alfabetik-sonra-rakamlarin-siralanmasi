using System;
using System.Collections.Generic;

namespace prjInputControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> rakamlar = new List<int>();
            List<string> harfler = new List<string>();
            string veri = "";
            do
            {
                Console.Write("-------------------------------------------------------------\n");
                Console.Write("Bir değer giriniz yada çıkmak için -(eksi) tuşuna basınız : ");
                veri = Console.ReadLine();
                if (veri == "-")
                {
                    Console.WriteLine("Çıkış yapıldı!");
                    break;
                }
                if (isNumeric(veri) == true)
                {
                    if (sayiGirildiMi(veri, rakamlar)) 
                    {
                        Console.WriteLine("Girilen rakam daha önce girildi!");
                    }
                    else
                    {
                        rakamlar.Add(int.Parse(veri));
                    }
                }
                else if (isNumeric(veri) == false)
                {
                    if (harfGirildiMi(veri, harfler))
                    {
                        Console.WriteLine("Girilen harf daha önce girildi!");
                    }
                    else
                    {
                        harfler.Add(veri);
                    }
                }
            } while (true);

            List<string> siraliListe = verileriSirala(harfler,rakamlar);
            Console.WriteLine("-------------------------------------------------------------\n\n");
            Console.WriteLine("Verilerin sıralanmış hali : " + string.Join(",", siraliListe));
            Console.WriteLine("\n\n-------------------------------------------------------------");

        }
        public static bool isNumeric(string veri)
        {
            int numeric = 0;
            bool cevirildiMi = int.TryParse(veri, out numeric);
            return cevirildiMi;
        }
        public static bool harfGirildiMi(string veri, List<string> harfler)
        {
            foreach (string harf in harfler)
            {
                if (veri == harf)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool sayiGirildiMi(string veri, List<int> rakamlar)
        {
            foreach (int rakam in rakamlar)
            {
                if (int.Parse(veri) == rakam)
                {
                    return true;
                }
            }
            return false;
        }
        public static List<string> verileriSirala(List<string> harfler, List<int> rakamlar)
        {
            List<string> geciciListe = new List<string>();
            harfler.Sort();
            rakamlar.Sort();

            foreach (string harf in harfler)
            {
                geciciListe.Add(harf);
            }
            foreach (int rakam in rakamlar)
            {
                geciciListe.Add(rakam.ToString());
            }
            return geciciListe;
        }
    }
}
