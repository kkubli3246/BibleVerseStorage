using BibleVerseApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BibleVerseApplication.Services.Data
{
    //This is the Data Access Object, This is used to "Access" the Databases and all of its information. 
    public class SecurityDAO
    {

        /*This DAO method is used to Add BibleVerse Objects to the SQL table. 
         * no return types for this method, as long as the Data validation is passed the SQL row gets created
         */
        public void AddVerse(BibleVerse verse)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BibleVerseApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //Open SQL connection to DB
            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                conn.Open();

                //SQL Query to insert a Bible verse into DB if the Current Bible Verse Doesn't exist
                string query = 
                    string.Format(
                    "BEGIN " +
                        "IF NOT EXISTS (SELECT * FROM BibleVerse " +
                            "WHERE TESTIMENT = '{0}' " +
                            "AND BOOK = '{1}' " +
                            "AND CHAPTER = {2} " +
                            "AND VERSE= {3} " +
                            "AND TEXT = '{4}' " +
                            ") " +
                        "BEGIN " +
                            "INSERT INTO BibleVerse(TESTIMENT,BOOK,CHAPTER,VERSE,TEXT) " +
                            "VALUES('{0}','{1}',{2},{3}," +
                            "'{4}') " +
                            "END " +
                    "END",
                    verse.Testiment, verse.Book, verse.Chapter, verse.Verse, verse.Text.Replace("'","''")//Text.Replace for single quote squl error
                    );

                using (SqlCommand command = new SqlCommand(query,conn)) 
                {
                    using (SqlDataReader sqlDataReader = command.ExecuteReader())
                    {
                        sqlDataReader.Read();
                    }
                }
                conn.Close();
            }
            
        }

        /*This method is used  to Search the SQL DB for a matching BibleVerse Object.  
         *Return Type is Tuple with Bible Verse and bool
         *Bool depends on the "Passed" or "Failed" View that get returned
         *The BibleVerse, is returned with the updated BibleVerse Text
         */
        public Tuple<BibleVerse, bool> SearchVerse(BibleVerse verse) 
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BibleVerseApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            //This is the returned Tuple When the
            var failed = Tuple.Create(verse,false);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query =
                   string.Format(
                   "SELECT * FROM BibleVerse " +
                           "WHERE TESTIMENT = '{0}' " +
                           "AND BOOK = '{1}' " +
                           "AND CHAPTER = {2} " +
                           "AND VERSE= {3}", verse.Testiment, verse.Book, verse.Chapter, verse.Verse);

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //This is the 'TEXT' value that is pulled from the SQL DB.
                            string returnData = reader.GetValue(5).ToString();

                            //This takes the Input values from the User and adds the Verse text values
                            var newVerse = verse;
                            newVerse.Text = returnData;

                            //Creates a tuple with the updated BibleVerse and true bool value
                            var passed = Tuple.Create(newVerse, true);
                            return passed;
                        }
                        return failed;
                    }
                }
            }
               
        }
    }
}