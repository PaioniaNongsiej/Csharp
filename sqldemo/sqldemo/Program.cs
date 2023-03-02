using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace sqldemo
{
    class Program
    {
        public static SqlConnection con;

        public static SqlCommand cmd;

        public static SqlDataReader dr;

        static void Main(string[] args)

        {
            //InsertData();
            //DeleteData();
            //UpdateData();
            SelectData();

            Console.Read();

        }
        public static SqlConnection getConnection()

        {

            con = new SqlConnection("data source=192.168.10.18; database=TrainingDB; user id=  TrainingDB_User; password= 'X1;xbhpUN#a5eGHt4ohF' ;");

            con.Open();

            return con;

        }
        public static void SelectData()

        {

            try

            {

                con = getConnection(); // gets the connection details after executing the getConnection method

                cmd = new SqlCommand("select * from Emp3", con);

                dr = cmd.ExecuteReader();

                while (dr.Read())

                {

                    //Console.WriteLine(dr[0] + " |" + dr[1] + "| " + dr[2]);

                    Console.WriteLine("--------------------");

                    Console.WriteLine("Employee Id : {0}", dr[0]);

                    Console.WriteLine("Employee Name : {0}", dr[1]);

                    Console.WriteLine("Employee job : {0}", dr[2]);

                    Console.WriteLine("Employee MGR : {0}", dr[3]);

                    Console.WriteLine("Employee Hiredate : {0}", dr[4]);

                    Console.WriteLine("Employee salary : {0}", dr[5]);

                }

            }

            catch (SqlException se)

            {

                Console.WriteLine("Some Error Occured.. Try after sometime");

                Console.WriteLine(se.Message);

            }

        }
        public static void InsertData()

        {

            con = getConnection();

            cmd = new SqlCommand("insert into emp3 values(100,'Paionia','student',7839,'2023/02/09',3000,300,30)");

            cmd.Connection = con; 
            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)

            {

                Console.WriteLine("Record Inserted Successfully.");

            }

            else

                Console.WriteLine("Not Inserted..");

        }




        public static void DeleteData()

        {

            con = getConnection();

            Console.WriteLine("Enter Employee id :");

            int eid = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd1 = new SqlCommand("Select * from emp3 where empno=@ecode");

            cmd1.Parameters.AddWithValue("@ecode", eid);

            cmd1.Connection = con; SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())

            {

                for (int i = 0; i < dr1.FieldCount; i++)

                {

                    Console.WriteLine(dr1[i]);

                }

            }

            con.Close();

            Console.WriteLine("Are you sure to delete this employee ? Y/N");

            string answer = Console.ReadLine();

            if (answer == "y" || answer == "Y")

            {

                cmd = new SqlCommand("delete from emp3 where empno=@ecode", con);

                cmd.Parameters.AddWithValue("@ecode", eid);

                con.Open(); int rw = cmd.ExecuteNonQuery();

                if (rw > 0)

                    Console.WriteLine("Record Deleted..");

                else

                    Console.WriteLine("Not deleted");

            }
        }

        public static void UpdateData()

        {

            con = getConnection();

            Console.WriteLine("Enter Employee id :");

            int eid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employee salary :");

            int salary = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd1 = new SqlCommand("Select * from emp3 where empno=@ecode");

            cmd1.Parameters.AddWithValue("@ecode", eid);

            cmd1.Connection = con; SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())

            {

                for (int i = 0; i < dr1.FieldCount; i++)

                {

                    Console.WriteLine(dr1[i]);

                }

            }

            con.Close();

            Console.WriteLine("Are you sure to update this employees data ? Y/N");

            string answer = Console.ReadLine();

            if (answer == "y" || answer == "Y")

            {

                cmd = new SqlCommand("update emp3 set sal=@esal where empno=@ecode", con);

                cmd.Parameters.AddWithValue("@ecode", eid);
                cmd.Parameters.AddWithValue("@esal", salary);

                con.Open(); int rw = cmd.ExecuteNonQuery();

                if (rw > 0)

                    Console.WriteLine("Record updated..");

                else

                    Console.WriteLine("Not updated");

            }
        }
    }
}
