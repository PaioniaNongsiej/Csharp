using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DisconnectedArchitecture1
{
    class Program

    {

        public static SqlConnection con;

        public static SqlDataAdapter da;

        public static DataSet ds;

        public static DataTable dt;

        static void Main(string[] args)

        {

            //InsertData();

            // SelectData();

            addTable_To_Dataset();

            //procedureCall();

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

                con = getConnection();

                da = new SqlDataAdapter("select * from dept", con);

                ds = new DataSet();

                da.Fill(ds, "TrainingDB"); dt = ds.Tables["TrainingDB"];                 //to access the data table

                foreach (DataRow drow in dt.Rows)

                {

                    foreach (DataColumn dcol in dt.Columns)

                    {

                        Console.Write(drow[dcol]);

                        Console.Write(" ");

                    }

                    Console.WriteLine();

                }
            }

            catch (SqlException se)

            {

                Console.WriteLine(se.Message);

            }

        }
        public static void InsertData()

        {

            con = getConnection();             //get the data into the dataset

            da = new SqlDataAdapter("select * from DEPT", con);

            ds = new DataSet();

            da.Fill(ds, "TrainingDB"); dt = ds.Tables["TrainingDB"];             //let us add one new row for the datatable in the dataset

            DataRow row = ds.Tables["TrainingDB"].NewRow();

            string DeptNo, Dname, LOC;

            Console.WriteLine("Enter department no:");

            DeptNo = Console.ReadLine();

            Console.WriteLine("Enter department Name:");

            Dname = Console.ReadLine();

            Console.WriteLine("Enter location :");

            LOC = Console.ReadLine();

            //give values to the new row

            row["deptno"] = DeptNo;

            row["dName"] = Dname;

            row["loc"] = LOC;             //add the new row to the datatable

            ds.Tables["TrainingDB"].Rows.Add(row);

            SqlCommandBuilder scb = new SqlCommandBuilder(da);

            da.InsertCommand = scb.GetInsertCommand(); da.Update(ds, "TrainingDB"); 
            Console.WriteLine("--------After Insertion---------"); da.Fill(ds); // to refresh the changes and reflect it              SelectData();

            //da = new SqlDataAdapter("select * from shippers", con);

            //da.Fill(ds, "NorthwindShippers");

            //dt = ds.Tables["NorthwindShippers"]; // to point ot the beginning of the datatable

            //                                     //to access the data table in iterations

            //foreach (DataRow drow1 in dt.Rows)

            //{

            //    foreach (DataColumn dcol1 in dt.Columns)

            //    {

            //        Console.Write(drow1[dcol1]);

            //        Console.Write(" ");

            //    }

            //    Console.WriteLine();

        }
        public static void addTable_To_Dataset()

        {

            Console.WriteLine("Adding a Table to the Dataset....");

            con = getConnection();

            da = new SqlDataAdapter("select * from DEPT", con);

            ds = new DataSet();

            da.Fill(ds, "TrainingDB");

            dt = ds.Tables["TrainingDB"];

            foreach (DataRow row1 in dt.Rows)

            {

                foreach (DataColumn col1 in dt.Columns)

                {

                    Console.Write(row1[col1]);

                    Console.Write(" ");

                }

                Console.WriteLine();

            }

        }
        public static void procedureCall()

        {

            con = getConnection();

            da = new SqlDataAdapter("[Ten Most Expensive Products]", con);

            da.SelectCommand.CommandType = CommandType.StoredProcedure; dt = new DataTable();

            da.Fill(dt);

            foreach (DataRow r in dt.Rows)

            {

                foreach (DataColumn c in dt.Columns)

                {

                    Console.Write(r[c]);

                    Console.Write(" ");

                }

                Console.WriteLine();

            }

        }

    }
}
