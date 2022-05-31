using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConverterWPF
{
    static class Convert
    {
        public static class Global
        {
            public static string[] alphabet = {"0","1","2","3","4","5","6","7","8","9",
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O",
            "P","Q","R","S","T","U","V","W" };
        };

        public static string decToImal(int convertedNumber, int baseNumber)
        {
            string returnedNumber = "";
            int remainder = 0;
            while (convertedNumber > 0)
            {
                remainder = convertedNumber % baseNumber;
                convertedNumber -= remainder;
                convertedNumber /= baseNumber;
                returnedNumber = Global.alphabet[remainder] + returnedNumber;
            }
            return returnedNumber;
        }

        public static double imalToDec(string convertedNumber, double baseNumber)
        {
            convertedNumber = convertedNumber.ToUpper();
            double returnedNumber = 0;
            for (int i = 0; i < convertedNumber.Length; i++)
            { 
                int index = Array.IndexOf(Global.alphabet, convertedNumber[i].ToString());
                returnedNumber += index * Math.Pow(baseNumber, convertedNumber.Length - i - 1);
            }
            return returnedNumber;
        }
    }
}
