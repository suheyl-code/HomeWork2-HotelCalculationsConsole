using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_HotelCalculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
            Console.ReadKey();
        }

        #region Method: Run()
        /// <summary>
        /// Bu yöntemde program sırasını ayarlama yaparız.
        /// </summary>
        private static void Run()
        {
            var otel = new HotelManagement();
            Hotels.CitySelector(otel);

            if (otel.City == "Istanbul")
            {
                Hotels.IstanbulHotelsProcess(otel);
            }
            else if (otel.City == "Izmir")
            {
                Hotels.IzmirHotelsProcess(otel);
            }
            else if(otel.City == "Ankara")
            {
                Hotels.AnkaraHotelsProcess(otel);
            }
            else if (otel.City == "Antalya")
            {
                Hotels.AntalyaHotelsProcess(otel);
            }

            otel.SetRoomNumber();

            if (otel.loopCounter > 0)
            {
                otel.SetRoomNumber();
                otel.SetDaysToStay();
                otel.SetExtraHotelOptions();
                otel.SetDate();
                otel.PrintReceipt();
                Environment.Exit(0);
            }

            otel.SetDaysToStay();
            otel.SetExtraHotelOptions();
            otel.SetDate();

            otel.PrintReceipt();
        }
        #endregion
    }
}
