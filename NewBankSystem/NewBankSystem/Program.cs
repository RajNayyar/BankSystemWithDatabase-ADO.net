using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
namespace NewBankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Business businessObj = new Business();

            int __option = 0;
            int __furtherOption = 1;
            while (true)
            {
                Console.WriteLine("Enter 1 to Create New account and 2 to access exisiting\n3 to exit.");

                __option = int.Parse(Console.ReadLine());

                if (__option == 1)
                {

                    Console.WriteLine("Enter Id");
                    int id = int.Parse(Console.ReadLine());
           
                        Console.WriteLine("Enter Name");
                        string name = (Console.ReadLine());

                        Console.WriteLine("Enter Account Type: S/C/D  (SAVINGS/CURRENT/DMAT)");
                        string type = Console.ReadLine();

                        Console.WriteLine("Enter Balance");
                        int balance = int.Parse(Console.ReadLine());

                        businessObj.getData(id, name, type, balance);
                    

                }
                else if (__option == 2)
                {
                    Console.WriteLine("Enter Id");
                    int id = int.Parse(Console.ReadLine());
                    while (true)
                    {
                        

                        businessObj.ShowDetails(id);
                        Console.WriteLine("Enter 1 to withdraw");

                        Console.WriteLine("Enter 2 to deposit");

                        Console.WriteLine("Enter 3 to Interest");

                        Console.WriteLine("Enter 4 to exit");

                        __furtherOption = int.Parse(Console.ReadLine());


                      
                        if (__furtherOption == 1)
                        {
                            Console.WriteLine("enter amount");
                            int amount = int.Parse(Console.ReadLine());
                            businessObj.withdraw(id, amount);
                            businessObj.ShowDetails(id);
                        }
                        else if (__furtherOption == 2)
                        {
                            Console.WriteLine("enter amount");
                            int amount = int.Parse(Console.ReadLine());
                            businessObj.deposit(id, amount);
                            businessObj.ShowDetails(id);
                        }
                        else if (__furtherOption == 3)
                        {
                      
                            Console.WriteLine("Interest: " + businessObj.interest(id));
                        }
                        else if (__furtherOption == 4)
                        {
                            break;
                        }
                    }
                }
                else if (__option == 3)
                {
                    break;
                }
            }
          

            Console.ReadKey();
        }
    }
}
