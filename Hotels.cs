using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork2_HotelCalculations
{
    internal class Hotels
    {
        #region Fields & Class Initializers
        private static string[] Cities = { "Istanbul", "Izmir", "Ankara", "Antalya" };
        HotelManagement hotelManagement = new HotelManagement();
        #endregion

        #region Dictionaries
        private static Dictionary<int, string> istanbulHotelsDictionary = new Dictionary<int, string>()
        {
            { 1, "ISTANBUL Otel Adi" },
            { 2, "-----------------" },
            { 3, "Pera Palace Hotel" },
            { 4, "Intercontinental Istanbul, An IHG Hotel" },
            { 5, "Sheraton Istanbul City Center" },
            { 6, "Ramada Plaza Wyndham Istanbul City Center"},
            { 7, "Sokullu Pasa Hotel - Special Class"},
            { 8, "Nokta Suites Hotel" }
        };

        private static Dictionary<int, string> izmirHotelsDictionary = new Dictionary<int, string>()
        {
            { 1, "IZMIR Otel Adiler" },
            { 2, "-----------------" },
            { 3, "Renaissance Izmir Hotel" },
            { 4, "Tav Airport Hotel Izmir" },
            { 5, "DoubleTree by Hilton Izmir Airport" },
            { 6, "Hotel Apartment Alsancak" },
            { 7, "Hotel Iz"},
            { 8, "Olimpiyat Otel Izmir"}
        };

        private static Dictionary<int, string> ankaraHotelsDictionary = new Dictionary<int, string>()
        {
            { 1, "ANKARA Otel Adiler" },
            { 2, "------------------" },
            { 3, "No. 19 Boutique Hotel" },
            { 4, "New Park Hotel Ankara" },
            { 5, "Anemon Ankara" },
            { 6, "Grand Nora Hotel" },
            { 7, "The Green Park Ankara" },
            { 8, "Latanya Hotel Ankara" },
        };

        private static Dictionary<int, string> antalyaHotelsDictionary = new Dictionary<int, string>()
        {
            { 1, "ANTALYA Otel Adiler" },
            { 2, "-------------------" },
            { 3, "Akra Hotel" },
            { 4, "Adalya Port Hotel" },
            { 5, "Tuvana Hotel" },
            { 6, "Only One Suites&residence" },
            { 7, "Sherwood Breezes Resort"  },
            { 8, "Lemon Hotel" }
        };
        #endregion

        #region Methods
        /// <summary>
        /// Uygulamanın başlangiç noktası.
        /// </summary>
        /// <param name="hotelManagement"></param>
        internal static void CitySelector(HotelManagement hotelManagement)
        {
            ColorConsole.WriteLine("\t<- Otel Rezervasyon Sistemine Hoş Geldiniz ->", ConsoleColor.Green);

            bool looping = true;
            while (looping)
            {
                Console.Write("Bir Şehir Seçiniz: ");
                foreach (string city in Cities)
                {
                    Console.Write("< ");
                    ColorConsole.Write($"{city}", ConsoleColor.Cyan);
                    Console.Write(" >  ");
                }
                Console.WriteLine();
                string choice = Console.ReadLine();

                if (string.IsNullOrEmpty(choice))
                {
                    ColorConsole.WriteLine("Şehri Adi yerine boş oldu, yine deneyin!", ConsoleColor.Red);
                }
                else if (choice.ToLower().Equals("istanbul"))
                {
                    hotelManagement.City = "Istanbul";
                    looping = false;

                }
                else if (choice.ToLower().Equals("izmir"))
                {
                    hotelManagement.City = "Izmir";
                    looping = false;
                }
                else if (choice.ToLower().Equals("ankara"))
                {
                    hotelManagement.City = "Ankara";
                    looping = false;
                }
                else if (choice.ToLower().Equals("antalya"))
                {
                    hotelManagement.City = "Antalya";
                    looping = false;
                }
                else
                {
                    ColorConsole.WriteLine("Bu Şehri bulamadik, yine deneyin!", ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// İstanbul otel listesi hakkında bilgi yazdır ve kullanıcıların seçimini ayarlama yapıyor.
        /// </summary>
        /// <param name="hotelManagement"></param>
        internal static void IstanbulHotelsProcess(HotelManagement hotelManagement)
        {
            Console.Clear();
            foreach (var item in istanbulHotelsDictionary)
            {
                ColorConsole.WriteLine(item.Value, ConsoleColor.Green);
            }

            Console.Write("\nBir Otel Şeciniz: ");
            string choice = Console.ReadLine();
            if (choice.TrimStart().ToLower().Contains("pera"))
            {
                hotelManagement.HotelName = "Pera Palace Hotel";
                hotelManagement.HotelAddress = "Mesrutiyet Cad. No. 52, Istanbul 34430";
                hotelManagement.DailyFee = 193;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("Pera Palace Hotel \t* * * * *\t $193/gece \t (değerlendirme 9.0)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("inter") ||
                (choice.TrimStart().ToLower().Contains("ihg")))
            {
                hotelManagement.HotelName = "Intercontinental Istanbul, An IHG Hotel";
                hotelManagement.HotelAddress = "Asker Ocagi Cad No: 1 Taksim, Istanbul 34435";
                hotelManagement.DailyFee = 150;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("Intercontinental Istanbul, An IHG Hotel \t* * * * *\t $150/gece \t (değerlendirme 8.5)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("sher") ||
                (choice.TrimStart().ToLower().Contains("city center")))
            {
                hotelManagement.HotelName = "Sheraton Istanbul City Center";
                hotelManagement.HotelAddress = "Haci Ahmet Mah, Kurtulus Deresi Cad. No:23 Beyoglu, Istanbul 34440";
                hotelManagement.DailyFee = 100;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("Sheraton Istanbul City Center \t* * * * *\t $100/gece \t (değerlendirme 8.2)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("ram") ||
                (choice.TrimStart().ToLower().Contains("plaza")))
            {
                hotelManagement.HotelName = "Ramada Plaza Wyndham Istanbul City Center";
                hotelManagement.HotelAddress = "Halaskargazi Cad No 63, Istanbul 34373";
                hotelManagement.DailyFee = 89;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("Ramada Plaza Wyndham Istanbul City Center \t* * * * *\t $89/gece \t (değerlendirme 7.6)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("soku") ||
                (choice.TrimStart().ToLower().Contains("special")))
            {
                hotelManagement.HotelName = "Sokullu Pasa Hotel - Special Class";
                hotelManagement.HotelAddress = "Kücük Ayasofya Mah. Sehit, Mehmet Pasa Sk. No:3, Istanbul 34400";
                hotelManagement.DailyFee = 99;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("Sokullu Pasa Hotel - Special Class \t* * * *\t $99/gece \t (değerlendirme 6.5)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("nokta") ||
                (choice.TrimStart().ToLower().Contains("suite")))
            {
                hotelManagement.HotelName = "Nokta Suites Hotel";
                hotelManagement.HotelAddress = "Mustafa Kemal Pasa Mah., Büyükçekmece 34320";
                hotelManagement.DailyFee = 15;
                hotelManagement.HotelStar = 3;

                Console.Clear();
                ColorConsole.WriteLine("Nokta Suites Hotel \t* * *\t $15/gece \t (değerlendirme 7.2)", ConsoleColor.Green);

            }
            else
            {
                hotelManagement.HotelName = "?????";
                hotelManagement.HotelAddress = string.Empty;
                hotelManagement.DailyFee = 0;
                hotelManagement.HotelStar = 0;

                Console.Clear();
                ColorConsole.WriteLine("\tBu Otel Bulunamadı!", ConsoleColor.Green);

                ResetProgram();
            }
        }

        /// <summary>
        /// Izmir otel listesi hakkında bilgi yazdır ve kullanıcıların seçimini ayarlama yapıyor.
        /// </summary>
        /// <param name="hotelManagement"></param>
        internal static void IzmirHotelsProcess(HotelManagement hotelManagement)
        {
            Console.Clear();
            foreach (var item in izmirHotelsDictionary)
            {
                ColorConsole.WriteLine(item.Value, ConsoleColor.Green);
            }

            Console.Write("\nBiri Şecin: ");
            string choice = Console.ReadLine();
            if (choice.TrimStart().ToLower().Contains("renai") ||
                (choice.TrimStart().ToLower().Contains("izmir hotel")))
            {
                hotelManagement.HotelName = "Renaissance Izmir Hotel";
                hotelManagement.HotelAddress = "Akdeniz Mah Gaziosmanpasa Bulvari No 16 Konak, Izmir 35210";
                hotelManagement.DailyFee = 105;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("Renaissance Izmir Hotel \t* * * * *\t $105/gece \t (değerlendirme 8.1)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("tav") ||
                choice.TrimStart().ToLower().Contains("airport hotel"))
            {
                hotelManagement.HotelName = "Tav Airport Hotel Izmir";
                hotelManagement.HotelAddress = "Adnan Menderes Airport Int. Terminal, Izmir 34510";
                hotelManagement.DailyFee = 51;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("Tav Airport Hotel Izmir \t* * * *\t $51/gece \t (değerlendirme 7.8)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("double") ||
                (choice.TrimStart().ToLower().Contains("hilton")))
            {
                hotelManagement.HotelName = "DoubleTree by Hilton Izmir Airport";
                hotelManagement.HotelAddress = "Fatih Mh. Ege Cad. N:4A, Izmir 35410";
                hotelManagement.DailyFee = 48;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("DoubleTree by Hilton Izmir Airport \t* * * *\t $48/gece \t (değerlendirme 8.3)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("hotel apart") ||
                (choice.TrimStart().ToLower().Contains("alsancak")))
            {
                hotelManagement.HotelName = "Hotel Apartment Alsancak";
                hotelManagement.HotelAddress = "Gazi Mh. Ece Cad. N: 20, Izmir 354425";
                hotelManagement.DailyFee = 34;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("Hotel Apartment Alsancak \t* * * *\t $34/gece \t (değerlendirme 7.4)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("iz") ||
                (choice.TrimStart().ToLower().Contains("hotel iz")))
            {
                hotelManagement.HotelName = "Hotel Iz";
                hotelManagement.HotelAddress = "Gazi Bulvari Ismet Kaptan Mh, Izmir 35210";
                hotelManagement.DailyFee = 22;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("Hotel Iz \t* * * *\t $22/gece \t (değerlendirme 5.9)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("olimp") ||
                (choice.TrimStart().ToLower().Contains("otel")))
            {
                hotelManagement.HotelName = "Olimpiyat Otel Izmir";
                hotelManagement.HotelAddress = "1296 Sokak No:24, Izmir 35240";
                hotelManagement.DailyFee = 20;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("Olimpiyat Otel Izmir \t* * * *\t $20/gece \t (değerlendirme 7.6)", ConsoleColor.Green);

            }
            else
            {
                hotelManagement.HotelName = "?????";
                hotelManagement.HotelAddress = String.Empty;
                hotelManagement.DailyFee = 0;
                hotelManagement.HotelStar = 0;

                Console.Clear();
                ColorConsole.WriteLine("\tBu Otel Bulunamadı!", ConsoleColor.Green);

                ResetProgram();
            }
        }

        /// <summary>
        /// Ankara otel listesi hakkında bilgi yazdır ve kullanıcıların seçimini ayarlama yapıyor.
        /// </summary>
        /// <param name="hotelManagement"></param>
        internal static void AnkaraHotelsProcess(HotelManagement hotelManagement)
        {
            Console.Clear();
            foreach (var item in ankaraHotelsDictionary)
            {
                ColorConsole.WriteLine(item.Value, ConsoleColor.Green);
            }

            Console.Write("\nBiri Şecin: ");
            string choice = Console.ReadLine();
            if (choice.TrimStart().ToLower().Contains("no") ||
                (choice.TrimStart().ToLower().Contains("boutiq")))
            {
                hotelManagement.HotelName = "No. 19 Boutique Hotel";
                hotelManagement.HotelAddress = "Birlik Mahallesi 457. Sokak No:19, Ankara 6000";
                hotelManagement.DailyFee = 26;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("No. 19 Boutique Hotel \t* * * *\t $26/gece \t (değerlendirme 9.1)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("new park"))
            {
                hotelManagement.HotelName = "New Park Hotel Ankara";
                hotelManagement.HotelAddress = "Ziya Gokalp Bulvari No 58 Cankaya, Ankara 06600";
                hotelManagement.DailyFee = 47;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("New Park Hotel Ankara \t* * * * *\t $47/gece \t (değerlendirme 8.2)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("anem"))
            {
                hotelManagement.HotelName = "Anemon Ankara";
                hotelManagement.HotelAddress = "Konur2 Street No:60, Kavaklıdere, Ankara 06100";
                hotelManagement.DailyFee = 41;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("Anemon Ankara \t* * * *\t $41/gece \t (değerlendirme 6.9)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("grand"))
            {
                hotelManagement.HotelName = "Grand Nora Hotel";
                hotelManagement.HotelAddress = "36 Kız Kulesi Sokak, Ankara 06700";
                hotelManagement.DailyFee = 26;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("Grand Nora Hotel \t* * * *\t $26/gece \t (değerlendirme 8.0)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("green"))
            {
                hotelManagement.HotelName = "The Green Park Ankara";
                hotelManagement.HotelAddress = "Kizilirmak Mah. 1443 Cad. No:39, Ankara";
                hotelManagement.DailyFee = 50;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("The Green Park Ankara \t* * * * *\t $50/gece \t (değerlendirme 7.4)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("latan"))
            {
                hotelManagement.HotelName = "Latanya Hotel Ankara";
                hotelManagement.HotelAddress = "Büklüm Caddesi No:1, Ankara 06680";
                hotelManagement.DailyFee = 78;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("Latanya Hotel Ankara \t* * * * *\t $78/gece \t (değerlendirme 8.3)", ConsoleColor.Green);

            }
            else
            {
                hotelManagement.HotelName = "?????";
                hotelManagement.HotelAddress = String.Empty;
                hotelManagement.DailyFee = 0;
                hotelManagement.HotelStar = 0;

                Console.Clear();
                ColorConsole.WriteLine("\tBu Otel Bulunamadı!", ConsoleColor.Green);

                ResetProgram();
            }
        }

        /// <summary>
        /// Antalya otel listesi hakkında bilgi yazdır ve kullanıcıların seçimini ayarlama yapıyor.
        /// </summary>
        /// <param name="hotelManagement"></param>
        internal static void AntalyaHotelsProcess(HotelManagement hotelManagement)
        {
            Console.Clear();
            foreach (var item in antalyaHotelsDictionary)
            {
                ColorConsole.WriteLine(item.Value, ConsoleColor.Green);
            }

            Console.Write("\nBiri Şecin: ");
            string choice = Console.ReadLine();
            if (choice.TrimStart().ToLower().Contains("akra"))
            {
                hotelManagement.HotelName = "Akra Hotel";
                hotelManagement.HotelAddress = "24, Lara Cad, Antalya 07100";
                hotelManagement.DailyFee = 136;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("Akra Hotel \t* * * * *\t $136/gece \t (değerlendirme 7.5)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("adalya"))
            {
                hotelManagement.HotelName = "Adalya Port Hotel";
                hotelManagement.HotelAddress = "Selcuk Mh. Iskele Cd. No:72 Kaleiçi, Antalya 07100";
                hotelManagement.DailyFee = 58;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("Adalya Port Hotel \t* * * *\t $58/gece \t (değerlendirme 9.0)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("tuva"))
            {
                hotelManagement.HotelName = "Tuvana Hotel";
                hotelManagement.HotelAddress = "Tuzcular Karanlik Sok. No:18, Antalya 07100";
                hotelManagement.DailyFee = 88;
                hotelManagement.HotelStar = 4;

                Console.Clear();
                ColorConsole.WriteLine("Tuvana Hotel \t* * * *\t $88/gece \t (değerlendirme 8.4)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("only"))
            {
                hotelManagement.HotelName = "Only One Suites&residence";
                hotelManagement.HotelAddress = "Genclik Mah 1330 Sok No1, Antalya";
                hotelManagement.DailyFee = 83;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("Only One Suites&residence \t* * * * *\t $83/gece \t (değerlendirme 7.7)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("sher") ||
                choice.TrimStart().ToLower().Contains("resort"))
            {
                hotelManagement.HotelName = "Sherwood Breezes Resort";
                hotelManagement.HotelAddress = "Lara Beach, Antalya 07100";
                hotelManagement.DailyFee = 111;
                hotelManagement.HotelStar = 5;

                Console.Clear();
                ColorConsole.WriteLine("Sherwood Breezes Resort \t* * * * *\t $111/gece \t (değerlendirme 8.7)", ConsoleColor.Green);

            }
            else if (choice.TrimStart().ToLower().Contains("lemo"))
            {
                hotelManagement.HotelName = "Lemon Hotel";
                hotelManagement.HotelAddress = "Arapusuyu Mah. Belediye Cad. No.16, Antalya 07070";
                hotelManagement.DailyFee = 43;
                hotelManagement.HotelStar = 3;

                Console.Clear();
                ColorConsole.WriteLine("Lemon Hotel \t* * *\t $43/gece \t (değerlendirme 7.0)", ConsoleColor.Green);

            }
            else
            {
                hotelManagement.HotelName = "?????";
                hotelManagement.HotelAddress = String.Empty;
                hotelManagement.DailyFee = 0;
                hotelManagement.HotelStar = 0;

                Console.Clear();
                ColorConsole.WriteLine("\tBu Otel Bulunamadı!", ConsoleColor.Green);

                ResetProgram();
            }
        }

        /// <summary>
        /// Bazen kullanıcı girdileri nedeniyle programı sonlandırmak için, ve diğer zamanlarda try{} catch {} yerine kullanılır.
        /// </summary>
        internal static void ResetProgram()
        {
            Thread.Sleep(1500);
            Console.Clear();
            Environment.Exit(0);
        }

        /// <summary>
        /// Kullanılabilir odaların listesiyle kullanıcı girişini değerlendirme yapıyor.
        /// Üç parametre alır.
        /// </summary>
        /// <param name="hotelManagement"></param>
        /// <param name="returnedRandomRoomNumbers"></param>
        /// <param name="userInputRoomNumber"></param>
        /// <returns>bool</returns>
        internal static bool RoomNumberEvaluation(HotelManagement hotelManagement,
            int[] returnedRandomRoomNumbers,
            int userInputRoomNumber)
        {
            bool msg = default;
            if (returnedRandomRoomNumbers.Any(x => x == userInputRoomNumber))
                msg = true;
            else
            {
                if (userInputRoomNumber < 1000 || userInputRoomNumber >= 10000)
                {
                    ColorConsole.WriteLine("Oda Numarası 4 haneli olmalıdır.", ConsoleColor.Red);
                }
                else
                {
                    ColorConsole.WriteLine("Bu Oda Şuan Boş değil!", ConsoleColor.Red);
                }
            }
            return msg;
        }

        /// <summary>
        /// Rastgele seçilmiş oda numaraları ve müsaitlik durumu.
        /// </summary>
        /// <returns>int[]</returns>
        internal static int[] EmptyRooms()
        {
            Random random = new Random();
            int[] rooms = new int[random.Next(0, 6)];
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = random.Next(1000, 9999);
            }
            return rooms;
        }

        /// <summary>
        /// Bir otelde boş oda yoksa (rastgele döndürülen sayılar nedeniyle), bu yöntem o oteli listeden kaldırır.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="element"></param>
        internal static void RemovingElementFromDictionary(string city, string element)
        {
            switch (city)
            {
                case "Istanbul":
                    if (istanbulHotelsDictionary.ContainsValue(element))
                    {
                        int key = istanbulHotelsDictionary.FirstOrDefault(x => x.Value == element).Key;
                        istanbulHotelsDictionary.Remove(key);
                    }
                    break;
                case "Izmir":
                    if (izmirHotelsDictionary.ContainsValue(element))
                    {
                        int key = izmirHotelsDictionary.FirstOrDefault(x => x.Value == element).Key;
                        izmirHotelsDictionary.Remove(key);
                    }
                    break;
                case "Antalya":
                    if (antalyaHotelsDictionary.ContainsValue(element))
                    {
                        int key = antalyaHotelsDictionary.FirstOrDefault(x => x.Value == element).Key;
                        antalyaHotelsDictionary.Remove(key);
                    }
                    break;
                case "Ankara":
                    if (ankaraHotelsDictionary.ContainsValue(element))
                    {
                        int key = ankaraHotelsDictionary.FirstOrDefault(x => x.Value == element).Key;
                        ankaraHotelsDictionary.Remove(key);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}