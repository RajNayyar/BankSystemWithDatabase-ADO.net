using System;

namespace DataAccess
{
    public class DataConnectUsingAdo: InterfaceForAdoEntity
    {
        BankDBEntities1 entityObj = new BankDBEntities1();
        public void insert(int id, string name, string accType, int balance)
        {
            var temp = new BankData
            {
                AccountNo = id,
                AccountHolderName = name,
                AccountType = accType,
                Balance = balance
            };
            entityObj.BankDatas.Add(temp);
            entityObj.SaveChanges();
        }

        public void View(int id)
        {
            Console.WriteLine("Account no: " + entityObj.BankDatas.Find(id).AccountNo);
            Console.WriteLine("Name: " + entityObj.BankDatas.Find(id).AccountHolderName);
            Console.WriteLine("Account Type: " + entityObj.BankDatas.Find(id).AccountType);
            Console.WriteLine("Balance: " + entityObj.BankDatas.Find(id).Balance);
        }

        public int getBalance(int id)
        {
            return entityObj.BankDatas.Find(id).Balance;

        }
        public string getType(int id)
        {
            return entityObj.BankDatas.Find(id).AccountType;
        }
        public void update(int id, int balance)
        {
            entityObj.BankDatas.Find(id).Balance = balance;
        }

        /*     public bool IdExists(int id)
             {

                 return true;
             }

         */
    }
}
