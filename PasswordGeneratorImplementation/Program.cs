Console.WriteLine("Welcome to my password generator!!!");
do
{
    string password = GeneratePassword(GetLength());
    Console.WriteLine("Your password is: " + password);
} while (ValidateKeepGoing());


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
