using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class Service
    {
        public static string GeneratePassword()
        {
            bool[] requirements = new bool[] { CapitalLettersRequired(), DigitsRequired(), LowercaseLettersRequired(), SpecialCharactersRequired() };
            int[] characterLengths = new int[] { 0, 0, 0, 0 };
            int passwordLength = GetPasswordLength();
            bool valid = true;
            string password = "";
            do
            {
                for (int i = 0; i < passwordLength; i++)
                {
                    char c = NextCharacter();
                    password += c;
                    if (IsCapital(c))
                    {
                        characterLengths[0]++;
                    }
                    else if (IsDigit(c))
                    {
                        characterLengths[1]++;
                    }
                    else if (IsLowerCase(c))
                    {
                        characterLengths[2]++;
                    }
                    else
                    {
                        characterLengths[3]++;
                    }
                }
                for (int j = 0; j < requirements.Length && valid; j++)
                {
                    valid = requirements[j] ? characterLengths[j] > 0 : characterLengths[j] == 0;
                }
            } while (!valid);
            return password;
        }

        public static bool KeepGenerating()
        {
            while (true)
            {
                Console.WriteLine("Do you want another password generated? ");
                string answer = Console.ReadLine();
                if ("NO" == answer.ToUpper() || "N" == answer.ToUpper())
                {
                    return false;
                }
                else if ("YES" == answer.ToUpper() || "Y" == answer.ToUpper())
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("This is a yes or no question. Try again.");
                }
            }
        }

        private static bool CapitalLettersRequired()
        {
            while (true)
            {
                Console.WriteLine("Requires Capital Letters: True or False");
                try
                {
                    return Convert.ToBoolean(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is a true or false question. Try Again.");
                }
            }
        }

        private static bool DigitsRequired()
        {
            while (true)
            {
                Console.WriteLine("Requires Digits: True or False");
                try
                {
                    return Convert.ToBoolean(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is a true or false question. Try Again.");
                }
            }
        }

        private static int GetMaximumLength(int minimumLength)
        {
            while (true)
            {
                Console.WriteLine("Enter the maximum length:");
                try
                {
                    int value = Convert.ToInt32(Console.ReadLine());
                    if (value < minimumLength)
                    {
                        Console.WriteLine("The maximum length must be at least the minimum length.");
                    }
                    else
                    {
                        return value;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The answer must be a whole number. Try Again.");
                }
            }
        }

        private static int GetMinimumPasswordLength()
        {
            while (true)
            {
                Console.WriteLine("Enter a minimum length: ");
                try
                {
                    int value = Convert.ToInt32(Console.ReadLine());
                    if (value <= 0)
                    {
                        Console.WriteLine("The password length must be at least 1.");
                    }
                    else
                    {
                        return value;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The answer must be a whole number. Try Again.");
                }
            }
        }

        private static int GetPasswordLength()
        {
            int min = GetMinimumPasswordLength();
            return GetRandomNumberBetween(min, GetMaximumLength(min));
        }

        private static int GetRandomNumberBetween(int min, int max)
        {
            Random random = new Random();
            return random.Next(max - min + 1) + min;
        }

        private static bool IsCapital(char value)
        {
            return value >= 65 && value <= 90;
        }

        private static bool IsDigit(char value)
        {
            return value >= 48 && value <= 57;
        }

        private static bool IsLowerCase(char value)
        {
            return value >= 97 && value <= 122;
        }

        private static bool LowercaseLettersRequired()
        {
            while (true)
            {
                Console.WriteLine("Requires Lowercase Letters: True or False");
                try
                {
                    return Convert.ToBoolean(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is a true or false question. Try Again.");
                }
            }
        }

        private static char NextCharacter()
        {
            return (char)GetRandomNumberBetween(33, 126);
        }

        private static bool SpecialCharactersRequired()
        {
            while (true)
            {
                Console.WriteLine("Requires Special Characters: True or False");
                try
                {
                    return Convert.ToBoolean(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is a true or false question. Try Again.");
                }
            }
        }
    }
}
