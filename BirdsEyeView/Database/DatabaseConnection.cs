using DidiDerDenker.BirdsEyeView.Objects;
using DidiDerDenker.BirdsEyeView.Objects.Collections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

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
                            Video video = new Video(id, name, date, url, c, project, (Task)mode, episode);
                        }
                    }
                }
            }
        }

        public void AddVideo(Video video)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddVideo", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Video_Name", video.Name);
                    cmd.Parameters.AddWithValue("@Video_Date", video.Date.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Video_Time", video.Date.ToString("HH:mm"));
                    cmd.Parameters.AddWithValue("@Video_URL", video.URL);
                    cmd.Parameters.AddWithValue("@Class_ID", video.Class.Id);
                    cmd.Parameters.AddWithValue("@Project_ID", video.Project.Id);
                    cmd.Parameters.AddWithValue("@Mode_ID", (int)video.Mode);
                    cmd.Parameters.AddWithValue("@Video_Episode", video.Episode);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateVideo(Video video)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateVideo", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Video_ID", video.Id);
                    cmd.Parameters.AddWithValue("@Video_Name", video.Name);
                    cmd.Parameters.AddWithValue("@Video_Date", video.Date.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Video_Time", video.Date.ToString("HH:mm"));
                    cmd.Parameters.AddWithValue("@Video_URL", video.URL);
                    cmd.Parameters.AddWithValue("@Class_ID", video.Class.Id);
                    cmd.Parameters.AddWithValue("@Project_ID", video.Project.Id);
                    cmd.Parameters.AddWithValue("@Mode_ID", (int)video.Mode);
                    cmd.Parameters.AddWithValue("@Video_Episode", video.Episode);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
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
                            Class c = Class.GetClassById(Convert.ToString(reader["Class_ID"]));
                            string format = Convert.ToString(reader["Project_Video_Title"]);
                            string scheduleFormat = Convert.ToString(reader["Project_Schedule_Title"]);
                            Project project = new Project(id, name, c, format, scheduleFormat);
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
