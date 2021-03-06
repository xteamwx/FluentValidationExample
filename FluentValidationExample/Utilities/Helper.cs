using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FluentValidationExample.Utilities
{
    public static class Helper
    {        public static bool IsValidSIN(int sin)
        {
            if (sin < 0 || sin > 999999998) return false;

            int checksum = 0;
            for (int i = 4; i != 0; i--)
            {
                checksum += sin % 10;
                sin /= 10;

                int addend = 2 * (sin % 10);

                if (addend >= 10) addend -= 9;

                checksum += addend;
                sin /= 10;
            }

            return (checksum + sin) % 10 == 0;
        }


        public static bool HasValidPassword(string pw)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");
            return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
        }

    }
}
