using System;
using System.Linq;
using System.Text;

namespace RomanNumerals
{
    internal class RomanNumeralsConverter
    {
        internal string Convert(string arabic)
        {
            StringBuilder sb = new StringBuilder();

            int arabicInt = int.Parse(arabic);

            int fiftiesModulo = HandlePartitions(sb, arabicInt, 50, RomanConstants.L);
            int tensModulo = HandlePartitions(sb, fiftiesModulo, 10, RomanConstants.X);
            int fivesModulo = HandlePartitions(sb, tensModulo, 5, RomanConstants.V);

            if (fivesModulo > 0)
            {
                sb.Append(GetStringFromPartition(RomanConstants.I, fivesModulo));
            }

            return sb.ToString();
        }

        private int HandlePartitions(StringBuilder sb, int number, int constantValue, RomanConstants constant)
        {
            int fulls = number / constantValue;
            int modulo = (number - (fulls * constantValue)) % constantValue;
            if (fulls > 0)
            {
                if (constant == RomanConstants.V && modulo == 4)
                {
                    sb.Append(RomanConstants.I.ToString() + RomanConstants.X.ToString());
                    return 0;
                }
                else
                {
                    sb.Append(string.Concat(Enumerable.Repeat(constant, fulls)));
                }
            }

            return modulo;
        }

        private string GetStringFromPartition(RomanConstants romanConsntant, int numberOfUnits)
        {
            string romanNumber = string.Concat(Enumerable.Repeat(romanConsntant, numberOfUnits));
            if (numberOfUnits > 3)
            {
                romanNumber = romanConsntant.ToString() + ++romanConsntant;
            }
            return romanNumber;
        }
    }

    

    internal enum RomanConstants
    {
        I,
        V,
        X,
        L,
        C
    }
}