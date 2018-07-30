using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DataAccess
{
    public class DataConnectEntityFW: InterfaceForAdoEntity
    {
     
        private SqlConnection con = new SqlConnection("Data Source =TAVDESK026;Initial Catalog=BankDB;Integrated Security=True");

        public void insert(int id,string name,string accType,int balance)
        {
            con.Open();
           // Console.WriteLine(con.State);

            String query = "INSERT INTO BankData(AccountNo,AccountHolderName,AccountType,Balance) VALUES (@ID,@NAME,@TYPE,@BALANCE) ";

            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@TYPE", accType);
                cmd.Parameters.AddWithValue("@BALANCE", balance);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public void View(int id)
        {
            con.Open();
            //Console.WriteLine(con.State);
            String query = "SELECT * from BankData where AccountNo = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    Console.WriteLine("Account No:"+reader[0]+"\nName:"+ reader[1]+"\nType: "+ reader[2]+"\nBalance:"+ reader[3]);
                }
            }
            con.Close();
        }

        public int getBalance(int id)
        {
            int balance = 0;
            con.Open();
           // Console.WriteLine(con.State);
            String query = "SELECT Balance from BankData where AccountNo = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    balance = (int)(reader.GetValue(0));
                }
            }
            con.Close();
            return balance;
        }
        public string getType(int id)
        {
            string type = "";
            con.Open();
          //  Console.WriteLine(con.State);
            String query = "SELECT AccountType from BankData where AccountNo = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    type = reader.GetValue(0).ToString();
                }
            }
            con.Close();
            return type;
        }
        public void update(int id, int balance)
        {
            con.Open();
           // Console.WriteLine(con.State);
            String query = "UPDATE BankData set Balance ="+ balance+" where AccountNo=@ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

     /*   public bool IdExists(int id)
        {
            bool a = false;
            con.Open();
            Console.WriteLine(con.State);
            String query = "SELECT * from BankData where AccountNo = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                a = true;
            }
            else
            {
                a = false;
            }
            con.Close();
            return a;
        }*/

    }
}
