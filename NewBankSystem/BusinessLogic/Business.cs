using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
    public class Business
    {
        DataConnect DB = new DataConnect();

        public void getData(int id, string name, string accType, int balance)
        {
            DB.insert(id, name, accType, balance);
        }

        public void ShowDetails(int id)
        {
            DB.View(id);
        }

        public void withdraw(int id, int amount)
        {
            int balance = DB.getBalance(id);
            string type = DB.getType(id).Trim();
            Console.WriteLine(balance+" "+type);

            if (type.Equals("S") && (balance - amount) > 1000)
            {
                balance = balance - amount;
                DB.update(id, balance);
            }
            else if (type == "C" && balance - amount >= 0)
            {
                balance = balance - amount;
                DB.update(id, balance);
            }
            else if (type == "D" && balance - amount >= -10000)
            {
                balance = balance - amount;
                DB.update(id, balance);
            }
            else
            {
                Console.WriteLine("Balance Insufficient");
            }
        }

        public void deposit(int id, int amount)
        {
            int balance = DB.getBalance(id);
            balance = balance + amount;
            DB.update(id, balance);
        }

        public float interest(int id , int amount)
        {
            int balance = DB.getBalance(id);
            string type = DB.getType(id).Trim();
            if (type == "S")
            {
                return balance * 4 / 100;

            }
            else if (type == "C")
            {
                return balance * 1 / 100;
            }
            else
            {
                return 0;
            }
        }
    /*    public int checkIfExists(int id)
        {
            if(DB.IdExists(id))
            {
                return false;
            }
            return true;
        }*/

    }
}

