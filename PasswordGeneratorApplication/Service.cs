namespace PasswordGeneratorApplication
{
    public class Service
    {
        public Service(bool[] requirements, int minLength, int maxLength)
        {
            if (requirements == null) 
            {
                throw new ArgumentNullException("Requirements Length", "Requirements Not Found.");
            }
            else if (requirements.Length != 4)
            {
                throw new ArgumentOutOfRangeException("Requirements Length", "There are only 4 requirements.");
            }
            int[] characterLengths = new int[] { 0, 0, 0, 0};
            int passwordLength = GetPasswordLength(minLength, maxLength);
            bool valid = true;
            Password = "";
            do
            {
                for (int i = 0; i < passwordLength; i++) 
                {
                    char c = NextCharacter(requirements);
                    Password += c;
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
        }

        public string Password
        {
            get;
            private set;
        }

        private ISet<char> CapitalPositions
        {
            get
            {
                ISet<char> positions = new HashSet<char>();
                for (int c = 65; c <= 90; c++)
                {
                    positions.Add((char)c);
                }
                return positions;
            }
        }

        private ISet<char> DigitPositions
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

        private ISet<char> LowercasePositions
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

        private ISet<char> SpecialCharacterPositions
        {
            get
            {
                ISet<char> positions = new HashSet<char>();
                for (int c = 33; c <= 126; c++)
                {
                    positions.Add((char)c);
                }
                positions.ExceptWith(CapitalPositions);
                positions.ExceptWith(DigitPositions);
                positions.ExceptWith(LowercasePositions);
                return positions;
            }
        }

        private int GetPasswordLength(int min, int max)
        {
            if (min <= 0)
            {
                throw new ArgumentOutOfRangeException("Minimum Password Length", "The password must have at least 1 character.");
            }
            else if (max < min)
            {
                throw new ArgumentOutOfRangeException("Maximum Password Length", "Invalid Password Range.");
            }
            return GetRandomNumberBetween(min, max);
        }

        private int GetRandomNumberBetween(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(max - min + 1) + min;
        }

        private bool IsCapital(char value)
        {
            return value >= 65 && value <= 90;
        }

        private bool IsDigit(char value)
        {
            return value >= 48 && value <= 57;
        }

        private bool IsLowerCase(char value)
        {
            return value >= 97 && value <= 122;
        }

        private char NextCharacter(bool[] requirements)
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
    }
}
