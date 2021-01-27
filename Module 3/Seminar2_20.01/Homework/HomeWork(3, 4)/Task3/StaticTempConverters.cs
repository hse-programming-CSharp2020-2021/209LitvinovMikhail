using System;
using System.Collections.Generic;
using System.Text;

namespace Task3 {
    static class StaticTempConverters {
        public static double CelsToFahr(double temperatureToConvert) {
            Console.Write("Перевод из градусов по Цельсию в градусы по Фаренгейту: ");
            return ((double)9 / 5) * temperatureToConvert + 32;
        }

        public static double FahrToCels(double temperatureToConvert) {
            Console.Write("Перевод из градусов по Фаренгейту в градусы по Цельсию: ");
            return ((double)5 / 9) * (temperatureToConvert - 32);
        }

        public static double CelsToKelvin(double temperatureToConvert) {
            Console.Write("Перевод из градусов по Цельсию в градусы по Кельвину: ");
            return temperatureToConvert + 273.15;
        }
        public static double KelvinToCels (double temperatureToConvert)
        {
            Console.Write("Перевод из градусов по Кельвину в градусы по Цельсию: ");
            return temperatureToConvert - 273.15;
        }
        public static double CelsToRankin(double temperatureToConvert)
        {
            Console.Write("Перевод из градусов по Цельсию в градусы по Ранкину: ");
            return (temperatureToConvert + 273.15) * ((double)9/5);
        }
        public static double RankinToCels(double temperatureToConvert)
        {
            Console.Write("Перевод из градусов по Ранкину в градусы по Цельсию: ");
            return (temperatureToConvert - 491.67) * ((double)5 / 9);   
        }
        public static double CelsToReaumur(double temperatureToConvert)
        {
            Console.Write("Перевод из градусов по Цельсию в градусы по Реомюру: ");
            return temperatureToConvert * ((double)4/5);
        }
        public static double ReaumurToCels(double temperatureToConvert)
        {
            Console.Write("Перевод из градусов по Реомюру в градусы по Цельсию: ");
            return temperatureToConvert * ((double)5 / 4);
        }
    }
}
