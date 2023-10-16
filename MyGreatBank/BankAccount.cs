using System.Text;

namespace MyGreatBank
{
    internal class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance) // Consturctor
        {
            Owner = name;

            // Initial balance should be a Deposit
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdarwal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive.");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("You do not have enough funds for this withdrawal.");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            // Header
            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var transaction in allTransactions)
            {
                // Rows
                string formattedAmount = String.Format("{0:C}", transaction.Amount);
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{formattedAmount}\t{transaction.Notes}");
            }
            return report.ToString();
        }

    }
}
