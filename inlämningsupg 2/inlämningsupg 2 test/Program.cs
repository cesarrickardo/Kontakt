using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace inlämningsupg_2_test
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("1: InsertCustomers");

            Console.WriteLine("2: InsertProduct");

            Console.WriteLine("3: Update");

            Console.WriteLine("4: Trigger");
            int Button = int.Parse(Console.ReadLine());

            // button 1 OK !
            if (Button == 1)
            #region
            {
                Console.WriteLine("Add your id");
                string ID = Console.ReadLine();
                Console.WriteLine("Add your Companyname");
                string Companyname = Console.ReadLine();
                Console.WriteLine("Add your name");
                string Name = Console.ReadLine();

                string cns = @"Server=(localdb)\MSSQLLocalDB;Database=NORTHWND;Trusted_Connection=Yes";
                SqlConnection cn = new SqlConnection(cns);
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertCustomer";
                cmd.Parameters.AddWithValue("@CustomerID", ID);
                cmd.Parameters.AddWithValue("@CompanyName", Companyname);
                cmd.Parameters.AddWithValue("@ContactName", Name);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            #endregion
            // button 2 OK !!
            if (Button == 2)
            #region
            {
                Console.WriteLine("Add the Productname");
                string Productname = Console.ReadLine();
                Console.WriteLine("Add price");
                string Price = Console.ReadLine();

                string cns = @"Server=(localdb)\MSSQLLocalDB;Database=NORTHWND;Trusted_Connection=Yes";
                SqlConnection cn = new SqlConnection(cns);
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertProduct";
                cmd.Parameters.AddWithValue("@ProductName", Productname);
                cmd.Parameters.AddWithValue("@Unitprice", Price);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            #endregion
            if (Button == 3)
            // button 3 OK !!??????
            #region
            {

                Console.WriteLine("Add the ProductID");
                int ProductID = int.Parse(Console.ReadLine());
                Console.WriteLine("Add price");
                var Price = Console.ReadLine();

                string cns = @"Server=(localdb)\MSSQLLocalDB;Database=NORTHWND;Trusted_Connection=Yes";
                SqlConnection cn = new SqlConnection(cns);
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateProductPrice";
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@Unitprice", Price);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            #endregion

            //sadasdasd
            // Button 4 OK ?!?!
            if (Button == 4)
            {
                #region
                using (SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=NORTHWND;Trusted_Connection=Yes"))
                using (SqlCommand command = connection.CreateCommand())
                {
                   command.CommandText = "Select * from tblCustomerChanges";

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("ID: " + reader.GetString(0) + "    Old contact name: " + reader.GetString(1) +
                                "|   New contact name: " + reader.GetString(2));
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to exit");
                    }
                    connection.Close();
                }
                Console.ReadKey();
            }
            #endregion

        }
    }
}