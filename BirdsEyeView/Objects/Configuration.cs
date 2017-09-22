using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Objects
{
    public class Configuration
    {
        #region fields
        private string serverName;
        private string serverUser;
        private string serverPassword;

        private string userName;
        private string userPassword;
        private string userStayLoggedIn;
        #endregion

        #region constructor
        public Configuration(string servername, string serveruser, string serverpassword)
        {
            this.ServerName = servername;
            this.serverUser = serveruser;
            this.ServerPassword = serverpassword;
        }
        #endregion

        #region public properties
        public string ServerName
        {
            get { return this.serverName; }
            set { this.serverName = value; }
        }
        public string ServerUser
        {
            get { return this.serverUser; }
            set { this.serverUser = value; }
        }
        public string ServerPassword
        {
            get { return this.serverPassword; }
            set { this.serverPassword = value; }
        }
        #endregion
    }
}
