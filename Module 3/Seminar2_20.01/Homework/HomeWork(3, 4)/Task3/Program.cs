using System;
using System.Collections.Generic;
namespace Task3 {
    class Program {

        public delegate double delegateConvertTemperature(double temperature);

        static void Main() {
            Console.WriteLine($"Задача #3: {Environment.NewLine}");
            // --------------------------------------------------------
            // Блок кода, необходимый для первой части третьей задачи (скорее более вводный в условие задачи). 
            TemperatureConverterImp converter = new TemperatureConverterImp();
            delegateConvertTemperature TempCelsToFahr = new delegateConvertTemperature(converter.CelsToFahr);
            delegateConvertTemperature TempFahrToCels = new delegateConvertTemperature(converter.FahrToCels);
            Console.WriteLine("Пример работы перевода 45.5 градусов по Цельсию в градусы по Фаренгейту:");
            Console.WriteLine($"{TempCelsToFahr(45.5):F2}");
            Console.WriteLine("Пример работы перевода 70 градусов по Фаренгейту в градусы по Цельсию:");
            Console.WriteLine($"{TempFahrToCels(70):F2}");
            Console.WriteLine($"--------------------------------{Environment.NewLine}");
            // --------------------------------------------------------
            // Блок кода, необходимый для второй части третьей задачи. 
            double initialTemp = -273.15;
            do {
                Console.WriteLine("Введите действительное значение температуры в градусах Цельсия (> -273.15):");
            } while (!double.TryParse(Console.ReadLine(), out initialTemp) || initialTemp == -273.15);
            delegateConvertTemperature[] delegateArray = { StaticTempConverters.CelsToFahr, StaticTempConverters.CelsToKelvin, StaticTempConverters.CelsToRankin, StaticTempConverters.CelsToReaumur };
            foreach (delegateConvertTemperature element in delegateArray) {
                Console.WriteLine(element?.Invoke(initialTemp));
            }
            
        }
    }
}
