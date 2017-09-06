using DidiDerDenker.BirdsEyeView.Objects;
using DidiDerDenker.BirdsEyeView.Objects.Collections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Database
{
    public class DatabaseConnection
    {
        #region Fields
        private readonly string ConnectionString;

        private static DatabaseConnection defaultInstance;
        #endregion

        #region Constructor
        public DatabaseConnection()
            :this(@"Data Source=JonasCurth.de;Initial Catalog=DD_DATABASE;User ID=Database;Password=tesT-Ad1")
        { }

        public DatabaseConnection(string connectionString)
        {
            this.ConnectionString = connectionString;

            if (!this.TestConnection())
            {
                throw new Exception("Can not connect to Server.");
            }
        }
        #endregion

        #region public properties
        public static DatabaseConnection Default
        {
            get
            {
                if (null == defaultInstance)
                {
                    defaultInstance = new DatabaseConnection();
                }
                return defaultInstance;
            }
        }
        #endregion

        #region private/protected methods
        private bool TestConnection()
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();

                success = true;
            }

            return success;
        }
        #endregion

        #region public methods
        public VideoCollection GetAllVideos()
        {
            VideoCollection collection = new VideoCollection();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM AllVideos", connection))
                {
                    connection.Open();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Video_ID"]);
                            string name = Convert.ToString(reader["Video_Name"]);
                            DateTime? date = Operations.Convert.ToNullableDateTime(Convert.ToString(reader["Video_Date"]), 
                                                                                   Convert.ToString(reader["Video_Time"]));
                            Uri url = new Uri(Convert.ToString(reader["Video_URL"]));
                            string classname = Convert.ToString(reader["Class_Name"]);
                            string project = Convert.ToString(reader["Project_Name"]);
                            int mode = Convert.ToInt32(reader["Mode_ID"]);
                            string episode = Convert.ToString(reader["Video_Episode"]);

                            collection.Add( new Video(id, name, date, url, classname, project, mode, episode));
                        }
                    }
                }
            }

            return collection;
        }

        public ProjectCollection GetAllProjects()
        {
            ProjectCollection collection = new ProjectCollection();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Projects", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = Convert.ToString(reader["Project_ID"]);
                            string name = Convert.ToString(reader["Project_Name"]);

                            collection.Add(new Project(id, name));
                        }
                    }
                }
            }

            return collection;
        }
        #endregion
    }
}
