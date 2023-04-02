using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorImplementation
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
                    char c = NextCharacter(requirements);
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

        private static ISet<char> CapitalPositions
        {
            get
            {
                ISet<char> positions = new HashSet<char>();
                for (int c = 65; c <= 95; c++)
                {
                    positions.Add((char)c);
                }
                return positions;
            }
        }

        private static ISet<char> DigitPositions
        {
            get
            {
                ISet<char> positions = new HashSet<char>();
                for (int c = 48; c <= 57; c++)
                {
                    positions.Add((char)c);
                }
                return positions;
            }
        }

        private static ISet<char> LowercasePositions
        {
            get
            {
                ISet<char> positions = new HashSet<char>();
                for (int c = 97; c <= 122; c++)
                {
                    positions.Add((char)c);
                }
                return positions;
            }
        }

        private static ISet<char> SpecialCharacterPositions
        {
            get
            {
                ISet<char> positions = new HashSet<char>();
                for (int c = 33; c <= 126; c++)
                {
                    if (!CapitalPositions.Contains((char)c) && !DigitPositions.Contains((char)c)
                        && !LowercasePositions.Contains((char)c))
                    {
                        positions.Add((char)c);
                    }
                }
                return positions;
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
            Random rand = new Random();
            IList<int> collection = new List<int>();
            for (int n = min; n <= max; n++)
            {
                collection.Add(n);
            }
            return collection[rand.Next(collection.Count)];
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

        private static char NextCharacter(bool[] requirements)
        {
            ISet<char> positions = new HashSet<char>();
            for (int i = 0; i < requirements.Length; i++)
            {
                if (requirements[i])
                {
                    switch (i)
                    {
                        case 0: positions.UnionWith(CapitalPositions); break;
                        case 1: positions.UnionWith(DigitPositions); break;
                        case 2: positions.UnionWith(LowercasePositions); break;
                        case 3: positions.UnionWith(SpecialCharacterPositions); break;
                    }
                }
            }
            Random rand = new Random();
            return positions.ToList()[rand.Next(positions.Count)];
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
