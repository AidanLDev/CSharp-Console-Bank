// See https://aka.ms/new-console-template for more information

namespace MyGreatBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Aidan", 250000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");
            account.MakeWithdarwal(120, DateTime.Now, "HamBurger");

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}

