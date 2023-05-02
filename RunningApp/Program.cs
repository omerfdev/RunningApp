using System.Reflection.Metadata.Ecma335;
namespace RunningApp
{
    internal class Program
    {
        static void Main()
        {
            int turSayisi = 5;
            TimeSpan[] turSuresi = new TimeSpan[turSayisi];
            for (int i = 0; i < turSayisi; i++)
            {
                Console.Clear();
                DateTime firstTime = DateTime.Now;
                Console.WriteLine("Alınan toplam mesafe= " + ToplamMesafe(AdımMesafesi(), AdimSayisi(), KosuSüresi()) + " metredir.");
                DateTime lastTime = DateTime.Now;
                TimeSpan turZamani = lastTime - firstTime;
                turSuresi[i] = turZamani;
                Console.WriteLine(turZamani);
                Console.WriteLine("Tur Zamanı Ekleniyor...");
                Thread.Sleep(5000);

            }
            Console.Clear();
            Array.Sort(turSuresi);
            Console.WriteLine("Turlar Sıralınayor...");
            Thread.Sleep(3000);
            //foreach (TimeSpan items in turSuresi) {  Console.WriteLine("* "+items); } Farklı bir yöntem olarak kullanılabilir.

            for (int i = 0; i < turSuresi.Length; i++)
            {
                Console.WriteLine((i + 1) + ". en iyi tur: " + turSuresi[i]);
            }
            Console.ReadLine();


        }

        /// <summary>
        /// metod adım mesafesini ölçer ve metre cinsine çevirir.
        /// </summary>
        /// <returns></returns>
        private static double AdımMesafesi()
        {
            Console.WriteLine("Bir adımızı giriniz");

            if (double.TryParse(Console.ReadLine(), out double adim))
            {
                adim = adim / 100;
                Console.WriteLine("Bir adımınız metredir= " + adim);
                return adim;

            }
            else { Console.Clear(); Console.WriteLine("Yanlış veri girişi lütfen sayı giriniz"); return AdımMesafesi(); }

        }
        /// <summary>
        /// Bu metod bir dakikada  kaç adet adım attığını bulur
        /// </summary>
        /// <returns></returns>
        private static double AdimSayisi()
        {
            Console.WriteLine("Bir dakikada kaç adım atıyorsunuz");

            if (double.TryParse(Console.ReadLine(), out double adimSayisi))
            {
                Console.WriteLine("Bir dakikada attığınız adım sayısı= " + adimSayisi);

                return adimSayisi;
            }
            else { Console.Clear(); Console.WriteLine("Yanlış veri girişi lütfen sayı giriniz"); return AdimSayisi(); }

        }
        /// <summary>
        /// Kosu süresini saat ve dakika olarak ister ve daha sonra saati 60 ile çarpıp dakika olarak geri gönderir.
        /// </summary>
        /// <returns></returns>

        static double KosuSüresi()
        {
           
            Console.WriteLine("Koşu sürenizin saatlik kısmını giriniz");
            if (double.TryParse(Console.ReadLine(), out double kosuSuresiSaat))
            {
                kosuSuresiSaat = kosuSuresiSaat * 60;

            }
            else { Console.Clear(); Console.WriteLine("Yanlış veri girişi lütfen sayı giriniz"); return KosuSüresi(); }            
            Console.WriteLine("Koşu sürenizin dakikalık kısmını giriniz");
            if (double.TryParse(Console.ReadLine(), out double kosuSuresiDakika))
            {
                double sure = kosuSuresiSaat + kosuSuresiDakika;
                Console.WriteLine("Toplam koşu süresi: " + sure);
                return sure;
            }
            else { Console.Clear(); Console.WriteLine("Yanlış veri girişi lütfen sayı giriniz"); return KosuSüresi(); }
        
                    
           
           
        }
        /// <summary>
        /// Bu metod parametrelerini aldıktan sonra toplam mesafeyi ölçer.
        /// </summary>
        /// <param name="adim"></param>
        /// <param name="adimSayisi"></param>
        /// <param name="kosuSuresi"></param>
        /// <returns></returns>
        static double ToplamMesafe(double adim, double adimSayisi, double sure)
        {
            Console.WriteLine("Adım uzunluğu metre cinsinden: "+adim);
            Console.WriteLine("Toplam koşu süresince atılan adım: "+adimSayisi*sure);
            double toplamMesafe = sure * adim * adimSayisi;
            return toplamMesafe;
        }
    }
}