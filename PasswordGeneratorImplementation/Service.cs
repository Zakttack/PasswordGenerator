using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class Service
    {
        public static string GeneratePassword(int length)
        {
            int specialCount = 0;
            int numberCount = 0;
            int lowercaseCount = 0;
            int uppercaseCount = 0;
            string password;
            do
            {
                password = "";
                for (int i = 0; i < length; i++)
                {
                    char c = GetNextCharacter();
                    if (IsCapital(c))
                    {
                        uppercaseCount++;
                    }
                    else if (IsDigit(c))
                    {
                        numberCount++;
                    }
                    else if (IsLowerCase(c))
                    {
                        lowercaseCount++;
                    }
                    else if (IsSpecialCharacter(c))
                    {
                        specialCount++;
                    }
                    password += c;
                }
            } while (specialCount < 1 || numberCount < 1 || lowercaseCount < 1 || uppercaseCount < 1);
            return password;
        }

        public static int GetLength()
        {
            Random rand = new Random();
            int min = GetPasswordMin();
            int max = GetPasswordMax(min);
            return rand.Next(max - min + 1) + min;
        }

        static char GetNextCharacter()
        {
            Random random = new Random();
            int value;
            do
            {
                value = random.Next(88) + 35;
            } while ((value > '&' && value < '0') || (value > '9' && value < 'A') || (value > 'Z' && value < 'a'));
            return (char)value;
        }
    }
}
