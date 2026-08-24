using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical3
{
    class Expence
    {
        public int expenceID;
        public string category;
        public double amount;
        public string modeofpayment;
        public DateTime expenceData;


        public Expence(int id, string category, double amount, string mode)
        {
            if (amount <= 0)
            {
                throw new Exception("Amount must be greater than zero.");
            }
            this.expenceID = id;
            this.category = category;
            this.amount = amount;
            this.modeofpayment = mode;
            this.expenceData = DateTime.Now;
        }
        public void DisplayExpense()
        {
            Console.WriteLine($"Expense ID: {expenceID}");
            Console.WriteLine($" Where you spend: {category}");
            Console.WriteLine($"Amount: {amount}");
            Console.WriteLine($"Mode of Payment: {modeofpayment}");
            Console.WriteLine($"Expense Date: {expenceData}");

        }
        public double getAmount()
        {
            return amount;
        }

        internal double GetAmount()
        {
            return amount;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Expence> expenses = new List<Expence>();
            int choice = 0;

            try
            {
                while (choice != 4)
                {
                    Console.WriteLine("Expense Management System");
                    Console.WriteLine("1. Add Expense");
                    Console.WriteLine("2. Display All Expenses");
                    Console.WriteLine("3. Total Expenses");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Expense ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Where You Spend The Money : ");
                            string category = Console.ReadLine();

                            Console.Write("Enter Amount: ");
                            double amount = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Enter Payment Mode (Cash/Online): ");
                            string mode = Console.ReadLine();

                            Expence exp = new Expence(id, category, amount, mode);
                            expenses.Add(exp);

                            Console.WriteLine("Expense added successfully!");
                            break;



                        case 2:
                            Console.WriteLine("All Expenses:");
                            foreach (var expense in expenses)
                            {
                                expense.DisplayExpense();
                                Console.WriteLine("-------------------");
                            }
                            break;



                        case 3:
                            double total = 0;
                            foreach (Expence DATA in expenses)
                            {
                                total += DATA.GetAmount();
                            }
                            Console.WriteLine($"Total Expense Amount: {total}");
                            break;



                        case 4:
                            Console.WriteLine("Exiting the program.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }



                }

            }
            catch (Exception ex)
            {
                // Handle input/other runtime errors
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}
