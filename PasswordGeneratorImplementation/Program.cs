using PasswordGenerator;
Console.WriteLine("Welcome to my Password Generator.");
do
{
    Console.WriteLine(Service.GeneratePassword());
} while(Service.KeepGenerating());
