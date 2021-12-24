using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EX3.Models.DAL
{
    public class DataServices
    {
        public static List<Article> articles;
        public static List<Review> reviews;
        public int Insert(Article A)
        {
            SqlConnection con = null;
            try
            {
                // C - Connect
                con = Connect("webOsDB");

                // C - Create Command
                SqlCommand command = CreateInsert(A, con);

                // E - Execute
                int affected = command.ExecuteNonQuery();

                return affected;

            }
            catch (Exception ex)
            {
                // write to log file
                throw new Exception("Failed in Insert of Artical", ex);
            }

            finally
            {
               
                // C - Close Connection
                con.Close();
                if (articles == null)
                {
                    articles = new List<Article>();
                }
                articles.Add(A);
            }

        }

        SqlConnection Connect(string connectionStringName)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            return con;
        }

        SqlCommand CreateInsert(Article A, SqlConnection con)
        {
            // INSERT INTO [Students_2022] ([name], age) VALUES('Messi', 34);
            string insertStr = "INSERT INTO [Articles_2022] ([serid], [sName], [artId], [heder], [summery], [sorce], [pdate], [picUrl], [link]) VALUES('" + A.Serid + "', '" + A.SName + "', '" + A.ArtId + "', '" + A.Heder + "', '" + A.Summery + "', '" + A.Sorce + "', '" + A.Pdate + "', '" + A.PicUrl + "', '" + A.Link + "')";
            SqlCommand command = new SqlCommand(insertStr, con);
            // TBC - Type and Timeout
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 30;
            return command;

        }

        SqlCommand CreateInsertArt(Review R, SqlConnection con)
        {
            // INSERT INTO [Students_2022] ([name], age) VALUES('Messi', 34);
            string insertStr = "INSERT INTO [Reviews_2022] ([artId], [revName], [revEmail], [revDate], [rate], [revText]) VALUES('" + R.ArtId + "', '" + R.RevName + "', '" + R.RevEmail + "', '" + R.RevDate + "', '" + R.Rate + "', '" + R.RevText + "')";
            SqlCommand command = new SqlCommand(insertStr, con);
            // TBC - Type and Timeout
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 30;
            return command;

        }

        public List<string> ReadTVsName()
        {
            List<string> TvsNames = new List<string>();
            if (articles == null)
            {
                return TvsNames;
            }
            foreach (var item in articles)
            {
                TvsNames.Add(item.SName);
            }
            return TvsNames.Distinct().ToList();
        }

        public List<Article> ReadArticals(string srName)
        {
            List<Article> serArt = new List<Article>();
            if (srName == null)
            {
                return serArt;
            }
            foreach (var item in articles)
            {
                if (item.SName == srName)
                {
                    serArt.Add(item);
                }

            }
            return serArt;
        }

        public int InsertRev(Review R)
        {
            SqlConnection con = null;
            try
            {
                // C - Connect
                con = Connect("webOsDB");

                // C - Create Command
                SqlCommand command = CreateInsertArt(R, con);

                // E - Execute
                int affected = command.ExecuteNonQuery();

                return affected;

            }
            catch (Exception ex)
            {
                // write to log file
                throw new Exception("Failed in Insert of Revew", ex);
            }

            finally
            {

                // C - Close Connection
                con.Close();
                if (reviews == null)
                {
                    reviews = new List<Review>();
                }
                reviews.Add(R);
            }
        }

        public List<Review> ReadRev()
        {
            return reviews;
        }

    }

   

}