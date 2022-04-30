using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork2_HotelCalculations
{
    internal class HotelManagement
    {
        #region Fields
        internal int[] returnedRandomRoomNumbers = Hotels.EmptyRooms();
        internal char hotelExtraOptions;
        internal string wantToReturn;
        internal byte loopCounter;
        private string _msg;
        #endregion

        #region Properties
        public string City { get; internal set; }

        private string _hotelName;
        public string HotelName
        {
            get { return _hotelName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _hotelName = "?????";
                else
                    _hotelName = value;
            }
        }

        public string HotelAddress { get; internal set; }

        public int RoomNumber { get; internal set; }

        public byte HotelStar { get; internal set; }

        private short _daysToStay;
        public short DaysToStay
        {
            get { return _daysToStay; }
            set
            {
                if (value > 0)
                {
                    _daysToStay = value;
                }
                else
                {
                    ColorConsole.WriteLine("Kalacağı Gün 0 veya olumsuz olamaz!", ConsoleColor.Red);
                    _daysToStay = 1;
                }
            }
        }

        private double _dailyFee;
        public double DailyFee
        {
            get { return _dailyFee; }
            set
            {
                if (value >= 10)
                {
                    _dailyFee = value;
                }
                else
                {
                    ColorConsole.WriteLine("Fiyatlar $10.00'dan başlıyor.", ConsoleColor.Red);
                    _dailyFee = 10.0;
                }
            }
        }

        public DateTime EnteringDate { get; internal set; }

        public DateTime EndDate { get; internal set; }
        #endregion

        #region Methods

        /// <summary>
        /// rastgele oluşturulmuş odalar arasında oda numarası istemek.
        /// </summary>
        /// <param name="hotelManagement"></param>
        internal void SetRoomNumber()
        {
            if (returnedRandomRoomNumbers.Length == 0)
            {
                ColorConsole.WriteLine("Üzgünüz, şu anda bu otelde boş oda yok!", ConsoleColor.Red);
                Console.Write("\nOtel listesi yine görmek ister misiniz? (Evet/Hayır) ");
                this.wantToReturn = Console.ReadLine();
                if (this.wantToReturn.ToLower().StartsWith("e"))
                {
                    loopCounter++;
                    Hotels.RemovingElementFromDictionary(this.City, this.HotelName);
                    switch (this.City)
                    {
                        case "Istanbul":
                            Hotels.IstanbulHotelsProcess(this);
                            break;
                        case "Izmir":
                            Hotels.IzmirHotelsProcess(this);
                            break;
                        case "Antalya":
                            Hotels.AntalyaHotelsProcess(this);
                            break;
                        case "Ankara":
                            Hotels.AnkaraHotelsProcess(this);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                if (returnedRandomRoomNumbers.Length == 1)
                    Console.WriteLine("Şuan Sadece Bu oda Boş:");
                else
                    Console.WriteLine("Şuan Bu odalar Boş:");

                foreach (var room in returnedRandomRoomNumbers)
                {
                    ColorConsole.Write($"{room} ", ConsoleColor.Magenta);
                }

                Console.WriteLine();

                if (returnedRandomRoomNumbers.Length == 1)
                {
                    Console.Write("Bu Odayi istermisiniz (Evet/Hayır): ");
                    string roomChoice = Console.ReadLine();
                    if (roomChoice.ToLower().StartsWith("e"))
                    {
                        this.RoomNumber = this.returnedRandomRoomNumbers[0];
                    }
                    else
                    {
                        Hotels.ResetProgram();
                    }
                }
                else
                {
                    Console.Write("\nBir Oda Seçiniz: ");
                    int userInputRoomNumber = Convert.ToInt32(Console.ReadLine()); ;
                    bool decission = Hotels.RoomNumberEvaluation(this, returnedRandomRoomNumbers.ToArray(), userInputRoomNumber);
                    if (decission)
                    {

                        this.RoomNumber = userInputRoomNumber;
                    }
                    else
                    {
                        Hotels.ResetProgram();
                    }
                }
            }
        }

        /// <summary>
        /// Kaç Gün Kalacaksınız diye sorariz.
        /// </summary>
        internal void SetDaysToStay()
        {
            if (this.DaysToStay == 0)
            {
                Console.Write("\nKaç Gün Kalacaksınız? ");
                this.DaysToStay = Convert.ToInt16(Console.ReadLine());
                if (this.DaysToStay > 255)
                {
                    ColorConsole.WriteLine("sistem bu kadar gün izin vermiyor!", ConsoleColor.Red);
                    Thread.Sleep(1000);
                    this.DaysToStay = 1;
                }
            }
        }

        /// <summary>
        /// 4'ten fazla yıldızlı otellerin ekstra seçenekleri var. İşte onları soruyoruz.
        /// </summary>
        internal void SetExtraHotelOptions()
        {
            if (this.HotelStar > 0 && this.HotelStar < 3)
            {
                ColorConsole.WriteLine("Bu Otel Kapanacak!", ConsoleColor.Red);
            }
            else if (this.HotelStar == 3 || this.HotelStar == 4)
            {
                ColorConsole.WriteLine("Bu otel için ekstra seçenek mevcut değil.", ConsoleColor.Green);
            }
            else if (this.HotelStar > 4)
            {
                ColorConsole.WriteLine("\nBu Otelde Fazla Seçenekler de Var:", ConsoleColor.Green);
                ColorConsole.Write("\ta-Sauna\n" +
                    "\tb-Jakuzi\n" +
                    "\tc-Masaj Salonu\n" +
                    "\td-Tenis kortu\n" +
                    "\te-Hepsi\n" +
                    "\tf-Hiç Biri\n", ConsoleColor.Green);
                ColorConsole.Write("Hangi Seçenek (a/b/c...)? ", ConsoleColor.Green);
                this.hotelExtraOptions = Convert.ToChar(Console.ReadLine());
            }
            else
            {
                ColorConsole.WriteLine("Yildiz Sifir veya olumsuz Olamaz!", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Tarih ayarlamak
        /// </summary>
        internal void SetDate()
        {
            this.EnteringDate = DateTime.Today.AddDays(1).Date;
            this.EndDate = this.EnteringDate.AddDays(this.DaysToStay);
        }

        /// <summary>
        /// fiyat hesaplamaları
        /// </summary>
        /// <returns>double</returns>
        private double PriceCalculations()
        {
            double kdv = 0.0d;
            double extra = 0.0d;
            double sum = 0.0d;

            if (this.DaysToStay > 0 && this.DaysToStay < 2)
            {
                kdv = (this.DailyFee * this.DaysToStay) * 0.02;
            }
            else if (this.DaysToStay >= 2 && this.DaysToStay <= 8)
            {
                kdv = (this.DailyFee * this.DaysToStay) * 0.08;
            }
            else if (this.DaysToStay > 8)
            {
                kdv = (this.DailyFee * this.DaysToStay) * 0.18;
            }
            sum = (this.DailyFee * this.DaysToStay) + kdv;

            if (HotelStar > 4)
            {
                switch (hotelExtraOptions)
                {
                    case 'a':
                        extra = sum * 0.2;
                        break;
                    case 'b':
                        extra = sum * 0.15;
                        break;
                    case 'c':
                        extra = sum * 0.1;
                        break;
                    case 'e':
                        extra = sum * 0.325;
                        break;
                    default:
                        break;
                }
                sum += extra;
            }
            return sum;
        }

        /// <summary>
        /// Tüm bilgileri ekrana yazdırmak için.
        /// </summary>
        public void PrintReceipt()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("****************************************************************");
            Console.WriteLine("* {0,-15}{1,45} *", "Şehir:", this.City);
            Console.WriteLine("* {0,-15}{1,45} *", "Otel Adi:", this.HotelName);
            ColorConsole.WriteLine($"{"",-2}{this.HotelAddress,45}", ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.Blue;

            if (RoomNumber != 0)
            {
                Console.WriteLine("* {0,-15}{1,45} *", "Oda Numarası:", this.RoomNumber);
            }
            else
            {
                Console.WriteLine("* {0,-15}{1,45} *", "Oda Numarası:", "-----");
            }

            if (HotelStar < 3)
            {
                Console.WriteLine("* {0,-15}{1,25}{2,25} *", "Otel Yildizi:", this.HotelStar, "(!)");
            }
            else if (HotelStar > 4)
            {
                Console.WriteLine("* {0,-15}{1,45} *", "Otel Yildizi:", this.HotelStar);
                switch (hotelExtraOptions)
                {
                    case 'a':
                        _msg = "Sauna (+%20 Fiyat)";
                        break;
                    case 'b':
                        _msg = "Jakuzi (+%15 Fiyat)";
                        break;
                    case 'c':
                        _msg = "Masaj Salonu (+%10 Fiyat)";
                        break;
                    case 'd':
                        _msg = "Tenis Kortu (Ücretsiz)";
                        break;
                    case 'e':
                        _msg = "Sauna/Jakuzi/Masaj/... (+%32.5 Fiyat)";
                        break;
                    case 'f':
                        _msg = "<Otel Özellikleri Seçilmedi>";
                        break;
                    default:
                        _msg = "!!!Bilinmeyen Seçenek!!!";
                        break;
                }
                Console.WriteLine("* {0,-15}{1,45} *", "Ozellikler:", _msg);
            }
            else
            {
                Console.WriteLine("* {0,-15}{1,45} *", "Otel Yildizi:", this.HotelStar);
            }

            if (this.DaysToStay > 0 && this.DaysToStay < 2)
            {
                Console.WriteLine("* {0,-15}{1,22}{2,23} *", "Kalınacak Gün:", this.DaysToStay, "OTV %2");
            }
            else if (this.DaysToStay >= 2 && this.DaysToStay <= 8)
            {
                Console.WriteLine("* {0,-15}{1,22}{2,23} *", "Kalınacak Gün:", this.DaysToStay, "Kdv %8");
            }
            else if (this.DaysToStay > 8)
            {
                Console.WriteLine("* {0,-15}{1,22}{2,23} *", "Kalınacak Gün:", this.DaysToStay, "Kdv %18");
            }
            else
            {
                Console.WriteLine("* {0,-15}{1,45} *", "Kalınacak Gün:", this.DaysToStay);
            }

            Console.WriteLine("* {0,-15}{1,45} *", "Giriş Tarihi:", this.EnteringDate);
            Console.WriteLine("* {0,-15}{1,45} *", "Çikiş Tarihi:", this.EndDate);
            Console.WriteLine("* {0,-15}{1,45:c2} *", "Günluk Fiyat:", this.DailyFee);
            // Fiyat Muhasebe
            Console.WriteLine("* {0,-15}{1,45:c2} *", "Toplam Fiyat:", PriceCalculations());

            Console.WriteLine("****************************************************************");
            Console.WriteLine("\t\t\tiyi günler dileriz\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion
    }
}

