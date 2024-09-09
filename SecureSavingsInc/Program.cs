using SecureSavingsInc.Models;
using System;
using SecureSavingsInc.Data;
using SecureSavingsInc.Constants;



Bank bank = new Bank();

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("Welcome to the Bank Simulation");
    Console.WriteLine("1. Create Account");
    Console.WriteLine("2. Deposit");
    Console.WriteLine("3. Withdraw");
    Console.WriteLine("4. Transfer");
    Console.WriteLine("5. View Balance");
    Console.WriteLine("6. Exit");
    Console.Write("Select an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            CreateAccount(bank);
            break;
        case "2":
            Deposit(bank);
            break;
        case "3":
            Withdraw(bank);
            break;
        case "4":
            Transfer(bank);
            break;
        case "5":
            ViewBalance(bank);
            break;
        case "6":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Please select again.");
            break;
    }
}

void CreateAccount(Bank bank)
{
    Console.Clear();
    Console.WriteLine("Create Account");
    Console.Write("Enter account holder's name: ");
    string name = Console.ReadLine();

    decimal initialBalance;
    Console.WriteLine("Enter the initial balance that you want to deposit (minimum $10)");
    while ((initialBalance = decimal.Parse(Console.ReadLine())) < 10)
    {
        if (initialBalance >= 10)
            break;
    }
    Console.WriteLine("Select account type:");
    Console.WriteLine("1. Savings Account");
    Console.WriteLine("2. Checking Account");
    string accountType = Console.ReadLine();

    BankAccount account = null;

    switch (accountType)
    {
        case "1":
            account = new SavingsAccount(name, initialBalance, Constants.InterestRate);
            break;

        case "2":
            account = new CheckingAccount(name, initialBalance, Constants.MaxOverdraft);
            break;

        default:
            Console.WriteLine("Invalid account type selected.");
            return;
    }

    bank.AddAccount(account);
    Console.WriteLine($"Account created successfully. Account Number: {account.AccountNumber}");
    Console.ReadKey();
}

void Deposit(Bank bank)
{
    Console.Clear();
    Console.WriteLine("Deposit");
    BankAccount account = FindAccount(bank);

    if (account != null)
    {
        Console.Write("Enter amount to deposit: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        account.Deposit(amount);
        Console.WriteLine($"Deposit successful. New balance: {account.Balance:C}");
    }

    Console.ReadKey();
}

void Withdraw(Bank bank)
{
    Console.Clear();
    Console.WriteLine("Withdraw");
    BankAccount account = FindAccount(bank);

    if (account != null)
    {
        Console.Write("Enter amount to withdraw: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        try
        {
            account.Withdraw(amount);
            Console.WriteLine($"Withdrawal successful. New balance: {account.Balance:C}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    Console.ReadKey();
}

void Transfer(Bank bank)
{
    Console.Clear();
    Console.WriteLine("Transfer");
    Console.WriteLine("From Account:");
    BankAccount fromAccount = FindAccount(bank);

    if (fromAccount != null)
    {
        Console.WriteLine("To Account:");
        BankAccount toAccount = FindAccount(bank);

        if (toAccount != null)
        {
            Console.Write("Enter amount to transfer: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                fromAccount.Transfer(toAccount, amount);
                Console.WriteLine("Transfer successful.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    Console.ReadKey();
}

void ViewBalance(Bank bank)
{
    Console.Clear();
    Console.WriteLine("View Balance");
    BankAccount account = FindAccount(bank);

    if (account != null)
    {
        Console.WriteLine($"Account Number: {account.AccountNumber}");
        Console.WriteLine($"Account Holder: {account.AccountHolderName}");
        Console.WriteLine($"Balance: {account.Balance:C}");
    }

    Console.ReadKey();
}

BankAccount FindAccount(Bank bank)
{
    Console.Write("Enter account number: ");
    string accountNumber = Console.ReadLine();
    BankAccount account = bank.FindAccount(accountNumber);

    if (account == null)
    {
        Console.WriteLine("Account not found.");
    }

    return account;
}
