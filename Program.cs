Console.WriteLine("Welcome to my password generator!!!");
do
{
    string password = GeneratePassword(GetLength());
    Console.WriteLine("Your password is: " + password);
} while (ValidateKeepGoing());

static string GeneratePassword(int length)
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

static int GetLength()
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

static int GetPasswordMin()
{
    bool valid;
    int minimum = 3;
    do
    {
        try
        {
            Console.WriteLine("Enter a minimum: ");
            minimum = Convert.ToInt32(Console.ReadLine());
            valid = minimum >= 4;
            if (!valid)
            {
                Console.WriteLine("The minimum must be at least 4. Try Again");
            }
        }
        catch (FormatException)
        {
            valid = false;
            Console.WriteLine("The input must be an integer. Try Again.");
        }
    } while (!valid);
    return minimum;
}

static int GetPasswordMax(int min)
{
    bool valid;
    int maximum = 0;
    do
    {
        try
        {
            Console.WriteLine("Enter a maximum: ");
            maximum = Convert.ToInt32(Console.ReadLine());
            valid = maximum >= min;
            if (!valid)
            {
                Console.WriteLine("The maximum must be at least " + min + ". Try Again");
            }
        }
        catch (FormatException)
        {
            valid = false;
            Console.WriteLine("The input must be an integer. Try Again.");
        }
    } while (!valid);
    return maximum;
}

static bool IsCapital(char c)
{
    return c >= 'A' && c <= 'Z';
}

static bool IsDigit(char c)
{
    return c >= '0' && c <= '9';
}

static bool IsLowerCase(char c)
{
    return c >= 'a';
}

static bool IsSpecialCharacter(char c)
{
    return c <= '&';
}

static bool ValidateKeepGoing()
{
    bool valid;
    string answer;
    do
    {
        Console.WriteLine("Do you want to keep going? ");
        answer = Console.ReadLine();
        valid = (answer != null) && (answer.ToLower() == "y" || answer.ToLower() == "n" || answer.ToLower() == "yes" || answer.ToLower() == "no");
        if (!valid)
        {
            Console.WriteLine("This is a yes or no question.");
        }
    } while (!valid);
    return answer.ToLower() == "y" || answer.ToLower() == "yes";
}
