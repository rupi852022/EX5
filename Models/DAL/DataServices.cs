using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EX3.Models.DAL
{
    public class DataServices
    {
        //public static List<Article> articles;
        //public static List<Review> reviews;

        /*public int InsertArt(Article A, int UserId)
        {
            string artId = chackArt(A);
            if (artId==null)
            {
               Insert(A);
            }

            int affected= InsertUserArt(A.ArtId, UserId);
            return affected;

        }


        private SqlCommand creatSelectIfArtCommand(SqlConnection con, string ArtId)
        {

            string commandStr = "SELECT artId FROM Articles_2022 WHERE artId=@ArtId";
            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.AddWithValue("@artId", ArtId);

            return cmd;
        }

        public string chackArt(Article A)
        {
            SqlConnection con = null;
            try
            {
                // Connect
                con = Connect("webOsDB");

                // Create the select command
                SqlCommand selectCommand = creatSelectIfArtCommand(con, A.ArtId);

                // Create the reader
                SqlDataReader dr = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                // Read the records
                // Execute the command
                //int id = Convert.ToInt32(insertCommand.ExecuteScalar());


                string ArtId = null;

                while (dr.Read())
                {
                    ArtId = (string)dr["artId"];
                }
                dr.Close();

                return ArtId;
            }
            catch (Exception ex)
            {
                // write the error to log
                throw new Exception("failed in Log In", ex);
            }
            finally
            {
                // Close the connection
                if (con != null)
                    con.Close();
            }
        }

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
                //if (articles == null)
                //{
                //    articles = new List<Article>();
                //}
                //articles.Add(A);
            }

        }

        public int InsertUserArt(string artId, int userId)
        {
            SqlConnection con = null;
            try
            {
                // C - Connect
                con = Connect("webOsDB");

                // C - Create Command
                SqlCommand command = CreateInsertUserArt(artId, userId, con);

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
                //if (articles == null)
                //{
                //    articles = new List<Article>();
                //}
                //articles.Add(A);
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

        SqlCommand CreateInsertRev(Review R, SqlConnection con)
        {
            // INSERT INTO [Students_2022] ([name], age) VALUES('Messi', 34);
            string insertStr = "INSERT INTO [Reviews_2022] ([artId], [revName], [revEmail], [revDate], [rate], [revText]) VALUES('" + R.ArtId + "', '" + R.RevName + "', '" + R.RevEmail + "', '" + R.RevDate + "', '" + R.Rate + "', '" + R.RevText + "')";
            SqlCommand command = new SqlCommand(insertStr, con);
            // TBC - Type and Timeout
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 30;
            return command;

        }

        SqlCommand CreateInsertUserArt(string artId, int userId, SqlConnection con)
        {
            // INSERT INTO [Students_2022] ([name], age) VALUES('Messi', 34);
            string insertStr = "INSERT INTO [UsersArticles_2022] ([id], [artId]) VALUES('" + userId + "', '" + artId+ "')";
            SqlCommand command = new SqlCommand(insertStr, con);
            // TBC - Type and Timeout
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 30;
            return command;

        }

        public List<string> ReadTVsName(int userId)
        {
            SqlConnection con = null;
            try
            {
                // Connect
                con = Connect("webOsDB");

                // Create the select command
                SqlCommand selectCommand = creatSelectIftvsCommand(con, userId);

                // Create the reader
                SqlDataReader dr = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                // Read the records
                // Execute the command
                //int id = Convert.ToInt32(insertCommand.ExecuteScalar());


                List<string> TvsNames = new List<string>();

                while (dr.Read())
                {
                    string tvName = (string)dr["sName"];
                    TvsNames.Add(tvName);
                }
                dr.Close();

                return TvsNames.Distinct().ToList();

            }
            catch (Exception ex)
            {
                // write the error to log
                throw new Exception("failed in Log In", ex);
            }
            finally
            {
                // Close the connection
                if (con != null)
                    con.Close();
            }
            //if (articles == null)
            //{
            //    return TvsNames;
            //}
            
        }

        private SqlCommand creatSelectIftvsCommand(SqlConnection con, int userId)
        {

            string commandStr = "SELECT Articles_2022.sName FROM UsersArticles_2022 INNER JOIN Articles_2022 ON UsersArticles_2022.artId= Articles_2022.artId WHERE UsersArticles_2022.id=@userId";
            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.AddWithValue("@userId", userId);

            return cmd;
        }

        public List<Article> ReadArticals(string srName, int userId)
        {
            List<Article> serArt = new List<Article>();
            if (srName == null)
            {
                return serArt;
            }
            else
            {
                SqlConnection con = null;
                try
                {
                    // Connect
                    con = Connect("webOsDB");

                    // Create the select command
                    SqlCommand selectCommand = creatSelectArtCommand(con, srName, userId);

                    // Create the reader
                    SqlDataReader dr = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Read the records
                    // Execute the command
                    //int id = Convert.ToInt32(insertCommand.ExecuteScalar());




                    while (dr.Read())
                    {
                        Article A = new Article();
                        A.Serid = (string)dr["serid"];
                        A.SName = (string)dr["sName"];
                        A.ArtId = (string)dr["artId"];
                        A.Heder = (string)dr["heder"];
                        A.Summery = (string)dr["summery"];
                        A.Sorce = (string)dr["sorce"];
                        A.Pdate = (DateTime)dr["pdate"];
                        A.PicUrl = (string)dr["picUrl"];
                        A.Link = (string)dr["link"];
                        serArt.Add(A);
                    }
                    dr.Close();

                    return serArt;

                }
                catch (Exception ex)
                {
                    // write the error to log
                    throw new Exception("failed in Get art", ex);
                }
                finally
                {
                    // Close the connection
                    if (con != null)
                        con.Close();
                }

            }
        }

        private SqlCommand creatSelectArtCommand(SqlConnection con,string srName, int userId)
        {

            string commandStr = "SELECT Articles_2022.* FROM UsersArticles_2022 INNER JOIN Articles_2022 ON UsersArticles_2022.artId= Articles_2022.artId WHERE UsersArticles_2022.id=@userId AND Articles_2022.sName=@srName";
            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@srName", srName);

            return cmd;
        }

        public int InsertRev(Review R)
        {
            SqlConnection con = null;
            try
            {
                // C - Connect
                con = Connect("webOsDB");

                // C - Create Command
                SqlCommand command = CreateInsertRev(R, con);

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
                //if (reviews == null)
                //{
                //    reviews = new List<Review>();
                //}
                //reviews.Add(R);
            }
        }

        public List<Review> ReadRev(int userId)
        {
            SqlConnection con = null;
            try
            {
                // Connect
                con = Connect("webOsDB");

                // Create the select command
                SqlCommand selectCommand = creatSelectRevCommand(con, userId);

                // Create the reader
                SqlDataReader dr = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                // Read the records
                // Execute the command
                //int id = Convert.ToInt32(insertCommand.ExecuteScalar());


                List<Review> RevList = new List<Review>();

                while (dr.Read())
                {
                    Review R = new Review();
                    int id = Convert.ToInt32(dr["RevId"]);
                    R.RevId = id;
                    R.ArtId = (string)dr["ArtId"];
                    R.RevName = (string)dr["revName"];
                    R.RevEmail = (string)dr["revEmail"];
                    R.RevDate = (DateTime)dr["revDate"];
                    int rate = Convert.ToInt32(dr["rate"]);
                    R.Rate = rate;
                    R.RevText = (string)dr["revText"];
                    RevList.Add(R);
                }
                dr.Close();

                return RevList;

            }
            catch (Exception ex)
            {
                // write the error to log
                throw new Exception("failed in Log In", ex);
            }
            finally
            {
                // Close the connection
                if (con != null)
                    con.Close();
            }

        }

        private SqlCommand creatSelectRevCommand(SqlConnection con, int userId)
        {

            string commandStr = "SELECT Reviews_2022.* FROM UsersArticles_2022 INNER JOIN Articles_2022 ON UsersArticles_2022.artId= Articles_2022.artId INNER JOIN Reviews_2022 ON Reviews_2022.artId=Articles_2022.artId WHERE UsersArticles_2022.id=@userId";
            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.AddWithValue("@userId", userId);

            return cmd;
        }*/


        public int InsertUser(User U)
        {
            SqlConnection con = null;
            try
            {
                // C - Connect
                con = Connect("webOsDB");

                // C - Create Command
                SqlCommand command = CreateInsertUser(U, con);

                // E - Execute
                int affected = command.ExecuteNonQuery();

                return affected;

            }
            catch (Exception ex)
            {
                // write to log file
                throw new Exception("Failed in Insert of User", ex);
            }

            finally
            {
                // Close Connection
                con.Close();
            }
        }


        SqlCommand CreateInsertUser(User U, SqlConnection con)
        {

            string insertStr = "INSERT INTO [CoParkingUsers_2022] ([email], [password], [fName], [lName], [phoneNumber], [gender]) VALUES('" + U.Email + "', '" + U.Password + "', '" + U.FName + "', '" + U.LName + "', '" + U.PhoneNumber+ "', '" + U.Gender + "')";
            SqlCommand command = new SqlCommand(insertStr, con);
            // TBC - Type and Timeout
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 30;
            return command;

        }


        //Read
        public User ReadUser(string email)
        {
            SqlConnection con = null;
            SqlDataReader dr = null;

            try
            {
                // Connect
                con = Connect("webOsDB");

                // Create the select command
                SqlCommand selectCommand = creatSelectUserCommand(con, email, password);

                // Create the reader
                dr = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                // Read the records
                // Execute the command
                //int id = Convert.ToInt32(insertCommand.ExecuteScalar());

                if (dr == null || !dr.Read())
                {
                    return null;
                }

                int id = Convert.ToInt32(dr["id"]);
                string email = (string)dr["email"];
                string password = (string)dr["password"];
                string fName = (string)dr["lName"];
                string lName = (string)dr["fName"];
                string phoneNumber = (string)dr["phoneNumber"];
                string gender = (string)dr["gender"];



                User user = new User();

                if (dr.Read()) 
                {
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                // write the error to log
                throw new Exception("failed in Log In", ex);
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }

                // Close the connection
                if (con != null)
                    con.Close();
            }
        }

        private SqlCommand creatSelectUserCommand(SqlConnection con, string email)
        {
            string commandStr = "SELECT * FROM CoParkingUsers_2022 WHERE email=@email";
            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.AddWithValue("@email", email);

            return cmd;
        }


        SqlCommand createCommand(SqlConnection con, string CommandSTR)
        {

            SqlCommand cmd = new SqlCommand();  // create the command object
            cmd.Connection = con;               // assign the connection to the command object
            cmd.CommandText = CommandSTR;       // can be Select, Insert, Update, Delete
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandTimeout = 5; // seconds

            return cmd;
        }
    }

   

}