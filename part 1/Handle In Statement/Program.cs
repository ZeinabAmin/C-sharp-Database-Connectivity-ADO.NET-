using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;

public class Program
{
    static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;"; // Replace with your actual connection string

    static void DeleteContacts(string ContactIDs)
    {

        SqlConnection connection = new SqlConnection(connectionString);

        string query = @"Delete Contacts 
                                where ContactID in (" + ContactIDs + ")";

        SqlCommand command = new SqlCommand(query, connection);


        try
        {
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Record Deleted successfully.");
            }
            else
            {
                Console.WriteLine("No Records Deleted.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }

    public static void Main()
    {


        DeleteContacts("8,9,10");

        Console.ReadKey();

    }

}
