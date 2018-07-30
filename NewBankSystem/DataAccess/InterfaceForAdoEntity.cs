using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface InterfaceForAdoEntity
    {
        void insert(int id, string name, string accType, int balance);

        void View(int id);


        int getBalance(int id);

        string getType(int id);

        void update(int id, int balance);
      
    }
}
