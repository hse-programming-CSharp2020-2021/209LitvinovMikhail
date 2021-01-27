using System;
using System.Collections.Generic;
using System.Text;

namespace Task3 {
    class TemperatureConverterImp {

        public double CelsToFahr(double temperatureToConvert) {
            return ((double)9 / 5) * temperatureToConvert + 32;
        }

        public double FahrToCels(double temperatureToConvert) {
            return ((double)5 / 9) * (temperatureToConvert - 32);
        }

    }
}
