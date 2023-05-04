using System.Reflection.Metadata.Ecma335;
namespace RunningApp
{
    internal class Program
    {
        static void Main()
        {
            int lapCount = 5;
            TimeSpan[] lapTimeArray = new TimeSpan[lapCount];
            for (int i = 0; i < lapCount; i++)
            {
                Console.Clear();
                DateTime firstTime = DateTime.Now;
                Console.WriteLine("Alınan toplam mesafe= " + ToplamMesafe(StepDistance(), StepCountMinute(), WalkTime()) + " metredir.");
                DateTime lastTime = DateTime.Now;
                TimeSpan lapTime = lastTime - firstTime;
                lapTimeArray[i] = lapTime;
                Console.WriteLine(lapTime);
                Console.WriteLine("Tur Zamanı Ekleniyor...");
                Thread.Sleep(5000);

            }
            Console.Clear();
            Array.Sort(lapTimeArray);
            Console.WriteLine("Turlar Sıralanıyor...");
            Thread.Sleep(3000);
            //foreach (TimeSpan items in lapTimeArray) {  Console.WriteLine("* "+items); } Farklı bir yöntem olarak kullanılabilir.

            for (int i = 0; i < lapTimeArray.Length; i++)
            {
                Console.WriteLine((i + 1) + ". en iyi tur: " + lapTimeArray[i]);
            }
            Console.ReadLine();


        }

        /// <summary>
        /// Give a one step distance 
        /// </summary>
        /// <returns></returns>
        private static double StepDistance()
        {
            Console.WriteLine("Bir adımızı giriniz");

            if (double.TryParse(Console.ReadLine(), out double step))
            {
                step = step / 100;
                Console.WriteLine("Bir adımınız metredir= " + step);
                return step;

            }
            else { Console.Clear(); Console.WriteLine("Yanlış veri girişi lütfen sayı giriniz"); return StepDistance(); }

        }
        /// <summary>
        /// Step Count Minute
        /// </summary>
        /// <returns></returns>
        private static double StepCountMinute()
        {
            Console.WriteLine("Bir dakikada kaç adım atıyorsunuz");

            if (double.TryParse(Console.ReadLine(), out double stepCount))
            {
                Console.WriteLine("Bir dakikada attığınız adım sayısı= " + stepCount);

                return stepCount;
            }
            else { Console.Clear(); Console.WriteLine("Yanlış veri girişi lütfen sayı giriniz"); return StepCountMinute(); }

        }
        /// <summary>
        /// (minute)Walk Time Method 
        /// </summary>
        /// <returns></returns>

        static double WalkTime()
        {
           
            Console.WriteLine("Koşu sürenizin saatlik kısmını giriniz");
            if (double.TryParse(Console.ReadLine(), out double walkTimeHour))
            {
                walkTimeHour = walkTimeHour * 60;

            }
            else { Console.Clear(); Console.WriteLine("Yanlış veri girişi lütfen sayı giriniz"); return WalkTime(); }            
            Console.WriteLine("Koşu sürenizin dakikalık kısmını giriniz");
            if (double.TryParse(Console.ReadLine(), out double kosuSuresiDakika))
            {
                double time = walkTimeHour + kosuSuresiDakika;
                Console.WriteLine("Toplam koşu süresi: " + time);
                return time;
            }
            else { Console.Clear(); Console.WriteLine("Yanlış veri girişi lütfen sayı giriniz"); return WalkTime(); }
        
                    
           
           
        }
        /// <summary>
        /// the total path taken Method
        /// </summary>
        /// <param name="step"></param>
        /// <param name="stepCount"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        static double ToplamMesafe(double step, double stepCount, double time)
        {
            Console.WriteLine("Adım uzunluğu metre cinsinden: "+step);
            Console.WriteLine("Toplam koşu süresince atılan adım: "+stepCount*time);
            double toplamMesafe = time * step * stepCount;
            return toplamMesafe;
        }
    }
}