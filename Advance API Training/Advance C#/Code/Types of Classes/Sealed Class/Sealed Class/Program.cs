using System;

namespace Sealed_Class
{
    /// <summary>
    /// Sealed class representing a bank account.
    /// </summary>
    sealed class BankAccount
    {
        // Private field to store the balance 
        private double _balance;

        /// <summary>
        /// Initializes a new instance of the BankAccount class with the specified initial balance.
        /// </summary>
        /// <param name="initialBalance">The initial balance of the bank account.</param>
        public BankAccount(double initialBalance)
        {
            _balance = initialBalance;
        }


        /// <summary>
        /// Deposits the specified amount into the bank account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        public void Deposit(double amount)
        {
            _balance += amount;
            Console.WriteLine($"Deposited ${amount}. Current balance: ${_balance}");
        }


        /// <summary>
        /// Withdraws the specified amount from the bank account if sufficient funds are available.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public void Withdraw(double amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Withdrawn ${amount}. Current balance: ${_balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }

        /// <summary>
        /// Returns the current balance of the bank account.
        /// </summary>
        /// <returns>The current balance.</returns>
        public double GetBalance()
        {
            return _balance;
        }
    }

    /// <summary>
    /// Class containing the Main method, serving as the entry point of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank Account Demo!");

            // Create a bank account with initial balance of $0
            BankAccount account = new BankAccount(0);

            // Interactive loop for user interactions
            while (true)
            {
                Console.WriteLine("\n1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter amount to deposit: $");
                        double depositAmount;
                        if (double.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            // Depositing the specified amount into the bank account
                            account.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid amount.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter amount to withdraw: $");
                        double withdrawAmount;
                        if (double.TryParse(Console.ReadLine(), out withdrawAmount))
                        {
                            // Withdrawing the specified amount from the bank account
                            account.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid amount.");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Current balance: ${account.GetBalance()}");
                        break;

                    case "4":
                        Console.WriteLine("Exiting the program...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }
    }
}
