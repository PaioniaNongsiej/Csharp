using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DissconnectionArchitecture
{
    class Program
    {
        static void Main(string[] args)

        {

            SqlConnection con;

            SqlDataAdapter da;

            try

            {

                con = new SqlConnection("data source=192.168.10.18; database=TrainingDB; user id=  TrainingDB_User; password= 'X1;xbhpUN#a5eGHt4ohF' ;");

                da = new SqlDataAdapter("select * from dept", con);

                con.Open();

                DataSet ds = new DataSet();

                da.Fill(ds, "TrainingDB"); DataTable dt = ds.Tables["TrainingDB"];                 //to access the data table

                foreach (DataRow drow in dt.Rows)

                {

                    foreach (DataColumn dcol in dt.Columns)

                    {

                        Console.Write(drow[dcol]);

                        Console.Write(" ");

                    }

                    Console.WriteLine();

                }                 //let us add one new row for the datatable in the dataset

                DataRow row = ds.Tables["TrainingDB"].NewRow(); //give values to the new row                

                row["deptno"] = "60";
                row["dname"] = "IT";
                row["loc"] = "Shillong";                 //add the new row to the datatable

                ds.Tables["TrainingDB"].Rows.Add(row);

                SqlCommandBuilder scb = new SqlCommandBuilder(da);

                da.InsertCommand = scb.GetInsertCommand();

                da.Update(ds, "TrainingDB"); Console.WriteLine("--------After Insertion---------");

                da.Fill(ds); // to refresh the changes and reflect it 

                da = new SqlDataAdapter("select * from DEPT", con);

                da.Fill(ds, "TrainingDB");

                dt = ds.Tables["TrainingDB"]; // to point ot the beginning of the datatable

                //to access the data table in iterations

                foreach (DataRow drow1 in dt.Rows)

                {

                    foreach (DataColumn dcol1 in dt.Columns)

                    {

                        Console.Write(drow1[dcol1]);

                        Console.Write(" ");

                    }

                    Console.WriteLine();

                }
            }

            catch (SqlException se)

            {

                Console.WriteLine(se.Message);

            }

            Console.Read();

        }

    }
}

