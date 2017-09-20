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
        public void GetAllVideos()
        {
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
                            DateTime date = Operations.Convert.ToDateTime(Convert.ToString(reader["Video_Date"]), 
                                                                                   Convert.ToString(reader["Video_Time"]));
                            string url = Convert.ToString(reader["Video_URL"]);

                            Class c = Class.GetClassByName(Convert.ToString(reader["Class_Name"]));
                            Project project = Project.GetProjectByName(Convert.ToString(reader["Project_Name"]));
                            int mode = Convert.ToInt32(reader["Mode_ID"]);
                            string episode = Convert.ToString(reader["Video_Episode"]);
                            Video video = new Video(id, name, date, url, c, project, mode, episode);
                        }
                    }
                }
            }
        }

        public void AddVideo(Video video)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [VIDEOS] (Video_Name, Video_Date, Video_Time, Video_URL, Class_ID, Project_ID, Mode_ID, Video_Episode) " +
                    "V", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Video_ID"]);
                            string name = Convert.ToString(reader["Video_Name"]);
                            DateTime date = Operations.Convert.ToDateTime(Convert.ToString(reader["Video_Date"]),
                                                                                   Convert.ToString(reader["Video_Time"]));
                            string url = Convert.ToString(reader["Video_URL"]);

                            Class c = Class.GetClassByName(Convert.ToString(reader["Class_Name"]));
                            Project project = Project.GetProjectByName(Convert.ToString(reader["Project_Name"]));
                            int mode = Convert.ToInt32(reader["Mode_ID"]);
                            string episode = Convert.ToString(reader["Video_Episode"]);
                            //Video video = new Video(id, name, date, url, c, project, mode, episode);
                            //collection.Add( new Video(id, name, date, url, classname, project, mode, episode));
                        }
                    }
                }
            }
        }

        public void UpdateVideo(Video video)
        {

        }

        public void GetAllProjects()
        {
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
                            string format = Convert.ToString(reader["Project_Video_Title"]);
                            string scheduleFormat = Convert.ToString(reader["Project_Schedule_Title"]);
                            Project project = new Project(id, name, format, scheduleFormat);
                        }
                    }
                }
            }
        }

        public void GetAllClasses()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Classes", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = Convert.ToString(reader["Class_ID"]);
                            string name = Convert.ToString(reader["Class_Name"]);
                            string colorCode = Convert.ToString(reader["Class_Color"]);
                            string format = Convert.ToString(reader["Class_Video_Title"]);
                            string scheduleFormat = Convert.ToString(reader["Class_Schedule_Title"]);

                            Class c = new Class(id, name, colorCode, format, scheduleFormat);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
